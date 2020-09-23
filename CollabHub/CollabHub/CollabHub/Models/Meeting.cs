using System;

namespace CollabHub.Models
{
    public class Meeting
    {
        public string UnitCode { get; set; }

        public override string ToString()
        {
            return UnitCode;
        }
    }
}