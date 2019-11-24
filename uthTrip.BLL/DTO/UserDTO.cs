namespace UthTrip.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;
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
            this.User_ID = user_ID;
            this.First_Name = first_Name;
            this.Last_Name = last_Name;
            this.Email = email;
            this.Username = username;
            this.Password = password;
            this.Birthday = birthday;
            this.Photo_Url = photo_Url;
            this.Info = info;
        }
    }
}
