using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ScoreChanger
    {
        private readonly Text _scoreText;

        private int _currentScore;
        
        public ScoreChanger(Text scoreText)
        {
            _scoreText = scoreText;

            UpdateTextComponent();
        }

        public void IncrementScore()
        {
            _currentScore++;
            UpdateTextComponent();
        }

        public void ResetScore()
        {
            _currentScore = 0;
            UpdateTextComponent();
        }

        private void UpdateTextComponent()
        {
            _scoreText.text = _currentScore.ToString();
        }
    }
}