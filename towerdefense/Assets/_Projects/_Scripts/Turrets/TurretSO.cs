using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    
    [CreateAssetMenu(fileName = "TurretSO", menuName = "towerdefense/TurretSO", order = 0)]
    public class TurretSO : ScriptableObject 
    {
        public Sprite uiDisplay;
        public string tag;
        public float damage;
        public float fireRate;
        public float range;
        public CharacterType characterType;
    }
}
