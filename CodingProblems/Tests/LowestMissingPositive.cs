using System;
using NUnit.Framework;

namespace CodingProblems.Tests
{
    /// <summary>
    /// Given an array of integers, find the first missing positive integer in linear time and constant space.
    /// In other words, find the lowest positive integer that does not exist in the array.
    /// The array can contain duplicates and negative numbers as well.
    ///
    /// For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.
    /// </summary>
    [TestFixture]
    internal class LowestMissingPositive
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(2, GetMinMissingPositiveInt(new[] {3, 4, -1, 1}));
            Assert.AreEqual(3, GetMinMissingPositiveInt(new[] {1, 2, 0}));
            Assert.AreEqual(5, GetMinMissingPositiveInt(new[] {3, 7, 6, -1, 1, 0, 4, 2}));
        }

        private int GetMinMissingPositiveInt(int[] arr)
        {
            Array.Sort(arr);
            var result = 1;
            var arrayLength = arr.Length;
            for (var i = 0; i < arrayLength; i++)
            {
                if (arr[i] <= result) continue;
                if (arr[i] != result + 1)
                {
                    result++;
                    return result;
                }

                result++;
            }

            result++;
            return result;
        }
    }
}