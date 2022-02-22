using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Pop_Items.Data;

namespace Pop_Items
{
    public class PopItemsSpawner
    {
        private PopItemsPooler _pooler;

        public event Action<GameObject> Spawned;
        
        public PopItemsSpawner(PopItemsSpawnerData poolData)
        {
            _pooler = new PopItemsPooler(poolData.Objects);
        }

        public async Task<GameObject[]> SpawnObject(int count)
        {
            var spawnedObjects = new List<GameObject>();
            
            for (var i = 0; i < count; i++)
            {
                spawnedObjects.Add(await _pooler.Get());
            }

            return spawnedObjects.ToArray();
        }
        
        public void Dispose()
        {
            _pooler.Dispose();
        }
        
        public void ReturnPopItem(GameObject spawnedObject)
        {
            _pooler.Return(spawnedObject);
        }
    }
}