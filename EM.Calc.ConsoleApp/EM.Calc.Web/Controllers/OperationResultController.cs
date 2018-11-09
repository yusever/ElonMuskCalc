using System.Web.Mvc;
using EM.Calc.DB;

namespace EM.Calc.Web.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class OperationResultController : Controller
    {
        IOperationResultRepository OperationResultRepository;

        public OperationResultController()
        {
            OperationResultRepository = new NHOperationResultRepository();
        }

        // GET: OperationResult
        public ActionResult Index()
        {
            var all = OperationResultRepository.GetAll();

            return View(all);
        }
    }
}