using System;

namespace Pop_Items
{
    public class ScoreModel
    {
        private readonly FillBarView _fillBarView;

        public event Action GameOver;
        
        public ScoreModel(FillBarView fillBarView)
        {
            _fillBarView = fillBarView;
        }

        public void IncreaseScore()
        {
            if (_fillBarView.SliderMaxValue > _fillBarView.SliderValue)
            {
                _fillBarView.IncreaseSlider();
                return;
            }
            
            ScoreReached();
        }

        private void ScoreReached()
        {
            GameOver?.Invoke();
            _fillBarView.GameCompleted();
        }
    }
}