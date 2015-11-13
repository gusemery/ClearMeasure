using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestProject
{
    public class FizzBuzzTests
    {
        Dictionary<int, string> Cases;

        [TestFixtureSetUp]
        public void TestingSetup()
        {
            Cases = new Dictionary<int, string>();
            Cases.Add(2, "Two");
            Cases.Add(3, "Three");
            Cases.Add(6, "Bazinga");
        }

        [TestFixtureTearDown]
        public void TestingShutdown()
        {
            Cases.Clear();
            Cases = null;
        }

        [TestCase(1, 10)]
        public void TestFizzBuzzForSuccess(int lower, int higher)
        {
            var result = FizzBuzzLib.FizzBuzz.Process(lower, higher, Cases);

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
                //Add div by zero error
                Cases.Add(0, "Boink");
                var result = FizzBuzzLib.FizzBuzz.Process(lower, higher, Cases);

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
                Cases.Remove(0);
                
            }
        }

        [TestCase(12,6)]
        [TestCase(0,1)]
        [TestCase(4, -2)]
        public void TestValidationofCall(int lower, int higher)
        {
            try
            {
                var result = FizzBuzzLib.FizzBuzz.Process(lower, higher, Cases);
            }
            catch(IndexOutOfRangeException )
            {
                //Expecting IndexOutOfRange.... 
                return;
            }
            throw new InvalidProgramException("The code should have exited by now!");
        }
    }
}
