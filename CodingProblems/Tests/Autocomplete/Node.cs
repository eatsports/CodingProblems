namespace CodingProblems.Tests.Autocomplete
{
    internal class Node
    {
        internal char Value;
        internal bool StringEnd;

        internal Node Left, Center, Right;

        public Node(char value, bool stringEnd)
        {
            Value = value;
            StringEnd = stringEnd;
        }
    }
}