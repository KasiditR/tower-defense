using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Towerdefense
{
    public class TurretTypeC : BaseTurretCharacter,IPooledObject
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
                BulletVFX bullet = _poolingManager?.SpawnFromPool(_tagBullet,this.transform.position,Quaternion.identity).GetComponent<BulletVFX>();
                bullet.InitBulletVFX(_target.transform,0.2f);
                IDamageable damageable = _target.GetComponent<IDamageable>();
                damageable.TakeDamage(resultDamage);
                _target.SlowSpeed();
            }
        }
        private void Update()
        {
            TargetEnemy();
        }
        private void TargetEnemy()
        {
            _colliders = Physics.OverlapSphere(this.transform.position, base.range, layerMask);

            if (_colliders.Length == 0)
            {
                return;
            }
            Collider col = _colliders.OrderBy(x => Vector3.Distance(this.transform.position,x.transform.position)).First();
            _target = col.GetComponent<BaseEnemyCharacter>();
            Debug.DrawLine(firePoint.position, _target.transform.position, Color.blue);
            modelRotate.LookAt(col.transform.position);
            Fire();
        }
        private void OnDrawGizmosSelected() 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,turretSO.range + OFFSET);
        }
    }
}
