using System;
using UnityEngine;

namespace VHon
{
    public static class Singleton
    {
        //===============================================================================================================================
        // internal static T Instance;
        // void Awake() => Instance = this.TrySingleton(Instance);
        //===============================================================================================================================
        public static T TrySingleton<T>(this T obj, T Instance, Action callback = null) where T : MonoBehaviour
        {
            T newInstance = Instance;

            if (Instance == null)
            {
                newInstance = obj;
                UnityEngine.Object.DontDestroyOnLoad(obj.gameObject);
                callback?.Invoke();
            }
            else if (Instance != obj) UnityEngine.Object.Destroy(obj.gameObject);

            return newInstance;
        }
        // ------------------------------------------------------------------------------------------------------------------------------        
    }
}