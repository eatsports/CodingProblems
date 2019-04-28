namespace CodingProblems.Tests.BinaryTreeSerialization
{
    internal class Node
    {
        public string Val { get; }
        public Node Left { get; }
        public Node Right { get; }

        public Node(string val, Node left = null, Node right = null)
        {
            Val = val;
            Left = left;
            Right = right;
        }
    }
}