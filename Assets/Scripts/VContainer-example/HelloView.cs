using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    public class HelloView : MonoBehaviour
    {
        public event Action OnStarted;
        public event Action<int> SpawnObjects;

        private void Start()
        {
            OnStarted?.Invoke();
        }

        [Button]
        private void Spawn(int count)
        {
            SpawnObjects?.Invoke(count);
        }
    }
}