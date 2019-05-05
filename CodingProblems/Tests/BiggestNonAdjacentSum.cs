using NUnit.Framework;

namespace CodingProblems.Tests
{
    [TestFixture]
    public class BiggestNonAdjacentSum
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(13, FindBiggestNonAdjacentSum(new[] {2, 4, 6, 2, 5}));
            Assert.AreEqual(10, FindBiggestNonAdjacentSum(new[] {5, 1, 1, 5}));
        }

        public int FindBiggestNonAdjacentSum(int[] array)
        {
            var arrayLength = array.Length;
            var inclLast = array[0];
            var exclLast = 0;
            for (var i = 1; i < arrayLength; i++)
            {
                var exclTmp = inclLast > exclLast ? inclLast : exclLast;
                inclLast = exclLast + array[i];
                exclLast = exclTmp;
            }

            return inclLast > exclLast ? inclLast : exclLast;
        }
    }
}