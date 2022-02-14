using UnityEngine;
using UnityEngine.Assertions;

using Pop_Items.Data;
using Pop_Items.Interfaces;

namespace Pop_Items
{
    public class PopItemsSpawner
    {
        private PopItemsPooler _pooler;
        private  IInitializer<PopItemMain> _initializer;
        
        public PopItemsSpawner(PopItemsSpawnerData poolData, IInitializer<PopItemMain> initializer)
        {
            _pooler = new PopItemsPooler(poolData.Objects);

            _initializer = initializer;
        }

        public async void SpawnObject(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ConfigureSpawnedObject(await _pooler.Get());
            }
        }

        private void ConfigureSpawnedObject(GameObject spawnedObject)
        {
            spawnedObject.SetActive(true);

            var popItem = spawnedObject.GetComponent<PopItemMain>();
            
            Assert.IsNotNull(popItem, "popItem != null");

            popItem.OnResetted -= ReturnPopItem;
            popItem.OnResetted += ReturnPopItem;
            
            _initializer.Initialize(popItem);
        }
        
        public void Dispose()
        {
            _initializer.Dispose();
            _pooler.Dispose();
        }
        
        private void ReturnPopItem(GameObject spawnedObject)
        {
            _pooler.Return(spawnedObject);
        }
    }
}