using NUnit.Framework;

namespace CodingProblems.Tests
{
    /// <summary>
    /// There exists a staircase with N steps, and you can climb up either 1 or 2 steps at a time.
    /// Given N, write a function that returns the number of unique ways you can climb the staircase.
    /// The order of the steps matters.
    ///
    /// For example, if N is 4, then there are 5 unique ways:
    /// 1, 1, 1, 1
    /// 2, 1, 1
    /// 1, 2, 1
    /// 1, 1, 2
    /// 2, 2
    ///
    /// What if, instead of being able to climb 1 or 2 steps at a time,
    /// you could climb any number from a set of positive integers X?
    /// For example, if X = {1, 3, 5}, you could climb 1, 3, or 5 steps at a time.
    /// </summary>
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