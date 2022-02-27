using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Pop_Items
{
    public class PopItemMainView : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameObject _fade;

        public void ToggleRestartButton(bool value)
        {
            _restartButton.gameObject.SetActive(value);
        }
        
        public void ToggleFadeObject(bool value)
        {
            _fade.SetActive(value);
        }

        public void SubscribeToRestartButtonTap(UnityAction action)
        {
            _restartButton.onClick.AddListener(action);
        }
        
        public void UnSubscribeToRestartButtonTap(UnityAction action)
        {
            _restartButton.onClick.RemoveListener(action);
        }
    }
}