using Xamarin.Forms;

namespace CollabHub.Models
{
    public class Meeting
    {
        public string UnitCode { get; set; }
        public string BGColour { get; set; }
        //public bool SomeCondition { get; set; }
        public Command TapCommand { get; set; }
    }
}