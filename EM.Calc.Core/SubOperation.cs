using System.Linq;

namespace EM.Calc.Core

{
    public class SubOperation : IOperation
    {
        public string Name => "sub";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public double? Execute()
        {
            Result = Operands[0];
            for (int i = 1; i < Operands.Length; i++)
            {
                Result = Result - Operands[i];
            }
            return Result;
        }
    }
}
