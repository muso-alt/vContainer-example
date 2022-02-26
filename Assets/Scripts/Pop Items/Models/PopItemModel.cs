using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Pop_Items
{
    public class PopItemModel
    {
        private const string FinishTag = "Finish";

        private List<PopItemView> _subscribedCorrectItems = new List<PopItemView>();
        
        public Action<GameObject> Reset;
        public Action CorrectAnswerTapped;
        
        public void Triggered(PopItemView itemView)
        {
            var collider = itemView.GetComponent<Collider2D>();
            
            Assert.IsNotNull(collider, "collider != null");

            if (collider.CompareTag(FinishTag))
            {
                ResetPopItem(itemView);
            }
        }

        public void AddPopItem(PopItemView itemView)
        {
            if (!_subscribedCorrectItems.Contains(itemView))
            {
                _subscribedCorrectItems.Add(itemView);
            }
        }

        private void RemovePopItem(PopItemView itemView)
        {
            if (_subscribedCorrectItems.Contains(itemView))
            {
                _subscribedCorrectItems.Remove(itemView);
            }
        }

        public void Dispose()
        {
            _subscribedCorrectItems.Clear();
        }
        
        public void CheckClickedPopItem(PopItemView itemView)
        {
            if (_subscribedCorrectItems.Contains(itemView))
            {
                CorrectAnswerTapped?.Invoke();
            }
            
            ResetPopItem(itemView);
        }

        private void ResetPopItem(PopItemView itemView)
        {
            itemView.ResetPopItem();
            Reset?.Invoke(itemView.gameObject);
            RemovePopItem(itemView);
        }
    }
}