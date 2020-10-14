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
                LastName = "Howard",
                Id = Guid.NewGuid().ToString(),
                UserColour = "#C1EDCC"
            },
            new User()
            {
                FirstName = "Alex",
                LastName = "Rozsa",
                Id = Guid.NewGuid().ToString(),
                UserColour = "#B0C0BC"
            },
            new User()
            {
                FirstName = "Peter",
                LastName = "Nguyen",
                Id = Guid.NewGuid().ToString(),
                UserColour = "#A7A7A9"
            },
            new User()
            {
                FirstName = "Noah",
                LastName = "Hartigan",
                Id = Guid.NewGuid().ToString(),
                UserColour = "#C1EDCC"
            }
        };
    }
}