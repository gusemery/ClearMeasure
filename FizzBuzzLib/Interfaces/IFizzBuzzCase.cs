using System;
namespace FizzBuzzLib
{
    public interface IFizzBuzzCase
    {
        int Divisor { get; set; }
        string Message { get; set; }
    }
}
