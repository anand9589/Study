namespace TreeProblem.Classes
{
    internal class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int key)
        {
            this.Data = key;
            this.Left = null;
            this.Right = null;
        }
    }
}
