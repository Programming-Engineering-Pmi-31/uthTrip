﻿namespace UthTripProject.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Microsoft.AspNet.Identity.Owin;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Infrastructure;
    using UthTrip.BLL.Interfaces;
    using UthTrip.BLL.Services;
    using UthTripProject.Models;

    public class HomeController : Controller
    {
        ITripService tripService;
        public HomeController(ITripService iserv)
        {
            this.tripService = iserv;
        }
        public ActionResult StartPage(string Country, string City, string maxPrice, string maxPeople)
        {
            IEnumerable<TripDTO> trips = this.tripService.GetAll();
            IEnumerable<DestinationDTO> destinations = this.tripService.GetAllDist();
            IEnumerable<DatesRangeDTO> dates = this.tripService.GetAllDateRanges();
            List<TripViewModel> tripViewModels_list = new List<TripViewModel>();
            foreach (var trip in trips)
            {
                foreach (var destination in destinations)
                {
                    if (trip.Destination_ID == destination.Destination_ID)
                    {
                        foreach (var date in dates)
                        {
                            if (trip.Destination_ID == destination.Destination_ID && trip.Date_ID == date.Date_ID)
                            {
                                tripViewModels_list.Add(new TripViewModel(trip, destination, date));
                                break;
                            }
                        }
                        break;
                    }
                }
            }

            IEnumerable<TripViewModel> viewModels = tripViewModels_list;

            var countries = new SelectList((from i in destinations
                                            orderby i.Country
                                            select i.Country).Distinct().ToList());
            ViewBag.Country = countries;

            var cities = new SelectList((from i in destinations
                                         orderby i.City
                                         select i.City).Distinct().ToList());
            ViewBag.City = cities;

            if (!string.IsNullOrEmpty(Country) && !string.IsNullOrEmpty(City))
            {
                viewModels = viewModels.Where(x => x.Country == Country && x.City == City);
            }
            else if (!string.IsNullOrEmpty(Country))
            {
                viewModels = viewModels.Where(x => x.Country == Country);
            }
            else if (!string.IsNullOrEmpty(City))
            {
                viewModels = viewModels.Where(x => x.City == City);
            }
            double price;
            if (double.TryParse(maxPrice, out price))
            {
                viewModels = viewModels.Where(x => x.Price <= price);
            }

            int persons;
            if (int.TryParse(maxPeople, out persons))
            {
                viewModels = viewModels.Where(x => x.Number_Of_People <= persons);
            }
            return this.View(viewModels);
        }
        public ActionResult HomeA()
        {
            return this.View("Login");
        }
    }
}