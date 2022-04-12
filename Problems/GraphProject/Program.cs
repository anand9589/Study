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
var lines = File.ReadAllLines(@"C:\Workspace\Study\Problems\bsf.txt");
int v = int.Parse(lines[0].Trim().Split(' ')[0]);
int e = int.Parse(lines[0].Trim().Split(' ')[1]);

List<List<int>> list = new List<List<int>>();

for (int i = 0; i < v; i++)
{
    list.Add(new List<int>());
}

for (int i = 0; i < e; i++)
{
    int v1 = int.Parse(lines[i + 1].Trim().Split(' ')[0]);
    int v2 = int.Parse(lines[i + 1].Trim().Split(' ')[1]);

    list[v1].Add(v2);
}
Solution solution = new Solution();
var res = solution.bfsOfGraph(v, list);
Console.WriteLine(res);

