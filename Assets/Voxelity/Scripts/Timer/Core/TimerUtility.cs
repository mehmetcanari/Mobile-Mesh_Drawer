using System.Collections.Generic;
using UnityEngine;
using Voxelity.Extensions;

namespace Voxelity.Timer
{
    public static class TimerUtility
    {
        private static List<Timer> timers = new List<Timer>();
        public static Timer CreateTimer(float duration, HideFlags hideFlags = HideFlags.NotEditable)
        {
            GameObject timerCreated = new GameObject("Timer");

            timerCreated.hideFlags = HideFlags.NotEditable;

            Timer timer = timerCreated.AddComponent<Timer>();

            timer.SetTime(duration);

            return timer;
        }
        public static void SetActive(this GameObject obj,bool isActive,float time)
        {
            var timer = CreateTimer(time).SetAutoDestroy(true).OnComplete(()=>obj.SetActive(isActive));
        }
        public static void Assign(Timer timer)
        {
            timers.Add(timer);
        }
        public static void Remove(Timer timer)
        {
            timers.Remove(timer);
        }
        public static Timer[] GetAllTimers()
        {
            return timers.ToArray();
        }

        public static Timer GetTimerWithName(string name)
        {
            foreach (var timer in GetAllTimers())
            {
                if (timer.name == name)
                    return timer;
            }
            return null;
        }
        public static Timer[] GetTimersWithName(string name)
        {
            List<Timer> timersWithSameName = new List<Timer>();
            foreach (var timer in GetAllTimers())
            {
                if (timer.name == name)
                    timersWithSameName.Add(timer);
            }
            return timersWithSameName.ToArray();
        }

        public static void KillAllTimers()
        {
            GetAllTimers().ForEach(timer => timer.KillTimer());
            timers.Clear();
        }
    }
}