using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    
    [CreateAssetMenu(fileName = "EnemySO", menuName = "towerdefense/EnemySO", order = 0)]
    public class EnemySO : ScriptableObject 
    {
        public string tag;
        public float hp;
        public float speed;
        public CharacterType characterType;
        [HideInInspector] public float firstHp;
        [HideInInspector] public float firstSpeed;
        public void IncreaseStatus(float value)
        {
            hp += (this.hp/100) * value;
            speed += (this.speed/100) * value;
        }
        public void SetFirstStatus()
        {
            firstHp = hp;
            firstSpeed = speed;
        }
        public void GetFirstStatus()
        {
            hp = firstHp;
            speed = firstSpeed;
        }
    }
}
