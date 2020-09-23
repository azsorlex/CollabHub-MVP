using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Models;

namespace CollabHub.Services
{
    class UserDataStore
    {
        public List<User> Users = new List<User>()
        {
            new User()
            {
                FirstName = "Ryan",
                LastName = "Howard"
            },
            new User()
            {
                FirstName = "Alex",
                LastName = "Rozsa"
            },
            new User()
            {
                FirstName = "Peter",
                LastName = "Nguyen"
            },
            new User()
            {
                FirstName = "Noah",
                LastName = "Hartigan"
            }
        };
    }
}
