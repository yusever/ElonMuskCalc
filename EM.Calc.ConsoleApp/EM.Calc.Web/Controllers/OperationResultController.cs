using EM.Calc.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Calc.Web.Controllers
{
    public class OperationResultController : Controller
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Elma\ElonMuskCalc\EM.Calc.ConsoleApp\EM.Calc.Web\App_Data\ElonMusk.mdf;Integrated Security=True";
        OperationResultRepository OperationResultRepository;

        public OperationResultController()
        {
            OperationResultRepository = new OperationResultRepository(connString);
        }

        public ActionResult IndexOperationResult()
        {
            ViewBag.Result = OperationResultRepository.Load(4);
            return View();
        }
    }
}