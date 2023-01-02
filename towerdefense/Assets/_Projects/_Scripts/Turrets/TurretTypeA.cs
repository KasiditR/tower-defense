using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    public class TurretTypeA : BaseTurretCharacter,IPooledObject
    {
        [SerializeField] private string _tagBullet;
        private BaseEnemyCharacter _target;
        private Collider[] _colliders;
        private PoolingManager _poolingManager;
        private void Start()
        {
            _poolingManager = PoolingManager.Instance;
        }
        public void OnObjectSpawn()
        {
            base.Init(turretSO.fireRate,turretSO.damage,turretSO.fireRate,turretSO.characterType);
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
            foreach (Collider item in _colliders)
            {
                if (item.TryGetComponent<BaseEnemyCharacter>(out _target))
                {
                    if (_target != null)
                    {
                        Debug.DrawLine(firePoint.position, _target.transform.position, Color.red);
                        modelRotate.LookAt(_target.transform.position);
                        Fire();
                    }
                }
            }
        }
        public override void Fire()
        {
            if (!this.isFire)
            {
                StartCoroutine(CountFireCoroutine());
                float resultDamage = this.damage;
                if (this.CheckEnemyIsSameType(_target))
                {
                    resultDamage *= 2;
                }
                BulletVFX bullet = _poolingManager.SpawnFromPool(_tagBullet,this.transform.position,Quaternion.identity).GetComponent<BulletVFX>();
                bullet.InitBulletVFX(_target.transform,0.2f);
                IDamageable damageable = _target.GetComponent<IDamageable>();
                damageable.TakeDamage(resultDamage);
            }
        }
    }
}
