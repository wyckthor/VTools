using UnityEngine;
using System.Collections.Generic;

namespace VHon
{
    public static class Timers
    {
        static List<Timer> timers = new List<Timer>();

        //===============================================================================================================================
        // this.SetTimer("TimerName", 10);
        //===============================================================================================================================
        public static void SetTimer<T>(this T obj, string _ID, float targetTime) where T : Component
        {
            string ID = obj.gameObject.GetInstanceID() + "_" + _ID;

            Timer timer = new Timer(ID, targetTime);
            Timer existingTimer = null;
            for (int i = 0; i < timers.Count; i++)
            {
                if (timers[i].ID == ID) existingTimer = timers[i];
            }

            if (existingTimer == null) timers.Add(timer);
        }

        //===============================================================================================================================
        // this.TimerUp("TimerName");
        //===============================================================================================================================
        public static bool TimerUp<T>(this T obj, string _ID) where T : Component
        {
            string ID = obj.gameObject.GetInstanceID() + "_" + _ID;

            Timer timer = null;
            foreach (var tmr in timers) if (tmr.ID == ID) timer = tmr;

            if (timer != null)
            {
                if (timer.time >= timer.targetTime) timer.time = 0;
                else timer.time += Time.deltaTime;
                
                return timer.time == 0;
            }
            else return false;
        }
        // ------------------------------------------------------------------------------------------------------------------------------        
    }

    //===================================================================================================================================
    class Timer
    {    
        public string ID;
        public float time;
        public float targetTime;

        public Timer(string _ID, float _targetTime)
        {
            ID = _ID;
            targetTime = _targetTime;
        }
    }
    // -----------------------------------------------------------------------------------------------------------------------------------
}