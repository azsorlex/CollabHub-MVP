using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CollabHub.Models
{
    public static class StoppableTimer
    {
        private static bool repeat;

        public static void Start(TimeSpan timespan, Action callback)
        {
            if (repeat)
                throw new Exception("A stoppable timer is already running. Stop that one before attempting to run a new one.");
            repeat = true;
            Device.StartTimer(timespan, () =>
            {
                if (repeat)
                    callback.Invoke();
                return repeat;
            });
        }

        public static void Stop()
        {
            repeat = false;
        }
    }
}
