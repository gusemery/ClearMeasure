using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FizzBuzzLib;

namespace TestProject
{
    public class FizzBuzzTests
    {
        IFizzBuzzCases Cases;

        [TestFixtureSetUp]
        public void TestingSetup()
        {
            Cases = GetNormalCases();
        }

        [TestFixtureTearDown]
        public void TestingShutdown()
        {
            Cases.Cases.Clear();
            Cases = null;
        }

        [TestCase(1, 10)]
        public void TestFizzBuzzForSuccess(int lower, int higher)
        {
            var fizzBuzz = new FizzBuzz(Cases);
            var result = fizzBuzz.Process(lower, higher);

            var array = result.ToArray();
            Assert.That(array[0].Contains("Two") == false);
            Assert.That(array[1].Contains("Two"));
            Assert.That(array[2].Contains("Three"));
            Assert.That(array[3].Contains("Two"));
            Assert.That(array[5].Contains("Two Three Bazinga"));
        }

        [TestCase(1,10)]
        public void TestDivByZero(int lower, int higher)
        {
            try
            {
                var cases = GetNormalCases();
                //Add div by zero error
                cases.Cases.Add(new FizzBuzzCase() { Divisor = 0, Message = "Boink" });

                var fizzBuzz = new FizzBuzz(Cases);
                var result = fizzBuzz.Process(lower, higher);

            }
            catch (IndexOutOfRangeException ex )
            {
                var exType = ex.GetType();

                //The code should catch the key of 0 and fail the execution with an IndexOutOfRange.
                Assert.That(exType == typeof(IndexOutOfRangeException));
                return;
            }
            finally
            {
                TestingSetup();
            }
        }

        [TestCase(12,6)]
        [TestCase(0,1)]
        [TestCase(4, -2)]
        public void TestValidationofCall(int lower, int higher)
        {
            try
            {
                var fizzBuzz = new FizzBuzz(Cases);
                var result = fizzBuzz.Process(lower, higher);
            }
            catch(IndexOutOfRangeException )
            {
                //Expecting IndexOutOfRange.... 
                return;
            }
            throw new InvalidProgramException("The code should have exited by now!");
        }

        private IFizzBuzzCases GetNormalCases()
        {
            IFizzBuzzCases cases = new FizzBuzzCases();
            cases.Cases.Clear();
            cases.Cases.Add(new FizzBuzzCase() { Divisor = 2, Message = "Two" }); 
            cases.Cases.Add(new FizzBuzzCase() { Divisor = 3, Message = "Three" });
            cases.Cases.Add(new FizzBuzzCase() { Divisor = 6, Message = "Bazinga" });
            return cases;
        }
    }
}
