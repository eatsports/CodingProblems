using System.Collections.Generic;
using NUnit.Framework;

namespace CodingProblems.Tests
{
    /// <summary>
    /// Given an array of integers, return the number of pairs of equal integers.
    /// For example, given array [10, 20, 20, 10, 10, 30, 50, 10, 20], the method should return 3.
    /// ([10, 10], [20,20], [10,10], the remaining integers have no matching pair)
    /// </summary>
    [TestFixture]
    public class CountPairsInArray
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(3, CountPairs(new[] {10, 20, 20, 10, 10, 30, 50, 10, 20}));
            Assert.AreEqual(4, CountPairs(new[] {1, 1, 3, 1, 2, 1, 3, 3, 3, 3}));
            Assert.AreEqual(6, CountPairs(new[] {6, 5, 2, 3, 5, 2, 2, 1, 1, 5, 1, 3, 3, 3, 5}));
            Assert.AreEqual(0, CountPairs(new[] {100}));
            Assert.AreEqual(9, CountPairs(new[] {4, 5, 5, 5, 6, 6, 4, 1, 4, 4, 3, 6, 6, 3, 6, 1, 4, 5, 5, 5}));
        }

        private int CountPairs(int[] array)
        {
            var arrayLength = array.Length;
            var cache = new HashSet<int>();

            var count = 0;
            for (var i = 0; i < arrayLength; i++)
            {
                if (!cache.Contains(array[i]))
                {
                    cache.Add(array[i]);
                }
                else
                {
                    count++;
                    cache.Remove(array[i]);
                }
            }

            return count;
        }
    }
}