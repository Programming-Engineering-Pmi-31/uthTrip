using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uthTripProject.Models;


namespace uthTripProject.Controllers
{
    public class TripController : Controller
    {
        //// GET: Trip
        //[HttpGet]
        //public ActionResult Create(int id=0)
        //{
        //    Trip tripModel = new Trip();
        //    return View(tripModel);
        //}
        //[HttpPost]

        //public ActionResult Create(Trip tripModel)
        //{
        //    using (DbModels dbModel = new DbModels())
        //    {
        //        if (dbModel.Trips.Any(x => x.Trip_Title == tripModel.Trip_Title))
        //        {
        //            ViewBag.DuplicateMessage = "This trip already exists.";
        //            return View("Create", tripModel);
        //        }
        //        try
        //        {
        //            tripModel.Trip_ID = dbModel.Trips.Max(x => x.Trip_ID) + 1;
        //            tripModel.Destination_ID = dbModel.Destinations.Max(x => x.Destination_ID) + 1;
        //            tripModel.Date_ID = dbModel.Dates_ranges.Max(x => x.Date_ID) + 1;
        //            tripModel.Creator_ID = 0;


        //        }
        //        catch (System.InvalidOperationException)
        //        {
        //            tripModel.Trip_ID = 0;
        //            tripModel.Destination_ID = 0;
        //            tripModel.Date_ID = 0;


        //        }
        //        dbModel.Destinations.Add(new Destination(tripModel.Destination_ID, tripModel.Is_Abroad,tripModel.Country, tripModel.City));
        //        dbModel.Dates_ranges.Add(new Dates_ranges(tripModel.Date_ID, tripModel.Start_date, tripModel.End_date));
        //        dbModel.Trips.Add(tripModel);
        //        dbModel.SaveChanges();
        //    }
        //    ModelState.Clear();
        //    ViewBag.SuccessMessage = "Successfull creation of trip.";
        //    return View("Create", new Trip());
        //}
    }
}