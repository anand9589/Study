// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using GraphProject;

//Graph_V1 graph_V1 = new Graph_V1(5);

//graph_V1.AddEdge(0, 1);
//graph_V1.AddEdge(0, 4);
//graph_V1.AddEdge(1, 4);
//graph_V1.AddEdge(3, 4);
//graph_V1.AddEdge(1, 2);
//graph_V1.AddEdge(3, 2);
//graph_V1.AddEdge(1, 3);

//graph_V1.Print();
//var lines = File.ReadAllLines(@"C:\Workspace\Study\Problems\stepsbynight.txt");
//int v = int.Parse(lines[0].Trim().Split(' ')[0]);
//List<int> start = Array.ConvertAll(lines[1].Trim().Split(' '), int.Parse).ToList();
//List<int> end = Array.ConvertAll(lines[2].Trim().Split(' '), int.Parse).ToList();
//int e = int.Parse(lines[0].Trim().Split(' ')[1]);

//List<List<List<int>>> list = new List<List<List<int>>>();

//for (int i = 0; i < v; i++)
//{
//    list.Add(new List<List<int>>());
//} 

//for (int i = 0; i < e; i++)
//{
//    int v1 = int.Parse(lines[i + 1].Trim().Split(' ')[0]);
//    int v2 = int.Parse(lines[i + 1].Trim().Split(' ')[1]);
//    int w = int.Parse(lines[i + 1].Trim().Split(' ')[2]);

//    list[v1].Add(new List<int> { v2, w });    
//    list[v2].Add(new List<int> { v1, w });
//}
//ListNode l1 = new ListNode(9);
//ListNode l2 = new ListNode(1);
//l2.next = new ListNode(9);
//l2.next.next = new ListNode(9);
//l2.next.next.next = new ListNode(9);
//l2.next.next.next.next = new ListNode(9);
//l2.next.next.next.next.next = new ListNode(9);
//l2.next.next.next.next.next.next = new ListNode(9);
//l2.next.next.next.next.next.next.next = new ListNode(9);
//l2.next.next.next.next.next.next.next.next = new ListNode(9);
//l2.next.next.next.next.next.next.next.next.next = new ListNode(9);
Solution solution = new Solution();
var res = solution.MyAtoi("2147483646");
Console.WriteLine(res);

