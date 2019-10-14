using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uthTrip.BLL.DTO
{
    class DestinationDTO
    {
        public int Destination_ID { get; set; }
        public bool Is_Abroad { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
