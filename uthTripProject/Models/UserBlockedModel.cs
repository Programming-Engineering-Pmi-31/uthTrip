namespace UthTripProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserBlockedModel
    {
        public UserBlockedModel()
        {

        }

        public UserBlockedModel(int user_ID, string first_Name, string last_Name, string email, string username, string password, DateTime birthday, string photo_Url, string info, bool isBlocked)
        {
            User_ID = user_ID;
            First_Name = first_Name;
            Last_Name = last_Name;
            Email = email;
            Username = username;
            Password = password;
            Birthday = birthday;
            Photo_Url = photo_Url;
            Info = info;
            this.isBlocked = isBlocked;
        }

        public int User_ID { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public System.DateTime Birthday { get; set; }

        public string Photo_Url { get; set; }

        public string Info { get; set; }

        public bool isBlocked { get; set; }
    }
}
