using System;
using System.Threading.Tasks;
using Pop_Items.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Pop_Items
{
    public class PopItemsPresenter : IStartable, IDisposable
    {
        private readonly PopItemsSpawner _spawner;
        private readonly PopItemsView _mainView;
        private readonly IInitializer<PopItemMain> _initializer;

        private bool _canSpawnPopItems;
        
        public PopItemsPresenter(PopItemsSpawner spawner, PopItemsView mainView, IInitializer<PopItemMain> initializer)
        {
            _spawner = spawner;
            _mainView = mainView;
            _initializer = initializer;
        }
        
        public void Start()
        {
            _canSpawnPopItems = true;
            _initializer.InitInternalData();
            _mainView.GameStarted += StartSpawn;
        }

        public void Dispose()
        {
            _mainView.GameStarted -= StartSpawn;
            _spawner.Dispose();
            _canSpawnPopItems = false;
        }

        private async void StartSpawn()
        {
            while (_canSpawnPopItems)
            {
                _spawner.SpawnObject(1);
                await Task.Delay(TimeSpan.FromSeconds(1f), default);
            }
        }
    }
}