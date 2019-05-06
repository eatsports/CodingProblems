using NUnit.Framework;

namespace CodingProblems.Tests
{
    [TestFixture]
    public class ClimbingLadders
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(5, CountStairSteps(4, new[] {1, 2}));
            Assert.AreEqual(8, CountStairSteps(5, new[] {1, 2}));
            Assert.AreEqual(0, CountStairSteps(0, new[] {1, 2}));
            Assert.AreEqual(1, CountStairSteps(1, new[] {1, 2}));
            Assert.AreEqual(2, CountStairSteps(2, new[] {1, 2}));
            
            Assert.AreEqual(5, CountStairSteps(5, new[] {1, 3, 5}));
            Assert.AreEqual(19, CountStairSteps(8, new[] {1, 3, 5}));
        }

        private int CountStairSteps(int steps, int[] legalMoves)
        {
            if (steps <= 0) return 0;
            var arrayLength = legalMoves.Length;
            var count = 0;
            for (var i = 0; i < arrayLength; i++)
            {
                var delta = steps - legalMoves[i];
                if (delta == 0) count++;
                else
                {
                    count += CountStairSteps(delta, legalMoves);
                }
            }

            return count;
        }
    }
}