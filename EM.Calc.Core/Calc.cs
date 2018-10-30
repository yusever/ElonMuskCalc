using System;
using System.Linq;

namespace EM.Calc.Core
{
    public class Calc
    {
        public int Sum(int[] args)
        {
            return args.Sum();
        }

        public int Sub(int[] args)
        {
            int res = args[0] - args[1];
            for (int i = 2; i < args.Length; i++)
            {
                res = res - args[i];
            }
            return res;
        }

        public int Pow(int[] args)
        {
            int res = (int)Math.Pow(args[0], args[1]);
            for (int i = 2; i < args.Length; i++)
            {
                res = (int)Math.Pow(res, args[i]);
            }
            return res;
        }
    }
}
