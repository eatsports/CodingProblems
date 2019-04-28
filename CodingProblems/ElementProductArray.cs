using System;
using NUnit.Framework;

namespace CodingProblems
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
            var tmpArray = new int[arr.Length];
            Array.Copy(arr, tmpArray, arr.Length);
            var product = 1;
            for (var i = 0; i < tmpArray.Length; i++)
            {
                product *= tmpArray[i];
            }

            for (var i = 0; i < tmpArray.Length; i++)
            {
                tmpArray[i] = product / tmpArray[i];
            }

            return tmpArray;
        }

        // Follow-up: what if you can't use division?
        private int[] GetProductArrayNoDivision(int[] arr) // O(2n)
        {
            var product = new int[arr.Length];
            var tmpNum = 1;
            for (var i = 0; i < product.Length; i++)
            {
                product[i] = tmpNum;
                tmpNum *= arr[i];
            }

            tmpNum = 1;
            for (var i = product.Length - 1; i >= 0; i--)
            {
                product[i] *= tmpNum;
                tmpNum *= arr[i];
            }

            return product;
        }
    }
}