using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
namespace Towerdefense
{
    public class UpdateStatusEnemy : MonoBehaviour
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private EnemySO[] _enemySOs;
        private GameObject[] _enemies;
        private BaseEnemyCharacter _baseEnemyCharacter;
        private GameManager _gameManager;
        private PoolingManager _poolingManager;
        private void Start()
        {
            _gameManager = GameManager.Instance;
            _poolingManager = PoolingManager.Instance;
            foreach (EnemySO item in _enemySOs)
            {
                item.SetFirstStatus();
            }
        }
        private void OnEnable()
        {
            _timer.onTimerEnd += UpdateStatus;
        }
        private void OnDisable()
        {
            _timer.onTimerEnd -= UpdateStatus;
        }
        private void OnApplicationQuit() 
        {
            foreach (EnemySO item in _enemySOs)
            {
                item.GetFirstStatus();
            }
        }
        private void UpdateStatus()
        {
            _gameManager?.SendNotification("Enemy PowerUP");
            foreach (var item in _enemySOs)
            {
                item.IncreaseStatus(0.5f);
                _enemies = _poolingManager?.GetQueueInPooling(item.tag).ToArray();
                for (var i = 0; i < _enemies.Length; i++)
                {
                    _baseEnemyCharacter = _enemies[i].GetComponent<BaseEnemyCharacter>();
                    if (_baseEnemyCharacter.gameObject.activeInHierarchy)
                    {
                        _baseEnemyCharacter.IncreaseStatus(0.5f);
                    }
                }
            }
            _timer.PlayTime();
        }
    }
}
