using System;
using System.Linq;

namespace EM.Calc.Core

{
    public class PowOperation : IExtOperation
    {
        public string Name => "pow";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public Guid Uid => new Guid("{9320D3A1-8504-477F-826D-5145B3BC8C79}");

        public string Description => "Возводит в степень";

        public int? ArgCount => 2;

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
