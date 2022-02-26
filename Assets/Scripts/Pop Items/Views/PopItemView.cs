using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Pop_Items
{
    public class PopItemView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SpriteRenderer _visualizationRenderer;
        [SerializeField] private UnityEvent _onResetted;
        
        public event Action<PopItemView> Tapped;
        public event Action<PopItemView> Triggered;

        public void SetSprite(Sprite currentSprite)
        {
            _visualizationRenderer.sprite = currentSprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Tapped?.Invoke(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Triggered?.Invoke(this);
        }

        public void ResetPopItem()
        {
            _onResetted?.Invoke();
        }
    }
}