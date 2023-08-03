using UnityEngine;
using System.Collections.Generic;

namespace VHon
{
    public static class Timers
    {
        static readonly List<TimerData> allTimers = new();

        //===============================================================================================================================
        // this.TimerSet(10);
        // this.TimerSet(10, "TimerName");
        //===============================================================================================================================
        public static void TimerSet<T>(this T obj, float targetTime, string _ID = "default") where T : Component
        {
            string ID = obj.gameObject.GetInstanceID() + "_" + _ID;

            TimerData timer = new(ID, targetTime);
            
            TimerData existingTimer = null;
            foreach (TimerData tmr in allTimers) if (tmr.ID == ID) existingTimer = tmr;

            if (existingTimer == null) allTimers.Add(timer);
        }

        //===============================================================================================================================
        // this.TimerUp();
        // this.TimerUp("TimerName");
        //===============================================================================================================================
        public static bool TimerUp<T>(this T obj, string _ID = "default") where T : Component
        {
            string ID = obj.gameObject.GetInstanceID() + "_" + _ID;

            TimerData timer = null;
            foreach (TimerData tmr in allTimers) if (tmr.ID == ID) timer = tmr;

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
    class TimerData
    {    
        public string ID;
        public float time;
        public float targetTime;

        public TimerData(string _ID, float _targetTime)
        {
            ID = _ID;
            targetTime = _targetTime;
        }
    }
    // -----------------------------------------------------------------------------------------------------------------------------------
}