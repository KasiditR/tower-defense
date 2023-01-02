using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Towerdefense
{
    public class RemoveTurret : MonoBehaviour
    {
        [SerializeField] private Image _imageTurret;
        [SerializeField] private GameObject _container;
        [SerializeField] private Button _sellButton;
        [SerializeField] private TurretSO[] _turretSOs;
        private Dictionary<string,Sprite> _spriteDictionary;
        private Node _node;
        private void Start()
        {
            _spriteDictionary = new Dictionary<string, Sprite>();
            foreach (TurretSO item in _turretSOs)
            {
                _spriteDictionary.Add(item.tag,item.uiDisplay);
            }
        }
        private void OnEnable()
        {
            PrepareState.onPrepared += SetEmptyPanel;
            Node.onTurretNotEmpty += OpenSellPanel;
        }
        private void OnDisable()
        {
            PrepareState.onPrepared -= SetEmptyPanel;
            Node.onTurretNotEmpty -= OpenSellPanel;
        }
        public void SetEmptyPanel()
        {
            _node = null;
            _container.SetActive(false);
            _sellButton.onClick.RemoveAllListeners();
        }
        private void OpenSellPanel(Node node)
        {
            _container.SetActive(true);
            _node = node;
            _imageTurret.sprite = _spriteDictionary[_node.GetTagTurret()];
            if (_sellButton.onClick != null)
            {
                _sellButton.onClick.RemoveAllListeners();
            }

            _sellButton.onClick.AddListener(() => SellTurretOnNode());
        }
        private void SellTurretOnNode()
        {
            _node.SellTurret();
            _sellButton.onClick.RemoveAllListeners();
            _container.SetActive(false);
        }
        
    }
}
