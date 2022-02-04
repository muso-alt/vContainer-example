using System;
using VContainer.Unity;

namespace DefaultNamespace
{
    public class GamePresenter : IStartable, IDisposable
    {
        private readonly HelloView _view;
        private readonly PopItemSpawner _popItemSpawner;
        private readonly ScoreChanger _scoreChanger;
        private readonly TapModel _tapModel;

        public GamePresenter(HelloView view, PopItemSpawner popItemSpawner, TapModel tapModel, ScoreChanger scoreChanger)
        {
            _view = view;
            _popItemSpawner = popItemSpawner;
            _tapModel = tapModel;
            _scoreChanger = scoreChanger;
        }

        public void Start()
        {
            _view.SpawnObjects += _popItemSpawner.SpawnObject;

            _tapModel.Tapped += _scoreChanger.IncrementScore;
        }

        public void Dispose()
        {
            _view.SpawnObjects -= _popItemSpawner.SpawnObject;
            
            _tapModel.Tapped -= _scoreChanger.IncrementScore;
        }
    }
}