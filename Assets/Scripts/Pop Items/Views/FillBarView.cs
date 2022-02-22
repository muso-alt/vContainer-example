using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Pop_Items
{
    public class FillBarView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private UnityEvent _gameCompleted;
        
        public float SliderValue => _slider.value;
        public float SliderMaxValue => _slider.maxValue;
        
        public void IncreaseSlider()
        {
            _slider.value++;
        }
        
        private void ResetToDefault()
        {
            _slider.value = 0;
        }

        public void GameCompleted()
        {
            ResetToDefault();
            _gameCompleted?.Invoke();
        }
    }
}