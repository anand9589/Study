// See https://aka.ms/new-console-template for more information
using TreeProblem.Classes;

Console.WriteLine("Hello, World!");

#region TreeExample
Tree tree = new Tree(55);
tree.Root.Childs.Add(new TreeNode(75));
#endregion
