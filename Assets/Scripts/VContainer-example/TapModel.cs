using System;

namespace DefaultNamespace
{
    public class TapModel
    {
        public event Action Tapped;

        public void PointTapped()
        {
            Tapped?.Invoke();
        }
    }
}