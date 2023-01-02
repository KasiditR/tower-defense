using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    public class TurretDisplay : MonoBehaviour
    {
        [SerializeField] private float _radiusSize;
        [SerializeField] private GameObject _radiusObject;
        [SerializeField] private Renderer _radiusRender;
        [SerializeField] private Renderer[] _renderers;
        [SerializeField] private Color _wrongColor;
        [SerializeField] private Color _passColor;
        private void OnValidate() 
        {
            if (_renderers == null)
            {
                _renderers = GetComponentsInChildren<MeshRenderer>();
            }
        }
        private void Start()
        {
            _radiusObject.transform.localScale = new Vector3(_radiusSize + 0.5f,_radiusSize,_radiusSize + 0.5f);
        }
        public void CanNotPlaceTurret()
        {
            _radiusRender.material.color = _wrongColor;
            foreach (Renderer item in _renderers)
            {
                item.material.color = _wrongColor;
            }
        }
        public void PlaceTurret()
        {
            _radiusRender.material.color = _passColor;
            foreach (Renderer item in _renderers)
            {
                item.material.color = _passColor;
            }
        }
    }
}
