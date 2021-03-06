﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLib
{
    public class FizzBuzz : FizzBuzzLib.IFizzBuzz
    {
        private IFizzBuzzCases _cases;

        public FizzBuzz(IFizzBuzzCases cases)
        {
            _cases = cases;
        }

        /// <summary>
        /// This function will take in a start and a finish integer and a Dictionary of test cases. Any of the divisors (int) within the 
        /// Cases will be applied against the current number and the string contained within the Case will be added to the string.
        /// 
        ///    Example
        ///    
        ///      1, "Every"
        ///      2, "Other"
        ///      
        /// calling ProcessUnlimited(1,4, cases) {using cases above} would return
        /// 
        ///  1 Every
        ///  2 Every Other
        ///  3 Every
        ///  4 Every Other
        ///  
        /// </summary>
        /// <param name="start">
        ///     Start of numbers to test.
        /// </param>
        /// <param name="finish">
        ///     End of numbers to test.
        /// </param>
        /// <returns></returns>
        public IList<string> Process(int start, int finish)
        {
            
            if (finish < start || finish == 0 || start == finish || start == 0 || _cases.Cases.Where(x => x.Divisor == 0).Count() > 0)
                throw new IndexOutOfRangeException("The passed variables are not within spec. The start has to be > 0 and finish has to be greater than Start and != 0. And there cannot be a Divisor of 0 ");

            List<string> result = new List<string>();

            for (var x = start; x <= finish; x++)
            {
                var buffer = x.ToString();
                foreach (var varCase in _cases.Cases)
                {
                    if (x % varCase.Divisor == 0)
                        buffer = string.Format("{0} {1}", buffer, varCase.Message);
                }
                result.Add(buffer);
            }

            return result;
        }
    }
}
