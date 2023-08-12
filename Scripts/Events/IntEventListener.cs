using UnityEngine;
using UnityEngine.Events;

namespace VHon
{
    public class IntEventListener : MonoBehaviour
    {
        public IntEvent Event; // Event to register with
        public UnityEvent<int> Response; // Response to invoke when Event is raised

        // ------------------------------------------------------------------------------------------------------------------------             
        void OnEnable() => Event.AddListener(this);
        void OnDisable() => Event.RemoveListener(this);

        public void OnEventRaised(int value) => Response.Invoke(value);
        // ------------------------------------------------------------------------------------------------------------------------             
    }
}