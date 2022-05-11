namespace LeetCode
{
    public class Node
    {
        public int Val;
        public Node Left;
        public Node Right;
        public Node Next;

        public Node() { }

        public Node(int _val)
        {
            Val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            Val = _val;
            Left = _left;
            Right = _right;
            Next = _next;
        }
    }
}
