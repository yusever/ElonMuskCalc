using System;
using System.Linq;

namespace EM.Calc.Core

{
    public class SumOperation : IExtOperation
    {
        public string Name => "sum";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public Guid Uid => new Guid("{886CBDBD-FB57-434E-BC1F-8A0EE3BC558A}");

        public string Description => "Суммирует";

        public int? ArgCount => 2;

        public double? Execute()
        {
            Result = Operands.Sum();
            return Result;
        }
    }
}
