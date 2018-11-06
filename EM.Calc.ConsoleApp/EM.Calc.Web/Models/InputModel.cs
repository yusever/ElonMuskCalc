using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EM.Calc.Core;

namespace EM.Calc.Web.Models
{
    public class InputModel
    {
        public InputModel()
        {
            Operations = new List<IOperation>();
        }

        [Display(Name = "Операция")]
        [Required(ErrorMessage = "Нам обязательно нужно знать операцию")]
        public string Name { get; set; }

        [Display(Name = "Параметры")]
        public double[] Args1 { get; set; }

        public IList<IOperation> Operations { get; set; }
    }
}