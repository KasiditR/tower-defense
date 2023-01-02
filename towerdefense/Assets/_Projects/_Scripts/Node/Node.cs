using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Towerdefense
{
    public class Node : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Color _hoverColor;
        [SerializeField] private Color _startColor;
        private string _tag;
        private GameObject _turret;
        private BuildManager _buildManager;
        private GameManager _gameManager;
        private TurretDisplay _turretDisplay;
        public static event Action<Node> onTurretNotEmpty;
        public static event Action onTurretPlace;
        private void OnValidate() 
        {
            if (_renderer == null)
            {
                _renderer = this.GetComponent<MeshRenderer>();
            }
        }
        private void Start()
        {
            _buildManager = BuildManager.Instance;
            _gameManager = GameManager.Instance;
            _startColor = _renderer.material.color;
        }

        private void OnMouseEnter() 
        {
            _renderer.material.SetColor("_Color",_hoverColor);
            if (_buildManager?.GetKeyBuild() != string.Empty)
            {
                _turretDisplay = _buildManager?.GetTurretInDisplay().GetComponent<TurretDisplay>();
                _turretDisplay.gameObject.SetActive(true);
                _turretDisplay.transform.position = this.transform.position + new Vector3(0,0.7f,0);
                if (_turret == null)
                {
                    _turretDisplay.PlaceTurret();
                }
                else
                {
                    _turretDisplay.CanNotPlaceTurret();
                }
            }
        }
        private void OnMouseExit() 
        {
            _renderer.material.SetColor("_Color",_startColor);
            if (_turretDisplay != null)
            {
                _turretDisplay.gameObject.SetActive(false);
            }   
        }
        private void OnMouseDown() 
        {
            if (_turretDisplay == null)
            {
                return;
            }
            if (_turret != null && _buildManager?.GetKeyBuild() != string.Empty)
            {
                return;
            }
            if (_turret != null || _gameManager.GetIsPrepared())
            {
                onTurretNotEmpty?.Invoke(this);
                return;
            }
            if (_buildManager?.GetKeyBuild() == string.Empty)
            {
                return;    
            }
            _tag = _buildManager?.GetKeyBuild();
            _turret = _buildManager?.GetTurretToBuild();
            _turret.transform.position = this.transform.position + new Vector3(0,0.5f,0);
            _turretDisplay.gameObject.SetActive(false);
            _buildManager?.SetKeyBuild(string.Empty);
            onTurretPlace?.Invoke();
        }
        public void SellTurret()
        {
            _turret.SetActive(false);
            _turret = null;
        }
        public string GetTagTurret()
        {
            return _tag;
        }
    }
}
