namespace UthTrip.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BlockedUsersDTO
    {
        public BlockedUsersDTO()
        {

        }

        public BlockedUsersDTO(int blocked_ID, int? user_ID)
        {
            Blocked_ID = blocked_ID;
            User_ID = user_ID;
        }

        public BlockedUsersDTO(int? user_ID)
        {
            User_ID = user_ID;
        }

        public int Blocked_ID { get; set; }

        public int? User_ID { get; set; }
    }
}
