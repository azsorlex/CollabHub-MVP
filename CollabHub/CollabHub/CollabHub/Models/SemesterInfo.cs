using System;
using System.Collections.Generic;
using System.Text;

namespace CollabHub.Models
{
    public class SemesterInfo
    {
        public string FirstUnitCode { get; set; }

        public string SecondUnitCode { get; set; }

        public string ThirdUnitCode { get; set; }

        public string FourthUnitCode { get; set; }

        public string SemesterTrack { get; set; }

        public string ResourceHeading1 { get; set; }
        public string ResourceHeading2 { get; set; }
        public string ResourceHeading3 { get; set; }

        public List<String> Unit1UnitInfo { get; set; }
        public List<String> Unit1LearningMat {get; set;}
        public List<String> Unit1AssessmentT { get; set; }

    }
}
