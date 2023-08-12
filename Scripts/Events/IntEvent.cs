using UnityEngine;
using System.Collections.Generic;

namespace VHon
{
    [CreateAssetMenu(menuName = "VHonEvents/IntEvent", fileName = "IntEvent", order = 1)]
    public class IntEvent : ScriptableObject
    {
        List<IntEventListener> listeners = new();

        // ------------------------------------------------------------------------------------------------------------------------             
        public void Raise(int value)
        {
            for (var i = listeners.Count - 1; i >= 0; i--) listeners[i].OnEventRaised(value);
        }

        // ------------------------------------------------------------------------------------------------------------------------             
        public void AddListener(IntEventListener listener)
        {
            if (!listeners.Contains(listener)) listeners.Add(listener);
        }

        // ------------------------------------------------------------------------------------------------------------------------             
        public void RemoveListener(IntEventListener listener)
        {
            if (listeners.Contains(listener)) listeners.Remove(listener);
        }
        // ------------------------------------------------------------------------------------------------------------------------             
    }
}