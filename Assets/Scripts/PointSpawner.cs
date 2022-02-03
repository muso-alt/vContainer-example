using DefaultNamespace.Data;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class PointSpawner
    {
        private readonly ObjectsPoolData _spawnableObjects;
        private readonly TapModel _tapModel;
        
        public PointSpawner(ObjectsPoolData poolData, TapModel tapModel)
        {
            _spawnableObjects = poolData;
            _tapModel = tapModel;
        }

        public void Debugger()
        {
            Debug.Log(_spawnableObjects.SpawnableObjects.Length);
        }

        public void SpawnObject(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ConfigureSpawnedPoint(Object.Instantiate(
                    _spawnableObjects.SpawnableObjects[i % _spawnableObjects.SpawnableObjects.Length]));
            }
        }

        private void ConfigureSpawnedPoint(GameObject spawnedObject)
        {
            spawnedObject.transform.position = new Vector2(Random.Range(-4f, 4),Random.Range(-4f, 4));

            var pointer = spawnedObject.GetComponent<Pointer>();
            
            Assert.IsNotNull(pointer, $"Spawned object don't have {nameof(Pointer)}");

            pointer.Tapped += _tapModel.PointTapped;
        }
    }
}