namespace UthTrip.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RightDTO
    {
        public int Rights_ID { get; set; }

        public int User_ID { get; set; }

        public int Role_ID { get; set; }

        public int Trip_ID { get; set; }

        public RightDTO()
        {
        }

        public RightDTO(int rights_ID, int user_ID, int role_ID, int trip_ID)
        {
            this.Rights_ID = rights_ID;
            this.User_ID = user_ID;
            this.Role_ID = role_ID;
            this.Trip_ID = trip_ID;
        }
    }
}
