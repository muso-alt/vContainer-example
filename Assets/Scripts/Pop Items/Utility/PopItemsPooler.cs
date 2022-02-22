using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

namespace Pop_Items
{
    public class PopItemsPooler
    {
        private readonly GameObject[] PoolingObjects;
        private readonly List<GameObject> ReturnedObjects;
        
        private int _currentObjectIndex = -1;

        public PopItemsPooler(GameObject[] poolingObjects)
        {
            ReturnedObjects = new List<GameObject>();
            PoolingObjects = poolingObjects;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<GameObject> Get()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (ReturnedObjects.Count > 0)
            {
                var item = ReturnedObjects[0];
                ReturnedObjects.Remove(item);
                return item;
            }

            var one = Create(PoolingObjects[GetIndex(PoolingObjects.Length)]);

            return one;
        }

        public void Return(GameObject item)
        {
            if (ReturnedObjects.Contains(item)) return;

            ReturnedObjects.Add(item);
        }

        protected virtual int GetIndex(int maxValue)
        {
            _currentObjectIndex++;
            
            if (_currentObjectIndex >= maxValue)
                _currentObjectIndex = 0;
            
            return _currentObjectIndex;
        }

        public void Dispose()
        {
            ReturnedObjects.Clear();
        }

        private GameObject Create(GameObject spawnObject)
        {
            return Object.Instantiate(spawnObject);
        }
    }
}