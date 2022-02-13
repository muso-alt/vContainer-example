using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Make_Way_Jump
{
    public class MainView : MonoBehaviour
    {
        public event Action OnStarted;

        [Button]
        public void StartGame()
        {
            OnStarted?.Invoke();
        }
    }
}