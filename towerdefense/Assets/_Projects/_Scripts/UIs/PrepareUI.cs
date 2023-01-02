using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace Towerdefense
{
    public class PrepareUI : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private Button _readyButton;
        private GameManager _gameManager;
        private void Awake()
        {
            if (_container.activeInHierarchy)
            {
                _container.SetActive(false);
            }
        }
        private void Start()
        {
            _gameManager = GameManager.Instance;
        }
        private void OnEnable() 
        {
            PrepareState.onPrepared += ShowPanel;
            _readyButton.onClick.AddListener(() => ReadyOnClick());
        }
        private void OnDisable()
        {
            PrepareState.onPrepared -= ShowPanel;
            _readyButton.onClick.RemoveListener(() => ReadyOnClick());
        }
        private void ReadyOnClick()
        {
            _gameManager.SetIsPrepared(true);
            _container.SetActive(false);
        }
        private void ShowPanel()
        {
            if (_container.activeInHierarchy)
            {
                _container.SetActive(false);
            }
            else
            {
                _container.SetActive(true);
            }
        }
    }
}
