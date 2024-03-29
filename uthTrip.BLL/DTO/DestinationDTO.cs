﻿namespace UthTrip.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DestinationDTO
    {
        public DestinationDTO()
        {
        }

        public DestinationDTO(int destination_ID, bool is_Abroad, string country, string city)
        {
            this.Destination_ID = destination_ID;
            this.Is_Abroad = is_Abroad;
            this.Country = country;
            this.City = city;
        }

        public int Destination_ID { get; set; }

        public bool Is_Abroad { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
