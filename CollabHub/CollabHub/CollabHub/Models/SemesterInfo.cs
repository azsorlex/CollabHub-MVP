using System;
using System.Collections.Generic;
using System.Text;

namespace CollabHub.Models
{
    public class SemesterInfo
    {
        public string SemesterTrack { get; set; }
        public List<String> UnitContentHeading { get; set; }
        public List<String> UnitCode { get; set; }
        public List<String> Unit1UnitInfo { get; set; }
        public List<String> Unit1LearningMat {get; set;}
        public List<String> Unit1AssessmentT { get; set; }

    }
}
