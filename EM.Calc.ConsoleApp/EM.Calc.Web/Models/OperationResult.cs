using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EM.Calc.Web.Models
{
    public class OperationResult
    {
        public string Name { get; set; }

        public double? Result { get; set; }

        public string Error { get; set; }
    }
}