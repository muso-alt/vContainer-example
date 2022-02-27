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
        private readonly PopItemMainView _popItemMainView;
        private readonly ScoreModel _scoreModel;

        private bool _canSpawnPopItems = true;

        public PopItemController(PopItemsSpawnerData popItemsData, PopItemsSpawner spawner, PopItemModel itemModel, 
            PopItemMainView popItemMainView, ScoreModel scoreModel)
        {
            _popItemsData = popItemsData;
            _spawner = spawner;
            _itemModel = itemModel;
            _popItemMainView = popItemMainView;
            _scoreModel = scoreModel;
        }

        public void Start()
        {
            StartGame();
            
            _popItemMainView.SubscribeToRestartButtonTap(StartGame);
            _scoreModel.GameOver += StopGame;
        }

        private async void StartGame()
        {
            _canSpawnPopItems = true;
            
            ToggleScreenVisualizers(false);

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
            StopGame();
            _positionByCamera.ResetToDefault();
            _spawner.Dispose();
            _popItemMainView.UnSubscribeToRestartButtonTap(StartGame);
            _scoreModel.GameOver -= StopGame;
        }

        private void StopGame()
        {
            _canSpawnPopItems = false;
            
            ToggleScreenVisualizers(true);
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

        private void ToggleScreenVisualizers(bool toggleValue)
        {
            _popItemMainView.ToggleRestartButton(toggleValue);
            _popItemMainView.ToggleFadeObject(toggleValue);
        }
    }
}