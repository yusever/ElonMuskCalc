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

            public Calc() : this("")
            {
            }

            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="path">Путь до сторонних библиотек с операциями</param>
            public Calc(string path)
            {
                Operations = new List<IOperation>();

                if (string.IsNullOrWhiteSpace(path))
                {
                    path = Environment.CurrentDirectory;
                }
                else
                {
                LoadOperations(Assembly.GetExecutingAssembly());
                }

                var dllFiles = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);
                foreach (var file in dllFiles)
                {
                    LoadOperations(Assembly.LoadFrom(file));
                }
            }

            private void LoadOperations(Assembly assembly)
            {
                // загрузить все типы из сборки
                var types = assembly.GetTypes();

                var needType = typeof(IOperation);

                // перебираем все классы в сборке
                foreach (var item in types.Where(t => t.IsClass && !t.IsAbstract))
                {
                    var interfaces = item.GetInterfaces();

                    // если класс реализаует заданный интерфейс
                    if (interfaces.Contains(needType))
                    {
                        //добавляем в операции экземпляр данного класса
                        var instance = Activator.CreateInstance(item);

                        var operation = instance as IOperation;
                        if (operation != null)
                        {
                            Operations.Add(operation);
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

