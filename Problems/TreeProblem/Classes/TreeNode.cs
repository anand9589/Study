namespace TreeProblem.Classes
{
    public class TreeNode
    {
        public int Data { get; set; }

        public List<TreeNode> Childs { get; set; }
        public TreeNode(int data)
        {
            this.Data = data;
            Childs = new List<TreeNode>();
        }
    }
}
