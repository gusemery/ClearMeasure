using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLib
{
    public class FizzBuzzCases : FizzBuzzLib.IFizzBuzzCases
    {
        List<FizzBuzzCase> _FizzBuzzCases;

        public FizzBuzzCases()
        {
            _FizzBuzzCases = new List<FizzBuzzCase>();
            _FizzBuzzCases.Add(new FizzBuzzCase(){Divisor = 2, Message="Fizz"});
            _FizzBuzzCases.Add(new FizzBuzzCase() { Divisor = 3, Message = "Buzz" });
        }

        public List<FizzBuzzCase> Cases
        {
            get
            {
                return _FizzBuzzCases;
            }
        }
    }
}
