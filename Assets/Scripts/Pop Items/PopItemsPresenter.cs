using System;

using VContainer.Unity;

namespace Pop_Items
{
    public class PopItemsPresenter : IStartable, IDisposable
    {
        private readonly ScoreModel _scoreModel;
        private readonly PopItemModel _popItemModel;
        private readonly PopItemsSpawner _popItemSpawner;

        public PopItemsPresenter(ScoreModel scoreModel, PopItemModel popItemModel, PopItemsSpawner spawner)
        {
            _scoreModel = scoreModel;
            _popItemModel = popItemModel;
            _popItemSpawner = spawner;
        }
        
        public void Start()
        {
            _popItemModel.CorrectAnswerTapped += _scoreModel.IncreaseScore;
            _popItemModel.Reset += _popItemSpawner.ReturnPopItem;

            _scoreModel.GameOver += _popItemSpawner.Dispose;
            _scoreModel.GameOver += _popItemModel.Dispose;
        }

        public void Dispose()
        {
            _popItemModel.CorrectAnswerTapped -= _scoreModel.IncreaseScore;;
            _popItemModel.Reset -= _popItemSpawner.ReturnPopItem;
            
            _scoreModel.GameOver -= _popItemSpawner.Dispose;
            _scoreModel.GameOver -= _popItemModel.Dispose;
        }
    }
}