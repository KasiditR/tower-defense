using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    public class Enemy : BaseEnemyCharacter,IDamageable,IPooledObject
    {
        [SerializeField] private Health _health;
        [SerializeField] private EnemyMovement _enemyMovement;
        public event Action onDie;

        public void TakeDamage(float damage)
        {
            this.hp -= damage;
            _health.ModifyHealth(-damage);
            if (this.hp > 0)
            {
                return;
            }
            this.gameObject.SetActive(false);
            onDie?.Invoke();
        }
        public void OnObjectSpawn()
        {
            InitEnemy(enemySO.hp,enemySO.speed,enemySO.characterType);
            _health.InitHealth(enemySO.hp);
            _enemyMovement.InitMovementSpeed(enemySO.speed);
        }
    }
}
