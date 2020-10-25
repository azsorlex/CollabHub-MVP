using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollabHub.Models
{
    public class Alert
    {
        [PrimaryKey]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Frequency { get; set; }
        public string Subject { get; set; }
        public bool Automatic { get; set; }
    }
}
