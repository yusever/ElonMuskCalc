using EM.Calc.DB;
using EM.Calc.Web.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Calc.Web.Controllers
{
    public class HomeController : Controller
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Elma\ElonMuskCalc\EM.Calc.ConsoleApp\EM.Calc.Web\App_Data\ElonMusk.mdf;Integrated Security=True";
        UserRepository UserRepository;

        public HomeController()
        {
            UserRepository = new UserRepository(connString);
        }

        public ActionResult Index()
        {
            ViewBag.Results = UserRepository.Load(1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}