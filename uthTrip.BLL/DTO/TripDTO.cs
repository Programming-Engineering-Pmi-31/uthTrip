using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UthTrip.BLL.DTO
{
    public class TripDTO
    {
        public int Trip_ID { get; set; }
        public string Trip_Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Date_ID { get; set; }
        public int Number_Of_People { get; set; }
        public int Destination_ID { get; set; }
        public int Creator_ID { get; set; }
        public TripDTO()
        {
                
        }
        public TripDTO(int trip_ID, string trip_Title, string description, double price, int date_ID, int number_Of_People, int destination_ID, int creator_ID)
        {
            this.Trip_ID = trip_ID;
            this.Trip_Title = trip_Title;
            this.Description = description;
            this.Price = price;
            this.Date_ID = date_ID;
            this.Number_Of_People = number_Of_People;
            this.Destination_ID = destination_ID;
            this.Creator_ID = creator_ID;
        }
    }
}
