namespace UthTripProject.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return this.View();
        }


        [HttpGet]
        public ActionResult HelloPage()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult HelloPageAction(int a)
        {
            return this.RedirectToAction("Login");
        }
    }
}