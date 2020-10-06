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
                SemesterTrack = "Semester 2 2020 (Current)"
            },
            new SemesterInfo()
            {
                SemesterTrack = "Semester 1 2020"
            },
            new SemesterInfo()
            {
                SemesterTrack = "Previous Semesters"
            }
        };
    }
}
