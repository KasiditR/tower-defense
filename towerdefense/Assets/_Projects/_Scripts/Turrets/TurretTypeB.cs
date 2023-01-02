using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

namespace Towerdefense
{
    public class TurretTypeB : BaseTurretCharacter,IPooledObject
    {
        [SerializeField] private string _tagBullet;
        [SerializeField] private Vector2Int _rangeDamage = new Vector2Int(8,11);
        private BaseEnemyCharacter _target;
        private Collider[] _colliders;
        private List<BaseEnemyCharacter> _enemyCharacters;
        private float distance;
        private PoolingManager _poolingManager;
        public void OnObjectSpawn()
        {
            _poolingManager = PoolingManager.Instance;
            base.Init(turretSO.fireRate,turretSO.damage,turretSO.fireRate,turretSO.characterType);
        }
        public override void Fire()
        {
            if (!this.isFire)
            {
                StartCoroutine(CountFireCoroutine());
                float resultDamage = Random.Range((float)_rangeDamage.x,(float)_rangeDamage.y);
                BulletVFX bullet = _poolingManager?.SpawnFromPool(_tagBullet,this.transform.position,Quaternion.identity).GetComponent<BulletVFX>();
                bullet.InitBulletVFX(_target.transform,0.2f);
                bullet.GetComponentInChildren<ExplosionBullet>().InitDamage(resultDamage,this.characterType);
            }
        }
        private void Update()
        {
            TargetEnemy();
        }
        private void TargetEnemy()
        {
            _colliders = Physics.OverlapSphere(this.transform.position, this.range, layerMask);
            if (_colliders.Length == 0)
            {
                return;
            }
            
            _enemyCharacters = new List<BaseEnemyCharacter>();
            foreach (var item in _colliders)
            {
                _enemyCharacters.Add(item.GetComponent<BaseEnemyCharacter>());
            }

            _target = GetBaseEnemyCharacter(_enemyCharacters);

            Debug.DrawLine(firePoint.position, _target.transform.position, Color.black);
            modelRotate.LookAt(_target.transform.position);
            Fire();
        }
        private BaseEnemyCharacter GetBaseEnemyCharacter(List<BaseEnemyCharacter> baseEnemyCharacters) 
        {
            BaseEnemyCharacter baseEnemyCharacter = baseEnemyCharacters[0];
            for (int i = 0; i < baseEnemyCharacters.Count; i++)
            {
                float newDistance = Vector3.Distance(this.transform.position,baseEnemyCharacters[i].transform.position);
                float oldDistance = Vector3.Distance(this.transform.position,baseEnemyCharacter.transform.position);
                if (newDistance > oldDistance && baseEnemyCharacters[i].hp > baseEnemyCharacter.hp)
                {
                    baseEnemyCharacter = baseEnemyCharacters[i];
                }
            }
            return baseEnemyCharacter;
        }
    }
}
