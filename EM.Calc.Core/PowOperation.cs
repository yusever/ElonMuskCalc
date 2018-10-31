using System;
using System.Linq;

namespace EM.Calc.Core

{
    public class PowOperation : IOperation
    {
        public string Name => "pow";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public double? Execute()
        {
            Result = Operands[0];
            for (int i = 1; i < Operands.Length; i++)
            {
                Result = Math.Pow(Result.Value, Operands[i]);
            }
            return Result;
        }
    }
}
