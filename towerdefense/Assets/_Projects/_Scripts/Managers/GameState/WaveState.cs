using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;
using System;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace Towerdefense
{
    public class WaveState : GameBaseState
    {
        private WaveSO _waveSO;
        private PoolingManager _poolingManager;
        private bool _isDeadAll;
        private List<GameObject> _enemyInWave = new List<GameObject>();
        public override void EnterState(GameManager gameManager)
        {
            gameManager.SendNotification("Start wave enemy");
            _poolingManager = PoolingManager.Instance;
            _waveSO = gameManager.WaveSO;
            SpawnWave();
        }
        public override void ExecuteState(GameManager gameManager)
        {
            if (_enemyInWave.Count == 0)
            {
                return;
            }
            _isDeadAll = _enemyInWave.All(x => !x.activeInHierarchy);
            if (_waveSO.WaveCount >= _waveSO.waveMax && _isDeadAll)
            {
                gameManager.SwitchState(new GameOverState());
                return;
            }
            if (_isDeadAll)
            {
                gameManager.SwitchState(new PrepareState());
            }
        }

        public override void ExitState(GameManager gameManager)
        {

        }
        private async void SpawnWave()
        {
            _enemyInWave = new List<GameObject>();
            _waveSO.WaveCount++;
            for (int i = 0; i < _waveSO.waveEnemy; i++)
            {
                SpawnEnemy();
                await Task.Delay(500);
            }
        }

        private void SpawnEnemy()
        {
            Random ran = new Random();
            int index = ran.Next(0,_waveSO.tagEnemies.Length);
            string tag = _waveSO.tagEnemies[index];
            GameObject enemy = _poolingManager.SpawnFromPool(tag,new Vector3(0,0.5f,0),Quaternion.identity);
            _enemyInWave.Add(enemy);
        }
    }
}
