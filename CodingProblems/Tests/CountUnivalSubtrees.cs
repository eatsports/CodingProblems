using CodingProblems.Tests.BinaryTreeSerialization;
using NUnit.Framework;

namespace CodingProblems.Tests
{
    /// <summary>
    /// A unival tree (which stands for "universal value") is a tree where all nodes under it have the same value.
    /// Given the root to a binary tree, count the number of unival subtrees.
    /// For example, the following tree has 5 unival subtrees:
    ///    0
    ///   / \
    ///  1   0
    ///     / \
    ///    1   0
    ///  / \
    /// 1   1
    /// </summary>
    [TestFixture]
    public class CountUnivalSubtrees
    {
        [Test]
        public void Test()
        {
            var node = new Node("0",
                new Node("1"),
                new Node("0",
                    new Node("1",
                        new Node("1"),
                        new Node("1")),
                    new Node("0")));
            Assert.AreEqual(5, CountSubtreesRecursive(node));

            node = new Node("0");
            Assert.AreEqual(1, CountSubtreesRecursive(node));

            node = new Node("0", new Node("1"), new Node("1"));
            Assert.AreEqual(3, CountSubtreesRecursive(node));
        }

        public int CountSubtreesRecursive(Node node)
        {
            var count = 0;
            if (node == null)
            {
                return count;
            }

            var bothNodesAreNull = node.Left == null && node.Right == null;
            if (bothNodesAreNull) return ++count;

            if (node.Left != null && node.Right.Val == node.Left.Val)
            {
                count++;
            }

            return count + CountSubtreesRecursive(node.Left) + CountSubtreesRecursive(node.Right);
        }
    }
}