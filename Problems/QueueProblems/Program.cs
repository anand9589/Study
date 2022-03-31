// See https://aka.ms/new-console-template for more information
using QueueProblems;
using QueueProblems.LRU;

Console.WriteLine("Hello, World!");
var lines = File.ReadAllLines(@"C:\Workspace\Study\Problems\StackQueue.txt");

#region LRUCache
//int cap = int.Parse(lines[0]);
//int queries = int.Parse(lines[1]);
//LRUCache_V1 lRUCache = new LRUCache_V1(cap);

//string[] strings = lines[2].Trim().Split(' ');

//for (int i = 0; i < strings.Length; i++)
//{
//    switch (strings[i])
//    {
//        case "GET":
//            i++;
//            lRUCache.get(int.Parse(strings[i]));
//            break;
//        case "SET":
//            i++;
//            int key = int.Parse(strings[i]);
//            i++;
//            int value = int.Parse(strings[i]);
//            lRUCache.set(key, value);
//            break;
//        default:
//            break;
//    }
//}

#endregion

Solution solution = new Solution();
#region CircularTour
//int n = int.Parse(lines[0]);
//int[] data = Array.ConvertAll(lines[1].Trim().Split(' '), int.Parse);

//int[] p = new int[n];
//int[] d = new int[n];

//for (int i = 0; i < n; i++)
//{
//    p[i] = data[i*2];
//    d[i] = data[i*2 +1];
//}
//Console.WriteLine(String.Join(',', p));
//Console.WriteLine(String.Join(',', d));
//var res = global::QueueProblems.Solution.Tour(p, d, n);
//Console.WriteLine(res);
#endregion

#region StackQueue
int n = int.Parse(lines[0]);
int[] data = Array.ConvertAll(lines[1].Trim().Split(' '), int.Parse);
StackQueue StackQueue = new StackQueue();
for (int i = 0; i < data.Length; i++)
{
    switch (data[i])
    {
        case 1:
            i++;
            StackQueue.Push(data[i]);
            break;
        case 2:
            Console.WriteLine(StackQueue.Pop());
            break;
        default:
            break;
    }
}
#endregion
