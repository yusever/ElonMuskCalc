using System;
using System.Linq;

namespace EM.Calc.Core
{
    public class Calc
    {
        /// <summary>
        /// Операции
        /// </summary>
        public IOperation[] Operations { get; set; }

        public Calc()
        {
            Operations = new IOperation[]
                {
                    new SumOperation(),
                    new NewOperation()
                };
        }

        public double? Execute(string operName, double[] values)
        {
            foreach (var item in Operations)
            {
                if (item.Name == operName)
                {
                    item.Operands = values;
                    item.Execute();
                    return item.Result;
                }
            }
            return null;
        }

        //[Obsolete("Не используйте это, есть Execute")]
        public double Sum(double[] args)
        {
            return args.Sum();
        }

        public double Sub(double[] args)
        {
            double res = args[0] - args[1];
            for (int i = 2; i < args.Length; i++)
            {
                res = res - args[i];
            }
            return res;
        }

        public double Pow(double[] args)
        {
            double res = Math.Pow(args[0], args[1]);
            for (int i = 2; i < args.Length; i++)
            {
                res = Math.Pow(res, args[i]);
            }
            return res;
        }

        public double New(double[] args)
        {
            return Double.PositiveInfinity;
        }
    }
}
