using System;
using System.Linq;

namespace EM.Calc.Core

{
    public class SubOperation : IExtOperation
    {
        public string Name => "sub";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public Guid Uid => new Guid("{83B60C76-4E36-4307-9C23-7CEABF7C9A08}");

        public string Description => "Вычитает";

        public int? ArgCount => 2;

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
