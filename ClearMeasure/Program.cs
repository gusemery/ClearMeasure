using Autofac;
using FizzBuzzLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClearMeasure
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            SetupIoC();

            Dictionary<int, string> cases = new Dictionary<int, string>();
            cases.Add(2, "Boom");
            cases.Add(6, "Ka-Boom");
            cases.Add(8, "Whoa");

            using (var scope = Container.BeginLifetimeScope())
            {
                var fizzBuzz = scope.Resolve<IFizzBuzz>();
                
                var items2 = fizzBuzz.Process(1, 100);
                foreach (var item in items2)
                    Console.WriteLine(item);
                
            }



            Console.Read();
        }

        private static void SetupIoC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FizzBuzz>().As<IFizzBuzz>();
            builder.RegisterType<FizzBuzzCase>().As<IFizzBuzzCase>();
            builder.RegisterType<FizzBuzzCases>().As<IFizzBuzzCases>();
            Container = builder.Build();
        }
    }
}
