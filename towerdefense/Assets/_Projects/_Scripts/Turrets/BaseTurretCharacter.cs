using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    public abstract class BaseTurretCharacter : BaseCharacter
    {
        [SerializeField] protected TurretSO turretSO;
        [SerializeField] protected Transform firePoint;
        [SerializeField] protected Transform modelRotate;
        [SerializeField] protected LayerMask layerMask;
        public float damage {get;protected set;}
        public float fireRate {get;protected set;}
        public float range {get;protected set;}
        protected bool isFire;
        public const float OFFSET = 0.5f;
        protected virtual void Init(float fireRate, float damage, float range,CharacterType characterType)
        {
            this.fireRate = fireRate;
            this.damage = damage;
            this.range = range + OFFSET;
            this.characterType = characterType;
        }
        public abstract void Fire();
        public bool CheckEnemyIsSameType(BaseEnemyCharacter baseEnemyCharacter)
        {
            if (baseEnemyCharacter.characterType == this.characterType)
            {
                return true;
            }
            return false;
        }
        // private void OnDrawGizmosSelected() 
        // {
        //     Gizmos.color = Color.red;
        //     Gizmos.DrawWireSphere(transform.position,turretSO.range + OFFSET);
        // }
        protected IEnumerator CountFireCoroutine()
        {
            isFire = true;
            yield return new WaitForSeconds(this.fireRate);
            isFire = false;
        }
    }
}
