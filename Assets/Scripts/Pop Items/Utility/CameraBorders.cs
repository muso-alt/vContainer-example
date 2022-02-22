using UnityEngine;
using UnityEngine.Assertions;

namespace Pop_Items
{
    public class CameraBorders
    {
        private readonly CameraCorners _cameraRect;
        private readonly CameraCorners _safeAreaRect;

        public CameraBorders()
        {
            var mainCamera = Camera.main;

            Assert.IsNotNull(mainCamera, "Camera not found");

            var leftBottomCorner = mainCamera.ScreenToWorldPoint(Vector2.zero);
            var rightTopCorner = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            var leftTopCorner = new Vector2(leftBottomCorner.x, rightTopCorner.y);
            var rightBottomCorner = new Vector2(rightTopCorner.x, leftBottomCorner.y);

            _cameraRect = new CameraCorners
            {
                LeftBottom = leftBottomCorner,
                LeftTop = leftTopCorner,
                RightBottom = rightBottomCorner,
                RightTop = rightTopCorner
            };

            var safeArea = Screen.safeArea;
            
            leftBottomCorner = mainCamera.ScreenToWorldPoint(new Vector2(safeArea.xMin, safeArea.yMin));
            rightTopCorner = mainCamera.ScreenToWorldPoint(new Vector2(safeArea.xMax, safeArea.yMax));

            leftTopCorner = new Vector2(leftBottomCorner.x, rightTopCorner.y);
            rightBottomCorner = new Vector2(rightTopCorner.x, leftBottomCorner.y);

            _safeAreaRect = new CameraCorners
            {
                LeftBottom = leftBottomCorner,
                LeftTop = leftTopCorner,
                RightBottom = rightBottomCorner,
                RightTop = rightTopCorner
            };
        }

        public CameraCorners GetCameraRect()
        {
            return _cameraRect;
        }

        public CameraCorners GetSafeAreaRect()
        {
            return _safeAreaRect;
        }
    }
}