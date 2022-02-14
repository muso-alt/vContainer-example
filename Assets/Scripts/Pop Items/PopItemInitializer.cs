using UnityEngine;

using Pop_Items.Data;
using Pop_Items.Interfaces;

namespace Pop_Items
{
    public class PopItemInitializer : IInitializer<PopItemMain>
    {
        private readonly PopItemTapProxy _tapProxy;
        private readonly PopItemsSpawnerData _popItemsData;
        
        private float _minX = float.MinValue;
        private float _maxX = float.MaxValue;
        private float _lastPosition = float.MaxValue;

        private const float StartVerticalPosition = -11f;
        private const float HundredForFrequency = 101f;

        public PopItemInitializer(PopItemTapProxy tapProxy, PopItemsSpawnerData popItemsData)
        {
            _tapProxy = tapProxy;
            _popItemsData = popItemsData;
        }

        public void InitInternalData()
        {
            var cameraBorders = new CameraBorders();
            var corners = cameraBorders.GetCameraRect();

            _minX = corners.LeftBottom.x + _popItemsData.LeftOffset;
            _maxX = corners.RightBottom.x + _popItemsData.RightOffset;
        }
        
        public void Initialize(PopItemMain popItem)
        {
            ConfigurePosition(popItem.transform);

            if (!CanCreateCorrectPopItem())
            {
                return;
            }
            
            popItem.SetObjectCorrect(_popItemsData.CorrectAnswerSprite);
            popItem.InitializeTapProxy(_tapProxy);
        }

        /// <summary>
        /// Get frequency bool type
        /// </summary>
        /// <returns></returns>
        private bool CanCreateCorrectPopItem()
        {
            var randomValue = Random.Range(0, HundredForFrequency);

            return randomValue <= _popItemsData.FrequencyOfCorrectObjects;
        }
        
        private void ConfigurePosition(Transform item)
        {
            item.position = new Vector3(GetNewPosition(), StartVerticalPosition);
        }

        public void Dispose()
        {
            _lastPosition = float.MaxValue;
            _minX = float.MinValue;
            _maxX = float.MaxValue;
        }

        private float GetNewPosition()
        {
            float newPosition;

            do
            {
                newPosition = Random.Range(_minX, _maxX);
            } 
            while (Mathf.Abs(_lastPosition - newPosition) < _popItemsData.ItemsOffset);

            _lastPosition = newPosition;
            
            return newPosition;
        }
    }
}