using UnityEngine;

namespace VHon
{
    public static class Mono
    {
        // ------------------------------------------------------------------------------------------------------------------------------        
        public static MonoBehaviour Get(GameObject obj)
        {
            MonoBehaviour mono = obj.GetComponent<MonoBehaviour>();
            if (mono == null)
            {
                GameObject parentObj = obj.transform.parent.gameObject;
                if (parentObj == null) Debug.Log($"VTools: No monobehaviour found!");
                else mono = Get(parentObj);
            }            
            return mono;
        }
        // ------------------------------------------------------------------------------------------------------------------------------        
    }
}