using System;

namespace Pop_Items
{
    public class ScoreModel
    {
        private readonly FillBarView _fillBarView;

        public event Action OnScoreReached;
        
        public ScoreModel(FillBarView fillBarView)
        {
            _fillBarView = fillBarView;
        }

        public void IncreaseScore()
        {
            if (_fillBarView.SliderMaxValue <= _fillBarView.SliderValue)
            {
                ScoreReached();
                return;
            }
            
            _fillBarView.IncreaseSlider();
        }

        private void ScoreReached()
        {
            OnScoreReached?.Invoke();
            _fillBarView.GameCompleted();
        }
    }
}