using System.Collections;
using UnityEngine;
using System;

namespace VHon
{
    public static class Delays
    {
        //===============================================================================================================================
        // this.Delay(2, Function);
        //===============================================================================================================================
        public static void Delay(this MonoBehaviour mono, float duration, Action callback)
        {
            mono.StartCoroutine(DelayRoutine(duration, callback));
        }
        // ------------------------------------------------------------------------------------------------------------------------------
        static IEnumerator DelayRoutine(float duration, Action callback)
        {
            yield return new WaitForSecondsRealtime(duration);
            if (callback != null) callback();
        }
        // ------------------------------------------------------------------------------------------------------------------------------        
    }
}