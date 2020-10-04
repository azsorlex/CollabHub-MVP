using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Views;
using CollabHub.Models;
using System.Linq;
using System.Diagnostics;

namespace CollabHub.ViewModels
{
    class VideoViewModel : BaseViewModel
    {
        public IList<Meeting> Meetings { get; set; }
        private List<string> UnitCodes;

        public VideoViewModel()
        {
            UnitCodes = new List<string>()
            {
                "IAB330",
                "CAB432",
                "CAB401",
                "IFB399",
                "IFB104"
            };
            List<string> BGColours = new List<string>()
            {
                "#C1EDCC",
                "#B0C0BC",
                "#A7A7A9"
            };
            Meetings = new List<Meeting>();

            long start = DateTime.Now.Ticks;
            for (int i = 0; i < UnitCodes.Count; i++)
            {
                Meetings.Add(new Meeting
                {
                    UnitCode = UnitCodes[i],
                    BGColour = BGColours[i % BGColours.Count],
                    Date = new DateTime(start + new TimeSpan(0, 0, i, 0).Ticks)
                });
            }
        }

        public void ReorderList()
        {
            Meetings = Meetings.OrderBy(m => m.Date).ToList(); // Rerder the list by Date
        }
    }
}
