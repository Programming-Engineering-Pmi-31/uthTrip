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
        public ActionResult Index(string City)
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
            return View(viewModels.Where(x => x.City == City));
        }
        public HomeController(ITripService iserv)
        {
            tripService = iserv;
        }
        public ActionResult StartPage()
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
            return View(viewModels);
        }
        public ActionResult HomeA()
        {

            return View("Login");
        }


        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}