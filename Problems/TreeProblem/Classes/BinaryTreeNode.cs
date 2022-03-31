namespace TreeProblem.Classes
{
    public class BinaryTreeNode
    {
        public int Data { get; set; }

        public BinaryTreeNode Left { get; set; }

        public BinaryTreeNode Right { get; set; }

        public BinaryTreeNode(int data)
        {
            this.Data = data;
            Left = null;
            Right = null;
        }
    }
}
