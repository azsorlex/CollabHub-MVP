using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Models;

namespace CollabHub.Services
{
    class SemesterDataStore
    {
        //Creating mock data used to populate the UnitPage
        public List<SemesterInfo> SemesterInfos = new List<SemesterInfo>()
        {
            //Mock data for current semester
            new SemesterInfo()
            {
                SemesterTrack = "Semester 2 2020 (Current)",
                UnitContentHeading = new List<string>(){"Unit Information", "Learning Materials", "Assessment Task"},
                UnitCode = new List<string>(){"IAB330", "IFB398", "CAB303"},
                Unit1UnitInfo = new List<String>(){"Getting Started", "Announcements", "Unit Details", "FAQ"},
                Unit1LearningMat = new List<String>(){"Weekly Schedule", "Week 1", "Week 2", "Week 3", "Week 4", "Week 5", "Week 6", "Week 7", "Week 8"},
                Unit1AssessmentT = new List<String>(){"Assignment 1", "Assignment 2", "Assignment 3", "My Grades"}
            },
            //Mock data for one semester before current 
            new SemesterInfo()
            {
                SemesterTrack = "Semester 1 2020",
                UnitContentHeading = new List<string>(){"Unit Information", "Learning Materials", "Assessment Task"},
                UnitCode = new List<string>(){"CAB203", "CAB302", "IFB295"},
                UnitGrade = new List<string>(){"- 84%", "- 79%", "- 93%"},
                Unit1UnitInfo = new List<String>(){"Announcements", "Getting Started", "Learner Support", "Contacts", "Tools"},
                Unit1LearningMat = new List<String>(){"Before Week 1", "Week 1", "Week 2", "Week 3", "Week 4", "Week 5", "Week 6", "Week 7", "Week 8"},
                Unit1AssessmentT = new List<String>(){"Assignment 1", "Assignment 2", "Assignment 3", "My Grades"}
            },
            //Mock data for all previous semesters
            new SemesterInfo()
            {
                SemesterTrack = "Previous Semesters",
                UnitContentHeading = new List<string>(){"Previous Semester Unit 1", "Previous Semester Unit 2", "Previous Semester Unit 3"},
                UnitCode = new List<string>(){"Semester 2 2019", "Semester 1 2019", "Semester 2 2018", "Semester 1 2018"},
                UnitGrade = new List<string>(){"- 3 Units", "- 3 Units", "- 3 Units"},

                Unit1UnitInfo = new List<String>(){"Announcements", "Unit Details", "Tutorials", "Assessment", "My Grades"},
                Unit1LearningMat = new List<String>(){"Announcements", "Unit Details", "Learning", "Assessment", "My Grades", "Tools", "Contact Us", "ePortfolio"},
                Unit1AssessmentT = new List<String>(){"Announcements", "Unit Details", "Learning", "Assessment"}
            }
        };
    }
}
