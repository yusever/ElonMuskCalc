using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.Core
{
    public class NewOperation : IExtOperation
    {
        public string Name => "new";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public Guid Uid => new Guid("{7E33DEEC-A655-47B6-B3B6-B8ABF3AA5A70}");

        public string Description => "Возвращает позитив";

        public int? ArgCount => 0;

        public double? Execute()
        {
            Result = double.PositiveInfinity;
            return Result;
        }
    }
}
