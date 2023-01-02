using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Towerdefense
{
    
    [CreateAssetMenu(fileName = "WaveSO", menuName = "towerdefense/WaveSO", order = 0)]
    public class WaveSO : ScriptableObject 
    {
        private int waveCount = 0;
        public int waveMax = 10;
        public int waveEnemy = 10;
        public string[] tagEnemies;//get enemies from pool by tag

        public int WaveCount 
        { 
            get => waveCount; 
            set 
            {
                waveCount = value;
                onCountChange?.Invoke(waveCount,waveMax);
            } 
        }

        public static event Action<int,int> onCountChange;
    }
}
