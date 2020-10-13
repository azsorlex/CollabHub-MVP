using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CollabHub.Models.GlobalUtilities
{
    public static class StoppableTimer
    {
        private static bool repeat;
        public static object[] timerInfo;

        public static void Start(TimeSpan timespan, Action callback)
        {
            if (repeat)
                throw new Exception("A stoppable timer is already running. Stop that one before attempting to run a new one.");
            timerInfo = new object[2];
            timerInfo[0] = timespan;
            timerInfo[1] = callback;
            repeat = true;
            callback.Invoke(); // Run the command once on startup
            Device.StartTimer(timespan, () =>
            {
                if (repeat)
                    callback.Invoke();
                return repeat;
            });
        }

        public static void Stop(bool delete)
        {
            repeat = false;
            if (delete)
                timerInfo = null;
        }
    }
}
