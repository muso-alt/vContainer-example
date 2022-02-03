using UnityEngine;

namespace DefaultNamespace.Data
{
    [CreateAssetMenu(fileName = "ObjectsPoolData", menuName = "Develop/ObjectPoolData", order = 0)]
    public class ObjectsPoolData : ScriptableObject
    {
        [SerializeField] private GameObject[] _spawnableObjects;

        public GameObject[] SpawnableObjects => _spawnableObjects;
    }
}