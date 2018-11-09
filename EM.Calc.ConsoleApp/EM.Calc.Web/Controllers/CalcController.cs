using System;
using System.Linq;
using System.Web.Mvc;
using EM.Calc.Web.Models;

namespace EM.Calc.Web.Controllers
{
    public class CalcController : Controller
    {
        private Core.Calc calc;
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Elma\ElonMuskCalc\EM.Calc.ConsoleApp\EM.Calc.Web\App_Data\ElonMusk.mdf;Integrated Security=True";

        EM.Calc.DB.OperationResultRepository OperationResultRepository;
        EM.Calc.DB.IOperationRepository OperationRepository;

        public CalcController()
        {
            OperationResultRepository = new EM.Calc.DB.OperationResultRepository(connString);
            OperationRepository = new EM.Calc.DB.OperationRepository(connString);
            calc = new Core.Calc(@"E:\temp");
        }

        // GET: Calc
        public ActionResult Execute(string oper, double[] args)
        {
            var model = Calc(oper, args);
            return View(model);
        }

        [HttpGet]
        public ActionResult Input()
        {
            var model = new InputModel
            {
                Operations = calc.Operations
            };
            return View(model);
        }

        [HttpPost]
        public PartialViewResult Input(InputModel model)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            if (!calc.Operations.Any(m => m.Name == model.Name))
            {
                ModelState.AddModelError("", "Такой операции нет");
                return null;
            }

            var result = Calc(model.Name, model.Args1);
            return PartialView("Execute", result);
        }

        private OperationResult Calc(string oper, double[] args)
        {
            var result = calc.Execute(oper, args);

            var operation = OperationRepository.LoadByName(oper);

            OperationResultRepository.Save(new EM.Calc.DB.OperationResult()
            {
                UserId = 1,
                ExecTime = new Random().Next(1, 1000),

                OperationId = operation.Id,
                CreationDate = DateTime.Now,
                Status = EM.Calc.DB.OperationResultStatus.DONE,
                Result = result ?? double.NaN,
                Args = string.Join(" ", args)
            });

            return new OperationResult()
            {
                Name = oper,
                Result = result
            };
        }
    }
}