using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class PopItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private UnityEvent _onClicked;
        [SerializeField] private UnityEvent _onResetted;
        
        public event Action Tapped;
        public event Action<GameObject> Resetted;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Tapped?.Invoke();
            _onClicked?.Invoke();
        }

        public void ResetPopItem()
        {
            Resetted?.Invoke(gameObject);
            _onResetted?.Invoke();
        }
    }
}