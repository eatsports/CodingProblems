using System.Collections.Generic;
using NUnit.Framework;

namespace CodingProblems.Tests
{
    /// <summary>
    /// Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.
    /// For example, given s = "abcba" and k = 2, the longest substring with k distinct characters is "bcb".
    /// </summary>
    [TestFixture]
    public class LongestStringOfKCharacters
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(3, GetLongestString("abcba", 2));
            Assert.AreEqual(5, GetLongestString("abcba", 3));
            Assert.AreEqual(4, GetLongestString("abcbca", 2));
            Assert.AreEqual(1, GetLongestString("abcbca", 1));
        }

        private int GetLongestString(string str, int maxChars)
        {
            if (maxChars == 1) return 1;
            var queue = new Queue<char>();
            var count = 0;
            var maxCount = 0;
            var stringLength = str.Length;
            for (var i = 0; i < stringLength; i++)
            {
                if (queue.Count < maxChars)
                {
                    queue.Enqueue(str[i]);
                }
                else
                {
                    if (!queue.Contains(str[i]))
                    {
                        queue.Dequeue();
                        queue.Enqueue(str[i]);
                        if (count > maxCount) maxCount = count;
                        count = 1;
                    }
                }

                count++;
            }


            return count > maxCount ? count : maxCount;
        }
    }
}