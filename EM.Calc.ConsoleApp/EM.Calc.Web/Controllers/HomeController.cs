using System.Web.Mvc;
using EM.Calc.DB;

namespace EM.Calc.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IUserRepository UserRepository;

        public HomeController()
        {
            UserRepository = new NHUserRepository();
        }

        public ActionResult Index()
        {
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