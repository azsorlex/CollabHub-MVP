using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Models;

namespace CollabHub.Services
{
    class SemesterDataStore
    {
        public List<SemesterInfo> SemesterInfos = new List<SemesterInfo>()
        {
            new SemesterInfo()
            {
                SemesterTrack = "Semester 2 2020 (Current)",
                FirstUnitCode = "IFB398",
                SecondUnitCode = "IAB330",
                ThirdUnitCode = "CAB303"
            },
            new SemesterInfo()
            {
                SemesterTrack = "Semester 1 2020",
                FirstUnitCode = "CAB203",
                SecondUnitCode= "CAB302",
                ThirdUnitCode = "IFB295"
            },
            new SemesterInfo()
            {
                SemesterTrack = "Previous Semesters",
                FirstUnitCode = "CAB201",
                SecondUnitCode = "CAB202",
                ThirdUnitCode = "CAB230",
                FourthUnitCode = "EGB100"
            }
        };
    }
}
