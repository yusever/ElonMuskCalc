using System.Linq;

namespace EM.Calc.Core

{
    public class SumOperation : IOperation
    {
        public string Name => "sum";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public double? Execute()
        {
            Result = Operands.Sum();
            return Result;
        }
    }
}
