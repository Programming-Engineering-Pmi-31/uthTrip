using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace uthTripProject.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult HelloPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HelloPageAction(int a)
        {
            return RedirectToAction("Login");
        }
    }
}



//namespace uthTripProject.Controllers
//{
//    public class HelloController : Controller
//    {


//        public HelloController()
//        {


//        }

//        public ActionResult Index()
//        {
//            return View();
//        }

//        [HttpGet]
//        public ActionResult Hello()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Hello(TripViewModel tripModel)
//        {
//            return RedirectToAction("Login");
//        }

//    }
//}