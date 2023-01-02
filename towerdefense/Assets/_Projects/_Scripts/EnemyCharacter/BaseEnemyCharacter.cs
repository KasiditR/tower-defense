using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    public abstract class BaseEnemyCharacter : BaseCharacter
    {
        [SerializeField] protected EnemySO enemySO;
        public float hp {get;protected set;}
        public float speed{get;protected set;}
        public virtual void InitEnemy(float hp, float speed,CharacterType characterType)
        {
            this.hp = hp;
            this.speed = speed;
            this.characterType = characterType;
        }
        public void IncreaseStatus(float value)
        {
            hp += (this.hp/100) * value;
            speed += (this.speed/100) * value;
        }
        public void SlowSpeed()
        {
            float result = (this.speed/100)*35;
            this.speed -= result;
        }
    }
}
