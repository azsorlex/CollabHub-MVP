using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollabHub.Models.Chat
{
    public class Message
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Text { get; set; }

        public string Timestamp { get; set; }

        public string From { get; set; }

        public string To { get; set; }
    }
}
