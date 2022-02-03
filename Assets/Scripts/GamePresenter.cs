using System;
using VContainer.Unity;

namespace DefaultNamespace
{
    public class GamePresenter : IStartable, IDisposable
    {
        private readonly HelloView _view;
        private readonly PointSpawner _pointSpawner;
        private readonly ScoreChanger _scoreChanger;
        private readonly TapModel _tapModel;

        public GamePresenter(HelloView view, PointSpawner pointSpawner, TapModel tapModel, ScoreChanger scoreChanger)
        {
            _view = view;
            _pointSpawner = pointSpawner;
            _tapModel = tapModel;
            _scoreChanger = scoreChanger;
        }

        public void Start()
        {
            _view.OnStarted += _pointSpawner.Debugger;
            
            _view.SpawnObjects += _pointSpawner.SpawnObject;

            _tapModel.Tapped += _scoreChanger.IncrementScore;
        }

        public void Dispose()
        {
            _view.OnStarted -= _pointSpawner.Debugger;
            
            _view.SpawnObjects -= _pointSpawner.SpawnObject;
            
            _tapModel.Tapped -= _scoreChanger.IncrementScore;
        }
    }
}