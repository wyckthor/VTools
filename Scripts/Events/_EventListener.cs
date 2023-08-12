using UnityEngine;
using UnityEngine.Events;

namespace VHon
{
    public class _EventListener : MonoBehaviour
    {
        public _Event Event; // Event to register with
        public UnityEvent Response; // Response to invoke when Event is raised

        // ------------------------------------------------------------------------------------------------------------------------             
        void OnEnable() => Event.AddListener(this);
        void OnDisable() => Event.RemoveListener(this);

        public void OnEventRaised() => Response.Invoke();
        // ------------------------------------------------------------------------------------------------------------------------             
    }
}