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
        private IList<Meeting> meetings;
        public IList<Meeting> Meetings
        {
            get
            {
                try
                {
                    if (meetings[0].TimeSpan.Minutes == -1)
                    {
                        meetings[0].Date = new DateTime(meetings[0].Date.Ticks + new TimeSpan(7, 0, 0, 0).Ticks); // Set the meeting to appear in one week time
                        meetings = meetings.OrderBy(m => m.Date).ToList();
                    }
                } catch (Exception e)
                {
                    Debug.WriteLine($"Exception caught and handled gracefully: {e}");
                }
                return meetings;
            }
            set
            {
                meetings = value;
            }
        }

        public VideoViewModel()
        {
            Meetings = new List<Meeting>();

            List<string>  UnitCodes = new List<string>()
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
    }
}
