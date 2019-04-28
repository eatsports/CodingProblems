using System.Collections.Generic;
using NUnit.Framework;

namespace CodingProblems.Tests
{
    /// <summary>
    /// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
    /// For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
    /// </summary>
    [TestFixture]
    internal class SumOfAnyTwo
    {
        [Test]
        public void Test()
        {
            Assert.True(IsSumOfAnyTwo(new[] {10, 15, 3, 7}, 17));
            Assert.True(IsSumOfAnyTwo(new[] {10, 15, 3, 7}, 18));
            Assert.True(IsSumOfAnyTwo(new[] {10, 15, 3, 7}, 13));

            Assert.False(IsSumOfAnyTwo(new[] {10, 15, 3, 7}, 15));
            Assert.False(IsSumOfAnyTwo(new[] {10, 15, 3, 7}, 7));
            Assert.False(IsSumOfAnyTwo(new[] {10, 15, 3, 7}, 11));
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