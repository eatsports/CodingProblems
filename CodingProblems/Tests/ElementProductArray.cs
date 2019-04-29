using NUnit.Framework;

namespace CodingProblems.Tests
{
    /// <summary>
    /// Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.
    /// For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].
    /// </summary>
    [TestFixture]
    internal class ElementProductArray
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(new[] {120, 60, 40, 30, 24}, GetProductArray(new[] {1, 2, 3, 4, 5}));
            Assert.AreEqual(new[] {2, 3, 6}, GetProductArray(new[] {3, 2, 1}));
            // No Division
            Assert.AreEqual(new[] {120, 60, 40, 30, 24}, GetProductArrayNoDivision(new[] {1, 2, 3, 4, 5}));
            Assert.AreEqual(new[] {2, 3, 6}, GetProductArrayNoDivision(new[] {3, 2, 1}));
        }

        private int[] GetProductArray(int[] arr) // O(2n)
        {
            var arrayLength = arr.Length;

            var result = new int[arrayLength];

            var product = 1;
            for (var i = 0; i < arrayLength; i++)
            {
                product *= arr[i];
            }

            for (var i = 0; i < arrayLength; i++)
            {
                result[i] = product / arr[i];
            }

            return result;
        }

        // Follow-up: what if you can't use division?
        private int[] GetProductArrayNoDivision(int[] arr) // O(2n)
        {
            var arrayLength = arr.Length;
            var result = new int[arrayLength];
            var tmpNum = 1;
            for (var i = 0; i < arrayLength; i++)
            {
                result[i] = tmpNum;
                tmpNum *= arr[i];
            }

            tmpNum = 1;
            for (var i = arrayLength - 1; i >= 0; i--)
            {
                result[i] *= tmpNum;
                tmpNum *= arr[i];
            }

            return result;
        }
    }
}