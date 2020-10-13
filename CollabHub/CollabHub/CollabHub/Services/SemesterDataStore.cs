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
                FirstUnitCode = "IAB330",
                SecondUnitCode = "IFB398",
                ThirdUnitCode = "CAB303",
                Unit1UnitInfo = new List<String>(){"Getting Started", "Announcements", "Unit Details", "FAQ"},
                Unit1LearningMat = new List<String>(){"Weekly Schedule", "Week 1", "Week 2", "Week 3", "Week 4", "Week 5", "Week 6", "Week 7", "Week 8"},
                Unit1AssessmentT = new List<String>(){"Assignment 1", "Assignment 2", "Assignment 3", "My Grades"}
            },
            new SemesterInfo()
            {
                SemesterTrack = "Semester 1 2020",
                ResourceHeading1 = "Unit Information",
                ResourceHeading2 = "Learning Materials",
                ResourceHeading3 = "Assessment Task",
                FirstUnitCode = "CAB203",
                SecondUnitCode= "CAB302",
                ThirdUnitCode = "IFB295",
                Unit1UnitInfo = new List<String>(){"Announcements", "Getting Started", "Learner Support", "Contacts", "Tools"},
                Unit1LearningMat = new List<String>(){"Before Week 1", "Week 1", "Week 2", "Week 3", "Week 4", "Week 5", "Week 6", "Week 7", "Week 8"}
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
