using UnityEngine;

namespace Pop_Items
{
    public class PositionByCameraConfigurator
    {
        private float _minX = float.MinValue;
        private float _maxX = float.MaxValue;
        private float _lastPosition = float.MaxValue;

        private float _itemsOffset;

        public PositionByCameraConfigurator(float leftOffset, float rightOffset, float itemsOffset)
        {
            var cameraBorders = new CameraBorders();
            var corners = cameraBorders.GetCameraRect();

            _minX = corners.LeftBottom.x + leftOffset;
            _maxX = corners.RightBottom.x + rightOffset;

            _itemsOffset = itemsOffset;
        }

        public void ResetToDefault()
        {
            _lastPosition = float.MaxValue;
            _minX = float.MinValue;
            _maxX = float.MaxValue;
        }
        
        public float GetNewPosition()
        {
            float newPosition;

            do
            {
                newPosition = Random.Range(_minX, _maxX);
            } 
            while (Mathf.Abs(_lastPosition - newPosition) < _itemsOffset);

            _lastPosition = newPosition;
            
            return newPosition;
        }
    }
}