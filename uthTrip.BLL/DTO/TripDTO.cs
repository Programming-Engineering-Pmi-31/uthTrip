using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uthTrip.BLL.DTO
{
    class TripDTO
    {
        public int Trip_ID { get; set; }
        public string Trip_Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Date_ID { get; set; }
        public int Number_Of_People { get; set; }
        public int Destination_ID { get; set; }
        public int Creator_ID { get; set; }
    }
}
