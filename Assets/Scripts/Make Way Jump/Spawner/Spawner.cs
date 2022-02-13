using UnityEngine;

namespace Make_Way_Jump
{
    public class Spawner
    {
        private readonly GameObject[] _spawnObjects;
        
        public Spawner(GameObject[] collection)
        {
            _spawnObjects = collection;
        }

        public GameObject Get()
        {
            return Object.Instantiate(_spawnObjects[Random.Range(0, _spawnObjects.Length)]);
        }
    }
}