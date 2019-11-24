using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uthTripProject.Models;
using System.Data.Entity.Infrastructure;
using System.Reflection;
using AutoMapper;
using uthTrip.BLL.Interfaces;
using uthTrip.BLL.Services;
using uthTrip.BLL.DTO;
using uthTrip.BLL.Infrastructure;

namespace uthTripProject.Controllers
{
    public class HomeController : Controller
    {
        ITripService tripService;
        public HomeController(ITripService iserv)
        {
            tripService = iserv;
        }
        public ActionResult StartPage(string Country,string City, string maxPrice, string maxPeople)
        {
            IEnumerable<TripDTO> trips = tripService.GetAll();
            IEnumerable<DestinationDTO> destinations = tripService.GetAllDist();
            IEnumerable<DatesRangeDTO> dates = tripService.GetAllDateRanges();
            List<TripViewModel> tripViewModels_list = new List<TripViewModel>();
            foreach (var trip in trips)
            {
                foreach (var destination in destinations)
                {
                    if (trip.Destination_ID == destination.Destination_ID)
                    {
                        foreach (var date in dates)
                        {
                            if (trip.Destination_ID == destination.Destination_ID && trip.Date_ID == date.Date_ID )
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

            if (!String.IsNullOrEmpty(Country) && !String.IsNullOrEmpty(City))
            {
                viewModels = viewModels.Where(x => x.Country == Country && x.City==City);
            }
           else if (!String.IsNullOrEmpty(Country) )
            {
                viewModels = viewModels.Where(x => x.Country == Country);
            }
            else if (!String.IsNullOrEmpty(City))
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
            return View(viewModels);

        }
        //public ActionResult TripDetail()
        //{
        //    //if (id == null)
        //    //{
        //    //    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //TripDTO trip = tripService.GetById(id);

        //    //return View(trip);
        //    return View();
        //}
        public ActionResult HomeA()
        {

            return View("Login");
        }
    }
}