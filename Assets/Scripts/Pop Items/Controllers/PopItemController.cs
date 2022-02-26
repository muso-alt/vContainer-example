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
        private readonly PopItemModel _itemModel;

        private bool _canSpawnPopItems = true;

        public PopItemController(PopItemsSpawnerData popItemsData, PopItemsSpawner spawner, PopItemModel itemModel)
        {
            _popItemsData = popItemsData;
            _spawner = spawner;
            _itemModel = itemModel;
        }

        async void IStartable.Start()
        {
            _canSpawnPopItems = true;
            
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
                spawnedObject.SetActive(true);
                
                var popItem = spawnedObject.GetComponent<PopItemView>();
                
                Assert.IsNotNull(popItem);
                
                ConfigurePosition(popItem.transform);

                if (CanCreateCorrectPopItem())
                {
                    popItem.SetSprite(_popItemsData.CorrectAnswerSprite);
                    _itemModel.AddPopItem(popItem);
                }

                popItem.Triggered -= _itemModel.Triggered;
                popItem.Triggered += _itemModel.Triggered;

                popItem.Tapped -= _itemModel.CheckClickedPopItem;
                popItem.Tapped += _itemModel.CheckClickedPopItem;
            }
        }

        private void ConfigurePosition(Transform item)
        {
            item.position = new Vector3(_positionByCamera.GetNewPosition(), _popItemsData.StartVerticalPosition);
        }

        public void Dispose()
        {
            _canSpawnPopItems = false;
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