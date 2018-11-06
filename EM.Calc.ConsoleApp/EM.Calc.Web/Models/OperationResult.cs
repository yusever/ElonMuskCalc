using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EM.Calc.Web.Models
{
    public class OperationResult
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Результат
        /// </summary>
        public double? Result { get; set; }
    }
}