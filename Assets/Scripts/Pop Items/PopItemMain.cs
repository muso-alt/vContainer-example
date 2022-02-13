using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Pop_Items
{
    public class PopItemMain : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SpriteRenderer _visualizationRenderer;
        [SerializeField] private UnityEvent _onTapped;
        [SerializeField] private UnityEvent _onResetted;
        
        public event Action<GameObject> OnResetted;
        public event Action Tapped;

        public void SetObjectCorrect(Sprite correctObjectSprite)
        {
            _visualizationRenderer.sprite = correctObjectSprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Tapped?.Invoke();
            _onTapped?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Finish"))
            {
                return;
            }
            
            _onResetted?.Invoke();
            OnResetted?.Invoke(gameObject);
        }
    }
}