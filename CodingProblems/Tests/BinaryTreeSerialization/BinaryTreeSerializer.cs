using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingProblems.Tests.BinaryTreeSerialization
{
    /// <summary>
    ///Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.
    ///For example, given the following Node class
    ///class Node:
    ///    def __init__(self, val, left=None, right=None):
    ///        self.val = val
    ///        self.left = left
    ///        self.right = right
    ///The following test should pass:
    ///node = Node('root', Node('left', Node('left.left')), Node('right'))
    ///assert deserialize(serialize(node)).left.left.val == 'left.left'
    /// </summary>
    [TestFixture]
    internal class BinaryTreeSerializer
    {
        private const string EmptyNodeSymbol = "0";

        [Test]
        public void Test()
        {
            var node = new Node("root", new Node("left", new Node("left.left")), new Node("right"));
            Assert.AreEqual("left.left", Deserialize(SerializeRecursive(node)).Left.Left.Val);
            Assert.AreEqual("right", Deserialize(SerializeRecursive(node)).Right.Val);
        }

        private Node Deserialize(string stringNode)
        {
            var nodes = stringNode.Split('-').ToList();
            var queue = new Queue<string>(nodes);
            var outputNode = NodeBuilderRecursive(queue);
            return outputNode;
        }

        private Node NodeBuilderRecursive(Queue<string> nodes)
        {
            if (nodes.Peek() != null)
            {
                var currentNode = nodes.Dequeue();
                if (currentNode == EmptyNodeSymbol)
                {
                    return null;
                }

                var node = new Node(currentNode, NodeBuilderRecursive(nodes), NodeBuilderRecursive(nodes));

                return node;
            }

            return null;
        }

        private string SerializeRecursive(Node root)
        {
            var result = "";
            if (root == null)
            {
                return $"{result}{EmptyNodeSymbol}-";
            }

            result += $"{root.Val}-";
            result += $"{SerializeRecursive(root.Left)}{SerializeRecursive(root.Right)}";

            return result;
        }
    }
}