using System;
using UnityEngine;

namespace Pop_Items
{
    public class PopItemsView : MonoBehaviour
    {
        [SerializeField] private int _countOfSpawningItems;
        public int CountOfSpawningItems => _countOfSpawningItems;

        public event Action GameStarted;

        private void Start()
        {
            GameStarted?.Invoke();
        }
    }
}