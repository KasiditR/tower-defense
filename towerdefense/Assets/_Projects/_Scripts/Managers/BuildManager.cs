using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Towerdefense
{
    [Serializable]
    public class ObjectDisplay
    {
        public string tag;
        public GameObject prefab;
    }
    public class BuildManager : MonoBehaviour
    {
        public static BuildManager Instance;
        [SerializeField] private string _keyPoolingObject;
        [SerializeField] private ObjectDisplay[] _objectDisplays;
        private PoolingManager _poolingManager;
        private Dictionary<string,GameObject> _displayDictionary = new Dictionary<string, GameObject>();
        private void Awake()
        {
            if (Instance != null)
            {
                return;
            }
            Instance = this;
        }
        private void Start()
        {
            _poolingManager = PoolingManager.Instance;
            foreach (ObjectDisplay item in _objectDisplays)
            {
                GameObject turretDisplay = Instantiate(item.prefab);
                turretDisplay.SetActive(false);
                turretDisplay.transform.SetParent(this.transform);
                _displayDictionary.Add(item.tag,turretDisplay);
            }
        }
        public string GetKeyBuild()
        {
            return _keyPoolingObject;
        }
        public GameObject GetTurretToBuild()
        {
            return _poolingManager?.SpawnFromPool(_keyPoolingObject,Vector3.zero,Quaternion.identity);
        }
        public GameObject GetTurretInDisplay()
        {
            return _displayDictionary[_keyPoolingObject + "display"];
        }
        public void SetKeyBuild(string key)
        {
            _keyPoolingObject = key;
        }
    }
}
