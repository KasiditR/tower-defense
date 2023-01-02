using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameOverPanel _gameOverPanel;
        private void OnEnable()
        {
            GameOverState.onGameOver += OpenGameOverPanel;
        }
        private void OnDisable()
        {
            GameOverState.onGameOver -= OpenGameOverPanel;
        }
        private void OpenGameOverPanel()
        {
            _gameOverPanel.gameObject.SetActive(true);
        }
    }
}
