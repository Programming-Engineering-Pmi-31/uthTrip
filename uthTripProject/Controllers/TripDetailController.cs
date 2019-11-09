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
    public class TripDetailController : Controller
    {
        // GET: TripDetail
        ITripService tripService;
        public TripDetailController(ITripService iserv)
        {
            tripService = iserv;
        }
        public ActionResult TripDetail(int ? id)
        {
            ////if (id == null)
            ////{
            ////    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ////}
            IEnumerable < TripDTO > trips = tripService.GetAll();
            IEnumerable<DestinationDTO> destinations = tripService.GetAllDist();
            IEnumerable<DatesRangeDTO> dates = tripService.GetAllDateRanges();
            List<TripViewModel> tripViewModels_list = new List<TripViewModel>();
            foreach (var t in trips)
            {
                foreach (var destination in destinations)
                {
                    if (t.Destination_ID == destination.Destination_ID)
                    {
                        foreach (var date in dates)
                        {
                            if (t.Destination_ID == destination.Destination_ID && t.Date_ID == date.Date_ID)
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
            viewModels = viewModels.Where(x=>x.Trip_ID==id);
            TripViewModel tripViewModel = viewModels.First();
            //TripDTO trip = tripService.GetById(id);
            return View(tripViewModel);
        }
    }
}