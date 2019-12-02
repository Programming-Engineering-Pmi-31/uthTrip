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
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Interfaces;
    using UthTrip.BLL.Services;
    using UthTripProject.Models;

    public class TripDetailController : Controller
    {
        private ITripService tripService;

        public TripDetailController(ITripService iserv)
        {
            this.tripService = iserv;
        }

        public ActionResult TripDetail(int? id)
        {
            ////if (id == null)
            ////{
            ////    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ////}
            IEnumerable<TripDTO> trips = this.tripService.GetAll();
            IEnumerable<DestinationDTO> destinations = this.tripService.GetAllDist();
            IEnumerable<DatesRangeDTO> dates = this.tripService.GetAllDateRanges();
            List<TripViewModel> tripViewModels_list = new List<TripViewModel>();
            foreach (var t in trips)
            {
                foreach (var destination in destinations)
                {
                    if (t.Destination_ID == destination.Destination_ID)
                    {
                        foreach (var date in dates)
                        {
                            if ( t.Date_ID == date.Date_ID)
                            {
                                tripViewModels_list.Add(new TripViewModel(t, destination, date));
                                break;
                            }
                        }


                        break;
                    }
                }
            }

            IEnumerable<TripViewModel> viewModels = tripViewModels_list;
            viewModels = viewModels.Where(x => x.Trip_ID == id);
            TripViewModel tripViewModel = viewModels.First();
            int PlacesWas= tripViewModel.Number_Of_People;
            int Subscriber=0;
            IEnumerable<RightDTO> rights = this.tripService.GetAllRights();
            foreach (var i in rights)
            {
                if (i.Trip_ID == id)
                {
                    Subscriber += 1;
                }

            }
            IEnumerable<UserDTO> users = this.tripService.GetAllUsers();
            Dictionary<int,string> peopleList = new Dictionary<int,string>();
            int FreePlaces = PlacesWas - Subscriber;
            foreach (var i in rights)
            {
                if (i.Trip_ID == id)
                {
                    foreach (var ii in users)
                    {
                        if(ii.User_ID==i.User_ID)
                        {
                            peopleList[ii.User_ID]=ii.First_Name;

                        }
                    }
                }
            }
            ViewBag.Subscribers_user= peopleList;
            ViewBag.freePlaces = FreePlaces;
            ////TripDTO trip = tripService.GetById(id);
            return this.View(tripViewModel);
        }

    }
}