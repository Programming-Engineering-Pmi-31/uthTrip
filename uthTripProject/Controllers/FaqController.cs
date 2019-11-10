//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;
//namespace uthTripProject.Controllers
//{
//    public class FaqController : Controller
//    {
//        private readonly IFaqRepository _repository;
//        public FaqController() : this(new FaqRepository()) { }
//        public FaqController(IFaqRepository repository)
//        {
//            _repository = repository;
//        }
//        public ActionResult Index()
//        {
//            var records = _repository.GetAll();
//            var model = new FaqViewModel
//            {
//                FAQs = records
//            };
//            return View(model);
//        }
//    }
//}
