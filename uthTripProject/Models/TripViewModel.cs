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
        public TripViewModel()
        {

        }
        public TripViewModel(TripDTO trip, DestinationDTO destination, DatesRangeDTO datesRange)
        {
            Trip_ID = trip.Trip_ID;
            Trip_Title = trip.Trip_Title;
            Description = trip.Description;
            Price = trip.Price;
            Date_ID = trip.Date_ID;
            Number_Of_People = trip.Number_Of_People;
            Creator_ID = trip.Creator_ID;
            Start_date = datesRange.Start_date;
            End_date = datesRange.End_date;
            Destination_ID = trip.Destination_ID;
            Is_Abroad = destination.Is_Abroad;
            Country = destination.Country;
            City = destination.City;
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
