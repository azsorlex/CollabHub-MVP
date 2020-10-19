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

        // May implement this at a later stage for sorting messages between users.
        //public string Timestamp { get; set; }
    }
}
