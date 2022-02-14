using System;
using System.Threading.Tasks;

using VContainer.Unity;

using Pop_Items.Interfaces;

namespace Pop_Items
{
    public class PopItemsPresenter : IStartable, IDisposable
    {
        private readonly PopItemsSpawner _spawner;
        private readonly PopItemsView _mainView;
        private readonly IInitializer<PopItemMain> _initializer;
        private readonly ScoreModel _scoreModel;
        private readonly PopItemTapProxy _tapProxy;

        private bool _canSpawnPopItems;
        
        public PopItemsPresenter(PopItemsSpawner spawner, PopItemsView mainView, IInitializer<PopItemMain> initializer, ScoreModel scoreModel, PopItemTapProxy tapProxy)
        {
            _spawner = spawner;
            _mainView = mainView;
            _scoreModel = scoreModel;
            _initializer = initializer;
            _tapProxy = tapProxy;
        }
        
        public void Start()
        {
            _tapProxy.OnTapped += _scoreModel.IncreaseScore;
            _mainView.GameStarted += StartSpawn;
            _scoreModel.OnScoreReached += StopGame;
        }

        public void Dispose()
        {
            _spawner.Dispose();
            
            StopGame();
            
            _mainView.GameStarted -= StartSpawn;
            _tapProxy.OnTapped -= _scoreModel.IncreaseScore;
            _scoreModel.OnScoreReached -= StopGame;
        }

        private async void StartSpawn()
        {
            _canSpawnPopItems = true;
            _initializer.InitInternalData();
            
            while (_canSpawnPopItems)
            {
                _spawner.SpawnObject(1);
                await Task.Delay(TimeSpan.FromSeconds(_mainView.SpawnInterval), default);
            }
        }

        private void StopGame()
        {
            _canSpawnPopItems = false;
            _spawner.Dispose();
        }
    }
}