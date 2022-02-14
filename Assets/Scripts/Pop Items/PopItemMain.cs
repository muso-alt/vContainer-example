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
        
        private PopItemTapProxy _tapProxy;

        public void SetObjectCorrect(Sprite correctObjectSprite)
        {
            _visualizationRenderer.sprite = correctObjectSprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //Correct tap detected if only tap proxy not null
            _tapProxy?.CorrectTapDetected();

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

        /// <summary>
        /// If TapProxy initialized in this component then it's correct object
        /// </summary>
        /// <param name="tapProxy"></param>
        public void InitializeTapProxy(PopItemTapProxy tapProxy)
        {
            _tapProxy = tapProxy;
        }

        private void ResetPopItem()
        {
            OnResetted?.Invoke(gameObject);
            _tapProxy = null;
            _onResetted?.Invoke();
        }
    }
}