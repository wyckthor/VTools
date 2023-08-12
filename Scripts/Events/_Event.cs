using UnityEngine;
using System.Collections.Generic;

namespace VHon
{
    [CreateAssetMenu(menuName = "VHonEvents/_Event", fileName = "_Event", order = 0)]
    public class _Event : ScriptableObject
    {
        List<_EventListener> listeners = new();

        // ------------------------------------------------------------------------------------------------------------------------             
        public void Raise(int value)
        {
            for (var i = listeners.Count - 1; i >= 0; i--) listeners[i].OnEventRaised();
        }

        // ------------------------------------------------------------------------------------------------------------------------             
        public void AddListener(_EventListener listener)
        {
            if (!listeners.Contains(listener)) listeners.Add(listener);
        }

        // ------------------------------------------------------------------------------------------------------------------------             
        public void RemoveListener(_EventListener listener)
        {
            if (listeners.Contains(listener)) listeners.Remove(listener);
        }
        // ------------------------------------------------------------------------------------------------------------------------             
    }
}