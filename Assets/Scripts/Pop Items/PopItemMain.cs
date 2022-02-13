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
        
        private PopItemTapProxy _tapProxy;

        public void SetObjectCorrect(Sprite correctObjectSprite)
        {
            _visualizationRenderer.sprite = correctObjectSprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //Correct tap detected if only tap proxy not null
            _tapProxy?.CorrectTapDetected();
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

        /// <summary>
        /// If TapProxy initialized in this component then it's correct object
        /// </summary>
        /// <param name="tapProxy"></param>
        public void InitializeTapProxy(PopItemTapProxy tapProxy)
        {
            _tapProxy = tapProxy;
        }

        public void ResetPopItem()
        {
            _tapProxy = null;
        }
    }
}