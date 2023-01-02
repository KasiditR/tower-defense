using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
namespace Towerdefense
{
    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public class PoolingManager : MonoBehaviour
    {
        public static PoolingManager Instance;
        [SerializeField] private List<Pool> _pools = new List<Pool>();
        private Dictionary<string,Queue<GameObject>> _poolDictionary;
        private GameObject _tempObjectToSpawn;
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
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();
            foreach (Pool item in _pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();
                for (int i = 0; i < item.size; i++)
                {
                    GameObject obj = Instantiate(item.prefab);
                    obj.transform.SetParent(this.transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                _poolDictionary.Add(item.tag,objectPool);
            }
        }
        public Queue<GameObject> GetQueueInPooling(string tag)
        {
            return _poolDictionary[tag];
        }
        public GameObject SpawnFromPool(string tag,Vector3 position,Quaternion rotation)
        {
            if (!_poolDictionary.ContainsKey(tag))
            {
                Debug.Log($"Pool with tag {tag} doesn't exist");
                return null;
            }
            Queue<GameObject> objectPool = _poolDictionary[tag];
            if (objectPool.All(x => x.activeInHierarchy))
            {
                Pool pool = _pools.Find(x => x.tag == tag);
                _tempObjectToSpawn = Instantiate(pool.prefab,Vector3.zero,Quaternion.identity);
                _tempObjectToSpawn.transform.SetParent(this.transform);
            }
            else
            {
                _tempObjectToSpawn = _poolDictionary[tag].Dequeue();
            }
            
            _tempObjectToSpawn.SetActive(true);
            _tempObjectToSpawn.transform.position = position;
            _tempObjectToSpawn.transform.rotation = rotation;

            IPooledObject pooledObject = _tempObjectToSpawn.GetComponent<IPooledObject>();
            pooledObject?.OnObjectSpawn();

            _poolDictionary[tag].Enqueue(_tempObjectToSpawn);

            return _tempObjectToSpawn;
        }
    }
}
