namespace UthTripProject.Controllers
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
    using PagedList.Mvc;
    using PagedList;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Infrastructure;
    using UthTrip.BLL.Interfaces;
    using UthTrip.BLL.Services;
    using UthTripProject.Models;

    public class HomeController : Controller
    {
        private ITripService tripService;

        public HomeController(ITripService iserv)
        {
            this.tripService = iserv;
        }

        public ActionResult StartPage(int? page, string Country, string City, string maxPrice, string maxPeople)
        {
            IEnumerable<TripDTO> trips = this.tripService.GetAll();
            IEnumerable<DestinationDTO> destinations = this.tripService.GetAllDist();
            IEnumerable<DatesRangeDTO> dates = this.tripService.GetAllDateRanges();

            List<TripViewModel> tripViewModels_list = (from trip in trips
                                                       from destination in destinations
                                                       from date in dates
                                                       where trip.Destination_ID == destination.Destination_ID
                                                       && trip.Date_ID == date.Date_ID
                                                       select new TripViewModel(trip, destination, date)).ToList();

            IEnumerable<TripViewModel> viewModels = tripViewModels_list;

            var countries = new SelectList((from i in destinations
                                            orderby i.Country
                                            select i.Country).Distinct().ToList());
            this.ViewBag.Country = countries;

            var cities = new SelectList((from i in destinations
                                         orderby i.City
                                         select i.City).Distinct().ToList());
            this.ViewBag.City = cities;

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

            int pageSize = 6;
            int pageNumber = page ?? 1;

            return this.View(viewModels.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult HomeA()
        {
            return this.View("Login");
        }

        public ActionResult MyTrips()
        {
            IEnumerable<TripDTO> trips = this.tripService.GetAll();
            IEnumerable<DestinationDTO> destinations = this.tripService.GetAllDist();
            IEnumerable<DatesRangeDTO> dates = this.tripService.GetAllDateRanges();
            IEnumerable<RightDTO> rights = this.tripService.GetAllRights();
            int user_id = int.Parse(this.Session["User_ID"].ToString());

            List<TripViewModel> tripViewModels_list = (from trip in trips
                                                       from destination in destinations
                                                       from date in dates
                                                       from right in rights
                                                       where trip.Destination_ID == destination.Destination_ID
                                                       && trip.Date_ID == date.Date_ID
                                                       && trip.Trip_ID == right.Trip_ID
                                                       && right.User_ID == user_id
                                                       && right.Role_ID == 1
                                                       select new TripViewModel(trip, destination, date)).ToList();

            IEnumerable<TripViewModel> viewModels = tripViewModels_list;

            return this.View(viewModels);
        }

        public ActionResult Created()
        {
            IEnumerable<TripDTO> trips = this.tripService.GetAll();
            IEnumerable<DestinationDTO> destinations = this.tripService.GetAllDist();
            IEnumerable<DatesRangeDTO> dates = this.tripService.GetAllDateRanges();
            int user_id = int.Parse(this.Session["User_ID"].ToString());

            List<TripViewModel> tripViewModels_list = (from trip in trips
                                                       from destination in destinations
                                                       from date in dates
                                                       where trip.Destination_ID == destination.Destination_ID
                                                       && trip.Date_ID == date.Date_ID
                                                       && trip.Creator_ID == user_id
                                                       select new TripViewModel(trip, destination, date)).ToList();

            IEnumerable<TripViewModel> viewModels = tripViewModels_list;

            return this.View(viewModels);
        }
    }
}