namespace GraphProject
{
    internal class BSTIterator
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        public BSTIterator(TreeNode root)
        {
            partialInorder(root);
        }

        private void partialInorder(TreeNode root)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }
        }

        public int Next()
        {
            TreeNode treeNode = stack.Pop();
            partialInorder((TreeNode)treeNode.right);
            return treeNode.val;
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }
    }
}
