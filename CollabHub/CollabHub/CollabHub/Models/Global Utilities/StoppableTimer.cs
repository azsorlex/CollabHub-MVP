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
