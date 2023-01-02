using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Towerdefense
{
    public class CancelTurret : MonoBehaviour
    {
        [SerializeField] private GameObject _cancelPanel;
        private BuildManager _buildManager;
        private void Start()
        {
            _buildManager = BuildManager.Instance;
        }
        private void OnEnable()
        {
            ShopItem.onShopTurret += OpenCancel;
            Node.onTurretPlace += CloseCancel;
        }
        private void OnDisable()
        {
            ShopItem.onShopTurret -= OpenCancel;
            Node.onTurretPlace -= CloseCancel;
        }
        private void OpenCancel()
        {
            _cancelPanel.SetActive(true);
        }
        private void CloseCancel()
        {
            _cancelPanel.SetActive(false);
        }
        public void CancelOnClick()
        {
            _buildManager?.SetKeyBuild(string.Empty);
            _cancelPanel.SetActive(false);
        }
    }
}
