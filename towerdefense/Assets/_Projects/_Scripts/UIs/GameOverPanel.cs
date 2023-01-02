using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Towerdefense
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private string _mainMenuSceneName;
        public void MainMenuOnClick()
        {
            SceneManager.LoadScene(_mainMenuSceneName);
        }
    }
}
