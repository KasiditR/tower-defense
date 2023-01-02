using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    public class WaypointManager : MonoBehaviour
    {
        public static WaypointManager Instance;
        [SerializeField] private Transform[] _waypoints = new Transform[0];

        public Transform[] Waypoints { get => _waypoints;}
        #if UNITY_EDITOR
        private void OnValidate() 
        {
            if (_waypoints.Length != this.transform.childCount)
            {
                _waypoints = new Transform[this.transform.childCount];
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    _waypoints[i] = this.transform.GetChild(i);
                }
            }
        }
        #endif
        private void Awake()
        {
            if (Instance != null)
            {
                return;
            }

            Instance = this;
        }
    }
}
