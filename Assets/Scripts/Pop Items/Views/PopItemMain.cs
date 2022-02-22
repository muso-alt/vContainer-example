using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Pop_Items
{
    public class PopItemMain : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SpriteRenderer _visualizationRenderer;
        [SerializeField] private UnityEvent _onResetted;
        
        public event Action<GameObject> OnResetted;
        public event Action OnTapped;

        public void SetSprite(Sprite correctObjectSprite)
        {
            _visualizationRenderer.sprite = correctObjectSprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnTapped?.Invoke();

            ResetPopItem();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Finish"))
            {
                return;
            }
            
            ResetPopItem();
        }

        private void ResetPopItem()
        {
            OnResetted?.Invoke(gameObject);
            _onResetted?.Invoke();
        }
    }
}