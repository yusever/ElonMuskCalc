using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EM.Calc.Core
{
    public class Calc
    {
        /// <summary>
        /// Операции
        /// </summary>
        public IList<IOperation> Operations { get; set; }

        public Calc()
        {
            string[] files = Directory.GetFiles(@"E:\Elma\ElonMuskCalc\EM.Calc.ConsoleApp\EM.Calc.ConsoleApp\bin\Debug", "*.dll");
            string[] dll_files = new string[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                dll_files[i] = Path.GetFileNameWithoutExtension(files[i]);
            }
            Operations = new List<IOperation>();
            for (int i = 0; i < dll_files.Length; i++)
            {
                var asm = Assembly.Load(dll_files[i]);
                var types = asm.GetTypes();

                //var needType = typeof(IOperation);

                //перебираем все классы в сборке
                foreach (var item in types)
                {
                    //если класс реализует заданный интерфейс
                    if (item.GetInterface("IOperation") != null)
                    {
                        //добавляем в операции экземпляр данного класса
                        var instance = Activator.CreateInstance(item);

                        var operation = instance as IOperation;

                        if (operation != null)
                        {
                            Operations.Add((IOperation)instance);
                        }
                    }
                }
            }

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

        #region Old Metods
        [Obsolete("Вместо этого следует использовать Execute()")]
        public double Sum(double[] args)
        {
            return args.Sum();
        }

        [Obsolete("Вместо этого следует использовать Execute()")]
        public double Sub(double[] args)
        {
            double res = args[0] - args[1];
            for (int i = 2; i < args.Length; i++)
            {
                res = res - args[i];
            }
            return res;
        }

        [Obsolete("Вместо этого следует использовать Execute()")]
        public double Pow(double[] args)
        {
            double res = Math.Pow(args[0], args[1]);
            for (int i = 2; i < args.Length; i++)
            {
                res = Math.Pow(res, args[i]);
            }
            return res;
        }

        [Obsolete("Вместо этого следует использовать Execute()")]
        public double New(double[] args)
        {
            return Double.PositiveInfinity;
        }
        #endregion
    }
}
