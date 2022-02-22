using System;

namespace Pop_Items
{
    public class PopItemModel
    {
        public event Action OnTapped;

        public void CorrectTapDetected()
        {
            OnTapped?.Invoke();
        }
    }
}