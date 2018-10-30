using System;
using System.Linq;

namespace EM.Calc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Введите строку для выполнения, например: sum 2 2 2...");
            string text = Console.ReadLine();
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[words.Length - 1];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Convert.ToInt32(words[i + 1]);
            }*/

            string[] operations = new[] { "sum", "sub", "pow", "new" };

            string operation, operands;
            double[] values;

            var calc = new Core.Calc();

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
          
            switch (operation)
            {
                /*case ("sum"):
                    Console.WriteLine("sum = " + calc.Sum(values));
                    break;
                case ("sub"):
                    Console.WriteLine("sub = " + calc.Sub(values));
                    break;
                case ("pow"):
                    Console.WriteLine("pow = " + calc.Pow(values));
                    break;*/
                case ("new"):
                    Console.WriteLine(calc.New(values));
                    break;
            }
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
