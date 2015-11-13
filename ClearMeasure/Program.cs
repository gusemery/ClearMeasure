using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClearMeasure
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, string> cases = new Dictionary<int, string>();
            cases.Add(2, "Boom");
            cases.Add(6, "Ka-Boom");
            cases.Add(8, "Whoa");

            var items2 = FizzBuzzLib.FizzBuzz.Process(1, 100, cases);


            foreach (var item in items2)
                Console.WriteLine(item);

            Console.Read();
        }
    }
}
