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
                ResourceHeading1 = "Unit Information",
                ResourceHeading2 = "Learning Materials",
                ResourceHeading3 = "Assessment Task",
                FirstUnitCode = "IFB398",
                SecondUnitCode = "IAB330",
                ThirdUnitCode = "CAB303",
                SubjectCon = new List<String>(){"Week1", "Week2", "Week3"}
            },
            new SemesterInfo()
            {
                SemesterTrack = "Semester 1 2020",
                ResourceHeading1 = "Unit Information",
                ResourceHeading2 = "Learning Materials",
                ResourceHeading3 = "Assessment Task",
                FirstUnitCode = "CAB203",
                SecondUnitCode= "CAB302",
                ThirdUnitCode = "IFB295"
            },
            new SemesterInfo()
            {
                SemesterTrack = "Previous Semesters",
                ResourceHeading1 = "Unit Information",
                ResourceHeading2 = "Learning Materials",
                ResourceHeading3 = "Assessment Task",
                FirstUnitCode = "CAB201",
                SecondUnitCode = "CAB202",
                ThirdUnitCode = "CAB230",
                FourthUnitCode = "EGB100"
            }
        };
    }
}
