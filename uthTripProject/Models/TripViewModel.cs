using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using uthTrip.BLL.DTO;

namespace uthTripProject.Models
{
    public class TripViewModel
    {
        public TripViewModel(TripDTO trip, DestinationDTO destination, DatesRangeDTO datesRange)
        {
            Trip_ID = trip.Trip_ID;
            Trip_Title = trip_Title;
            Description = description;
            Price = price;
            Date_ID = date_ID;
            Start_date = start_date;
            End_date = end_date;
            Number_Of_People = number_Of_People;
            Destination_ID = destination_ID;
            Is_Abroad = is_Abroad;
            Country = country;
            City = city;
            Creator_ID = creator_ID;
        }

        public int Trip_ID { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Trip title must have at least 3 chars.")]
        [DisplayName("Trip title")]
        [Required(ErrorMessage = "This field is required.")]
        public string Trip_Title { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Description must have at least 3 chars.")]
        [DisplayName("Description")]
        [Required(ErrorMessage = "This field is required.")]
        public string Description { get; set; }
      
        public double Price { get; set; }
        
        public int Date_ID { get; set; }

        [DisplayName("Start date")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Start_date { get; set; }

        [DisplayName("End date")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> End_date { get; set; }

        [DisplayName("Number of people")]
        [Required(ErrorMessage = "This field is required.")]
        public int Number_Of_People { get; set; }

        [DisplayName("Destination ID")]
        [Required(ErrorMessage = "This field is required.")]
        public int Destination_ID { get; set; }

        [DisplayName("Is it Abroad ?")]
        [Required(ErrorMessage = "This field is required.")]
        public bool Is_Abroad { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Creator_ID { get; set; }

    }
}
