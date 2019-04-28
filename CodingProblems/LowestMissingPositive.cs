using System;
using System.Diagnostics;
using NUnit.Framework;

namespace CodingProblems
{
    [TestFixture]
    internal class LowestMissingPositive
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(2, GetMinMissingPositiveInt(new[] {3, 4, -1, 1}));
            Assert.AreEqual(3, GetMinMissingPositiveInt(new[] {1, 2, 0}));
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