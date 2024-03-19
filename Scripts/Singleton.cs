using UnityEngine;

namespace VHon
{
    public static class Singleton
    {
        //===============================================================================================================================
        // internal static T Instance;
        // void Awake() => Instance = this.TrySingleton(Instance);
        //===============================================================================================================================
        public static T TrySingleton<T>(this T obj, T Instance) where T : MonoBehaviour
        {
            T newInstance = Instance;

            if (Instance == null)
            {
                newInstance = obj;
                Object.DontDestroyOnLoad(obj.gameObject);
            }
            else if (Instance != obj) Object.Destroy(obj.gameObject);

            return newInstance;
        }
        // ------------------------------------------------------------------------------------------------------------------------------        
    }
}