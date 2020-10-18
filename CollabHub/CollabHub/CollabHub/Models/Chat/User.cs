using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CollabHub.Models
{
    class User
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserColour { get; set; }
        public string Name { get { return $"{FirstName} {LastName}"; } }
        public string Greeting
        {
            get { return $"Hi! May name is {Name}. What's yours?"; }
        }

        public string Initials
        {
            get
            {
                string firstInitial = this.FirstName[0].ToString();
                string secondInitial = this.LastName[0].ToString();
                string initials = firstInitial += secondInitial;

                return initials.ToUpper();
            } 
        }

        public Xamarin.Forms.Command UserChatPage
        {
            get
            {
                return new Xamarin.Forms.Command(async () => { await Shell.Current.GoToAsync
                        ($"userChat?initials={Initials}&name={Name}&firstName={FirstName}&userColour={UserColour}"
                    ); });
            }
        }
    }
}
