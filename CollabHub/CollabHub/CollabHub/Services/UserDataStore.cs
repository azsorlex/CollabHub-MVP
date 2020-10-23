using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Models;

namespace CollabHub.Services
{
    class UserDataStore
    {
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                FirstName = "Ryan",
                LastName = "Howard",
                Id = "1",
                UserColour = "#C1EDCC"
            },
            new User()
            {
                FirstName = "Alex",
                LastName = "Rozsa",
                Id = "2",
                UserColour = "#B0C0BC"
            },
            new User()
            {
                FirstName = "Peter",
                LastName = "Nguyen",
                Id = "3",
                UserColour = "#A7A7A9"
            },
            new User()
            {
                FirstName = "Noah",
                LastName = "Hartigan",
                Id = "4",
                UserColour = "#C1EDCC"
            }
        };

        //  Gets populated with single user, which is Sri by default. Changes made in HomeViewModel
        public static User CurrentUser = new User
        {
            FirstName = "Sri",
            LastName = "Nair",
            Id = "5",
            UserColour = "#B0C0BC"
        };
    }
}