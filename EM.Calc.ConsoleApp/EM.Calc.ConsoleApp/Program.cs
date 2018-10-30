using System;
using System.Linq;

namespace EM.Calc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string operation, operands;
            double[] values;

            var calc = new Core.Calc();

            string[] operations = calc.Operations.Select(o => o.Name).ToArray();

            if (args.Length == 0)
            {
                Console.WriteLine("Список операций: ");

                foreach (var item in operations)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Введите операцию ");
                operation = Console.ReadLine();

                Console.WriteLine("Введите операнды: ");
                operands = Console.ReadLine();
                values = ConvertToDouble(operands.Split(new[] { " ", ";" }, StringSplitOptions.RemoveEmptyEntries));
            }

            else
            {
                operation = args[0].ToLower();
                values = ConvertToDouble(args, 1);

            }

            var result = calc.Execute(operation, values);

            Console.WriteLine(result);
            
            Console.ReadKey();
        }

        private static double[] ConvertToDouble(string[] args, int start = 0)
        {
            return args
                .ToList()
                .Skip(start)
                .Select(Convert.ToDouble)
                .ToArray();
        }
    }
}
