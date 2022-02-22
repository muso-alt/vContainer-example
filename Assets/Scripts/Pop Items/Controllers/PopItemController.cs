using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Pop_Items.Data;
using UnityEngine.Assertions;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace Pop_Items
{
    public class PopItemController : IStartable, IDisposable
    {
        private PositionByCameraConfigurator _positionByCamera;
        
        private readonly PopItemsSpawnerData _popItemsData;
        private readonly PopItemsSpawner _spawner;

        private bool _canSpawnPopItems;
        
        public PopItemController(PopItemsSpawnerData popItemsData, PopItemsSpawner spawner)
        {
            _popItemsData = popItemsData;
            _spawner = spawner;
        }

        public async void Start()
        {
            _positionByCamera = new PositionByCameraConfigurator(_popItemsData.LeftOffset, _popItemsData.RightOffset,
                _popItemsData.ItemsOffset);

            while (_canSpawnPopItems)
            {
                Initialize(await _spawner.SpawnObject(_popItemsData.CountOfSpawningItems));
                await Task.Delay(TimeSpan.FromSeconds(_popItemsData.SpawnInterval));
            }
        }
        
        private void Initialize(IEnumerable<GameObject> spawnedObjects)
        {
            foreach (var spawnedObject in spawnedObjects)
            {
                var popItem = spawnedObject.GetComponent<PopItemMain>();
                
                Assert.IsNotNull(popItem);
                
                ConfigurePosition(popItem.transform);

                if (CanCreateCorrectPopItem())
                {
                    popItem.SetSprite(_popItemsData.CorrectAnswerSprite);
                }

                popItem.OnResetted -= _spawner.ReturnPopItem;
                popItem.OnResetted += _spawner.ReturnPopItem;
            }
        }

        private void ConfigurePosition(Transform item)
        {
            item.position = new Vector3(_positionByCamera.GetNewPosition(), _popItemsData.StartVerticalPosition);
        }

        public void Dispose()
        {
            _positionByCamera.ResetToDefault();
            _spawner.Dispose();
        }

        /// <summary>
        /// Get frequency bool type
        /// </summary>
        /// <returns></returns>
        private bool CanCreateCorrectPopItem()
        {
            var randomValue = Random.Range(0, _popItemsData.HundredForFrequency);

            return randomValue <= _popItemsData.FrequencyOfCorrectObjects;
        }
    }
}