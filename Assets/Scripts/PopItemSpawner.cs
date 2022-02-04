using DefaultNamespace.Data;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class PopItemSpawner
    {
        private readonly TapModel _tapModel;

        private Pooler _pooler;
        
        public PopItemSpawner(ObjectsPoolData poolData, TapModel tapModel)
        {
            _tapModel = tapModel;
            
            _pooler = new Pooler(poolData.SpawnableObjects);
        }

        public async void SpawnObject(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ConfigureSpawnedPoint(await _pooler.Get());
            }
        }

        private void ConfigureSpawnedPoint(GameObject spawnedObject)
        {
            spawnedObject.transform.position = new Vector2(Random.Range(-4f, 4),Random.Range(-4f, 4));

            var pointer = spawnedObject.GetComponent<PopItem>();
            
            Assert.IsNotNull(pointer, $"Spawned object don't have {nameof(PopItem)}");

            pointer.Tapped += _tapModel.PointTapped;
            pointer.Resetted += ReturnPopItem;
        }

        private void ReturnPopItem(GameObject spawnedObject)
        {
            _pooler.Return(spawnedObject);
        }
    }
}