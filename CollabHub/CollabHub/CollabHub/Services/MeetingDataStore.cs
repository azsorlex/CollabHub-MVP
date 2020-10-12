using CollabHub.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CollabHub.Services
{
    public static class MeetingDataStore
    {
        private static bool initialised;
        private static ObservableCollection<Meeting> _meetings = new ObservableCollection<Meeting>() // Data would be retrieved from a database of some sort
        {
            new Meeting() // Alex's sessions
            {
                UnitCode = "IAB330",
                Date = new DateTime(2020, 7, 29, 15, 0, 0), // Format: year, month, day, hour, minute, second
                EndDate = new DateTime(2020, 10, 21), // Precice time isn't necessary here
                Duration = new KeyValuePair<byte, byte>(2, 0)
            },
            new Meeting()
            {
                UnitCode = "CAB432",
                Date = new DateTime(2020, 7, 22, 11, 0, 0),
                EndDate = new DateTime(2020, 10, 21),
                Duration = new KeyValuePair<byte, byte>(2, 0)
            },

            new Meeting() // Ryan's sessions
            {
                UnitCode = "CAB240",
                Date = new DateTime(2020, 7, 20, 10, 30, 0),
                EndDate = new DateTime(2020, 10, 19),
                Duration = new KeyValuePair<byte, byte>(1, 30)
            },
            new Meeting()
            {
                UnitCode = "CAB303",
                Date = new DateTime(2020, 7, 22, 10, 0, 0),
                EndDate = new DateTime(2020, 10, 21),
                Duration = new KeyValuePair<byte, byte>(2, 0)
            },
            new Meeting()
            {
                UnitCode = "IAB206",
                Date = new DateTime(2020, 7, 22, 12, 30, 0),
                EndDate = new DateTime(2020, 10, 21),
                Duration = new KeyValuePair<byte, byte>(1, 30)
            },

            new Meeting() // Noah's sessions
            {
                UnitCode = "IFB295",
                Date = new DateTime(2020, 7, 28, 9, 0, 0),
                EndDate = new DateTime(2020, 10, 20),
                Duration = new KeyValuePair<byte, byte>(2, 0)
            },
            new Meeting()
            {
                UnitCode = "EGB339",
                Date = new DateTime(2020, 7, 29, 11, 0, 0),
                EndDate = new DateTime(2020, 10, 21),
                Duration = new KeyValuePair<byte, byte>(2, 0)
            },
            new Meeting()
            {
                UnitCode = "CAB303",
                Date = new DateTime(2020, 7, 23, 9, 0, 0),
                EndDate = new DateTime(2020, 10, 22),
                Duration = new KeyValuePair<byte, byte>(2, 0)
            },
            new Meeting()
            {
                UnitCode = "EGB339",
                Date = new DateTime(2020, 7, 30, 11, 0, 0),
                EndDate = new DateTime(2020, 10, 22),
                Duration = new KeyValuePair<byte, byte>(1, 0)
            },

            new Meeting() // Peter's sessions
            {
                UnitCode = "CAB303",
                Date = new DateTime(2020, 7, 23, 15, 0, 0),
                EndDate = new DateTime(2020, 10, 22),
                Duration = new KeyValuePair<byte, byte>(2, 0)
            }
        };
        public static ObservableCollection<Meeting> Meetings
        {
            get
            {
                if (!initialised)
                    Init();
                return _meetings;
            }
            set => _meetings = value;
        }

        private static void Init()
        {
            List<string> BGColours = new List<string>()
            {
                "#C1EDCC",
                "#B0C0BC",
                "#A7A7A9"
            };

            List<Meeting> temp = _meetings.OrderBy(m => m.Date).ToList();
            _meetings.Clear();
            for (int i = 0; i < temp.Count; i++)
            {
                temp[i].BGColour = BGColours[i % BGColours.Count];
                _meetings.Add(temp[i]);
            }
            initialised = true;
        }
    }
}