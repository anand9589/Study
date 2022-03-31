namespace TreeProblem.Classes
{
    public class Tree
    {
        public TreeNode Root { get; set; }

        public Tree(int data)
        {
            Root = new TreeNode(data);
        }
    }
}
