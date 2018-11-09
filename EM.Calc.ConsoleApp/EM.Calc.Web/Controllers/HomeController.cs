using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.Calc.DB;
using EM.Calc.Web.DB;

namespace EM.Calc.Web.Controllers
{
    public class HomeController : Controller
    {
        IEntityRepository<User> UserRepository;

        public HomeController()
        {
            UserRepository = new NHUserRepository();
        }

        public ActionResult Index()
        {
            ViewBag.Results = UserRepository.Load(1);
            return View();
        }

        public ActionResult About(long? id, string r)
        {
            ViewBag.Message = "Your application description page.";

            return View("Contact");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}