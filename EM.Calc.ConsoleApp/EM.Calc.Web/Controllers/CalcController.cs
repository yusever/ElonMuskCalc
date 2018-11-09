using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using EM.Calc.Web.Models;

namespace EM.Calc.Web.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {
        private Core.Calc calc;

        EM.Calc.DB.IOperationResultRepository OperationResultRepository;
        EM.Calc.DB.IUserRepository UserRepository;
        EM.Calc.DB.IOperationRepository OperationRepository;

        public CalcController()
        {
            OperationResultRepository = new EM.Calc.DB.NHOperationResultRepository();
            OperationRepository = new EM.Calc.DB.NHOperationRepository();
            UserRepository = new EM.Calc.DB.NHUserRepository();
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
                return PartialView(model);
            }

            if (!calc.Operations.Any(m => m.Name == model.Name))
            {
                ModelState.AddModelError("", "Такой операции нет");
                return PartialView(model);
            }

            var result = Calc(model.Name, model.Args1);

            return PartialView("Execute", result);
        }

        private OperationResult Calc(string oper, double[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = calc.Execute(oper, args);
            stopWatch.Stop();

            var operation = OperationRepository.LoadByName(oper);

            var user = UserRepository.LoadByName(User.Identity.Name);

            OperationResultRepository.Save(new EM.Calc.DB.OperationResult()
            {
                ExecTime = stopWatch.ElapsedMilliseconds,
                User = user,
                Operation = operation,
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