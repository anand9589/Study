// See https://aka.ms/new-console-template for more information
using TreeProblem;
using TreeProblem.Classes;

//Console.WriteLine("Hello, World!");
var lines = File.ReadAllLines(@"C:\Workspace\Study\Problems\BST.txt");
#region TreeExample
//Tree tree = new Tree(55);
//tree.Root.Childs.Add(new TreeNode(75));
#endregion
// { Driver Code Starts
//Initial Template for C#

var gfg = new GFG();
var str = lines[0].Trim();

var root = gfg.buildTree(str);
//var str1 = lines[1].Trim();
//var root1 = gfg.buildTree(str1);
Solution obj = new Solution();
var res = obj.DeleteNode(root, 50);


//List<int> res = obj.PreOrderTraversal(root);
//Console.WriteLine(string.Join(',', res));
//res = obj.InOrderTraversal(root);
//Console.WriteLine(string.Join(',', res));
//res = obj.PostOrderTraversal(root);
//Console.WriteLine(string.Join(',', res));
//Console.ReadLine();
//Console.WriteLine(string.Join(',',res));

//foreach (var item in res.Keys)
//{
//    Console.Write($"{item} : ");
//    foreach (var data in res[item])
//    {
//        Console.Write(data.data);
//        Console.Write(" ");
//    }
//    Console.WriteLine();
//}
//obj.leftView(root);
//var res = obj.isBST(root);
//Console.WriteLine(res ? 1 : 0);
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//class Node
//{
//    public int data;
//    public Node left;
//    public Node right;

//    public Node(int key)
//    {
//        this.data = key;
//        this.left = null;
//        this.right = null;
//    }
//}


class GFG
{
    // Function to Build Tree
    public Node buildTree(string str)
    {
        // Corner Case
        if (str.Length == 0 || str[0] == 'N')
            return null;

        // Creating vector of strings from input
        // string after spliting by space
        var ip = str.Split(' ');



        Node root = new Node(int.Parse(ip[0]));


        // Push the root to the queue
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        // Starting from the second element
        int i = 1;
        while (queue.Count != 0 && i < ip.Length)
        {

            // Get and remove the front of the queue
            Node currNode = queue.Peek();
            queue.Dequeue();

            // Get the current node's value from the string
            string currVal = ip[i];

            // If the left child is not null
            if (currVal != "N")
            {

                // Create the left child for the current node
                currNode.Left = new Node(int.Parse(currVal));

                // Push it to the queue
                queue.Enqueue(currNode.Left);
            }

            // For the right child
            i++;
            if (i >= ip.Length)
                break;
            currVal = ip[i];

            // If the right child is not null
            if (currVal != "N")
            {

                // Create the right child for the current node
                currNode.Right = new Node(int.Parse(currVal));

                // Push it to the queue
                queue.Enqueue(currNode.Right);
            }
            i++;
        }

        return root;
    }

    void inorder(Node root)
    {
        if (root == null) return;
        inorder(root.Left);
        Console.Write(root.Data + " ");
        inorder(root.Right);
    }



}
// } Driver Code Ends


//User function Template for C#

/*  A binary tree Node
    class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int key)
        {
            this.data = key;
            this.left = null;
            this.right = null;
        }
    }
*/

//class Solution
//{

//    //Function to check whether a Binary Tree is BST or not.
//    public bool isBST(Node root)
//    {
//        if (root == null) return true;
//        // Your code here
//        bool result = true;
//        if (root != null)
//        {

//            if (root.left != null && root.data > root.left.data)
//            {
//                result = isBST(root.left);
//            }

//            if (!result) return false;

//            if (root.right != null && root.data < root.right.data)
//            {
//                result = isBST(root.right);
//            }

//        }

//        return result;
//    }
//}