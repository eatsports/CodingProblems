using System.Collections.Generic;
using NUnit.Framework;

namespace CodingProblems.Tests
{
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