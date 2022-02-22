using System;

using VContainer.Unity;

namespace Pop_Items
{
    public class PopItemsPresenter : IStartable, IDisposable
    {
        private readonly ScoreModel _scoreModel;
        private readonly PopItemModel _popItemModel;

        public PopItemsPresenter(ScoreModel scoreModel, PopItemModel popItemModel)
        {
            _scoreModel = scoreModel;
            _popItemModel = popItemModel;
        }
        
        public void Start()
        {
            _popItemModel.OnTapped += _scoreModel.IncreaseScore;
        }

        public void Dispose()
        {
            _popItemModel.OnTapped -= _scoreModel.IncreaseScore;
        }
    }
}