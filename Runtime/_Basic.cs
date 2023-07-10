using UnityEngine;

namespace VHon
{
    public static class _Basic
    {
        // ------------------------------------------------------------------------------------------------------------------------------        
        public static MonoBehaviour GetMono(GameObject obj)
        {
            MonoBehaviour mono = obj.GetComponent<MonoBehaviour>();
            if (mono == null)
            {
                GameObject parentObj = obj.transform.parent.gameObject;
                if (parentObj == null) Debug.Log($"VTools: No monobehaviour found!");
                else mono = GetMono(parentObj);
            }            
            return mono;
        }
        // ------------------------------------------------------------------------------------------------------------------------------        
    }
}