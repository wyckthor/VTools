using UnityEngine;

namespace VHon
{
    public static class Singleton
    {
        //===============================================================================================================================
        // internal static Singleton Instance;
        // void Awake() => Instance = this.TrySingleton();
        //===============================================================================================================================
        public static T TrySingleton<T>(this T instance) where T : MonoBehaviour
        {
            T newInstance = null;

            if (instance != null)
            {
                if (Object.FindObjectsOfType<T>().Length == 1)
                {
                    Object.DontDestroyOnLoad(instance.gameObject);
                    newInstance = instance;
                }
                else Object.Destroy(instance.gameObject);
            }
            return newInstance;
        }
        // ------------------------------------------------------------------------------------------------------------------------------        
    }
}