using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uthTrip.BLL.DTO
{
    public class UserDTO
    {
        public int User_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Photo_Url { get; set; }
        public string Info { get; set; }
        public UserDTO()
        {

        }
        public UserDTO(int user_ID, string first_Name, string last_Name, string email, string username, string password, DateTime birthday, string photo_Url, string info)
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
        }
    }
}
