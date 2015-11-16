using System;
namespace FizzBuzzLib
{
    public interface IFizzBuzz
    {
        System.Collections.Generic.IList<string> Process(int start, int finish);
    }
}
