using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Towerdefense.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private string _gameSceneName;
        private void OnEnable()
        {
            _playButton.onClick.AddListener(() => PlayOnClick());
            _quitButton.onClick.AddListener(() => QuitOnClick());
        }
        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(() => PlayOnClick());
            _quitButton.onClick.RemoveListener(() => QuitOnClick());
        }
        private void PlayOnClick()
        {
            SceneManager.LoadScene(_gameSceneName);
        }
        private void QuitOnClick()
        {
            Application.Quit();
        }
    }
}
