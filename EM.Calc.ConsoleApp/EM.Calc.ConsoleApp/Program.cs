using System;
using System.Linq;

namespace EM.Calc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку для выполнения, например: sum 2 2 2...");
            string text = Console.ReadLine();
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[words.Length - 1];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Convert.ToInt32(words[i + 1]);
            }

            string operation = words[0];
            switch (operation)
            {
                case ("sum"):
                    Console.WriteLine("sum = " + Sum(numbers));
                    break;
                case ("sub"):
                    Console.WriteLine("sub = " + Sub(numbers));
                    break;
                case ("pow"):
                    Console.WriteLine("pow = " + Pow(numbers));
                    break;
            }
            Console.ReadKey();
        }

        public static int Sum(int[] args)
        {
            return args.Sum();
        }

        public static int Sub(int[] args)
        {
            int res = args[0] - args[1];
            for (int i = 2; i < args.Length; i++)
            {
                res = res - args[i];
            }
            return res;
        }

        public static int Pow(int[] args)
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
