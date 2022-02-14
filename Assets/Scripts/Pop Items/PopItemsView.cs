using System;
using UnityEngine;

namespace Pop_Items
{
    public class PopItemsView : MonoBehaviour
    {
        [SerializeField] private int _countOfSpawningItems;
        [SerializeField] private float _spawnInterval = 1f;
        public int CountOfSpawningItems => _countOfSpawningItems;
        public float SpawnInterval => _spawnInterval;

        public event Action GameStarted;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            GameStarted?.Invoke();
        }
    }
}