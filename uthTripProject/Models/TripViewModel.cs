﻿namespace UthTripProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using UthTrip.BLL.DTO;

    public class TripViewModel
    {
        public TripViewModel()
        {
        }

        public TripViewModel(TripDTO trip, DestinationDTO destination, DatesRangeDTO datesRange)
        {
            this.Trip_ID = trip.Trip_ID;
            this.Trip_Title = trip.Trip_Title;
            this.Description = trip.Description;
            this.Price = trip.Price;
            this.Date_ID = trip.Date_ID;
            this.Number_Of_People = trip.Number_Of_People;
            this.Creator_ID = trip.Creator_ID;
            this.Start_date = datesRange.Start_date;
            this.End_date = datesRange.End_date;
            this.Destination_ID = trip.Destination_ID;
            this.Is_Abroad = destination.Is_Abroad;
            this.Country = destination.Country;
            this.City = destination.City;
        }

        public int Trip_ID { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Trip title must have at least 3 chars.")]
        [DisplayName("Назва")]
        [Required(ErrorMessage = "This field is required.")]
        public string Trip_Title { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Description must have at least 3 chars.")]
        [DisplayName("Опис")]
        [Required(ErrorMessage = "This field is required.")]
        public string Description { get; set; }

        [DisplayName("Вартість")]
        public double Price { get; set; }

        public int Date_ID { get; set; }

        [DisplayName("Початкова дата")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Start_date { get; set; }

        [DisplayName("Кінцева дата")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> End_date { get; set; }

        [DisplayName("Кількість людей")]
        [Required(ErrorMessage = "This field is required.")]
        public int Number_Of_People { get; set; }

        [DisplayName("Destination ID")]
        [Required(ErrorMessage = "This field is required.")]
        public int Destination_ID { get; set; }

        [DisplayName("Це закордоном?")]
        [Required(ErrorMessage = "This field is required.")]
        public bool Is_Abroad { get; set; }

        [DisplayName("Країна")]
        public string Country { get; set; }

        [DisplayName("Місто")]
        public string City { get; set; }

        public int Creator_ID { get; set; }
    }
}
