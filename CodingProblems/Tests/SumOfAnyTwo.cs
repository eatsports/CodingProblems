using System.Collections.Generic;
using NUnit.Framework;

//    Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
//    For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
namespace CodingProblems
{
    [TestFixture]
    internal class SumOfAnyTwo
    {
        [Test]
        public void Test()
        {
            Assert.True(IsSumOfAnyTwo(new[] {10, 15, 3, 7}, 17));
        }

        private bool IsSumOfAnyTwo(int[] arr, int k)
        {
            var cache = new HashSet<int>();
            var arrayLength = arr.Length;
            for (var i = 0; i < arrayLength; i++)
            {
                var currentElement = arr[i];
                var delta = k - currentElement;

                if (cache.Contains(delta))
                {
                    return true;
                }

                if (!cache.Contains(currentElement))
                {
                    cache.Add(currentElement);
                }
            }

            return false;
        }
    }
}