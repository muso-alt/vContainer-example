using System;
using System.Collections.Generic;
using Pop_Items.Data;
using UnityEngine;

namespace Pop_Items
{
    public class PopItemModel
    {
        private readonly string _finishTag;

        private readonly List<PopItemView> _subscribedCorrectItems = new List<PopItemView>();
        public event Action<GameObject> Reset;
        public event Action CorrectAnswerTapped;

        public PopItemModel(PopItemsSpawnerData popItemData)
        {
            _finishTag = popItemData.FinishTag;
        }
        
        public void Triggered(Collider2D other, PopItemView itemView)
        {
            if (other.CompareTag(_finishTag))
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