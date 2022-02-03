using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class Pointer : MonoBehaviour, IPointerClickHandler
    {
        public event Action Tapped;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Tapped?.Invoke();
        }
    }
}