using System;
using NUnit.Framework;

namespace CodingProblems.Tests
{
    /// <summary>
    /// Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.
    /// For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.
    /// You can assume that the messages are decodable. For example, '001' is not allowed.
    /// </summary>
    [TestFixture]
    public class MessageDecodeWays
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(6, CountWays(12425434));
            Assert.AreEqual(3, CountWays(121));
            Assert.AreEqual(3, CountWays(1234));
            Assert.AreEqual(3, CountWays(111));
            Assert.AreEqual(1, CountWays(101));
        }

        private int CountWays(int input)
        {
            var array = IntToArray(input);
            var arrayLength = array.Length;
            var output = CountWaysRecursive(array, arrayLength);
            return output;
        }

        private int CountWaysRecursive(int[] array, int arrayLength)
        {
            if (arrayLength == 0) return 1;
            if (arrayLength == 1) return 1;

            var count = 0;

            var lastElementNotZero = array[arrayLength - 1] > 0;
            if (lastElementNotZero)
            {
                count = CountWaysRecursive(array, arrayLength - 1);
            }

            var lastTwoElementsMakeValidNum = (array[arrayLength - 2] == 1 || array[arrayLength - 2] == 2) &&
                                              array[arrayLength - 1] < 7;
            if (lastTwoElementsMakeValidNum)
            {
                count += CountWaysRecursive(array, arrayLength - 2);
            }

            return count;
        }

        private int[] IntToArray(int number)
        {
            var arrayLength = GetNumberLength(number);
            var result = new int[arrayLength];
            for (var i = 0; i < arrayLength; i++)
            {
                var a = Math.Pow(10, arrayLength - i - 1);
                var left = number / a;
                result[i] = (int) left;
                number -= (int) a * result[i];
            }

            return result;
        }

        private int GetNumberLength(int number)
        {
            return (int) Math.Log10(number) + 1;
        }
    }
}