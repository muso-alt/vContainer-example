using System;

namespace Pop_Items
{
    public class PopItemTapProxy
    {
        public event Action OnTapped;

        public void CorrectTapDetected()
        {
            OnTapped?.Invoke();
        }
    }
}