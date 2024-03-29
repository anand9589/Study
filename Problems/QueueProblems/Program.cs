﻿// See https://aka.ms/new-console-template for more information
using QueueProblems;
using QueueProblems.LRU;

Console.WriteLine("Hello, World!");
var lines = File.ReadAllLines(@"C:\Workspace\Study\Problems\QueueByArray.txt");

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
//int n = int.Parse(lines[0]);
//int[] data = Array.ConvertAll(lines[1].Trim().Split(' '), int.Parse);
//StackQueue StackQueue = new StackQueue();
//for (int i = 0; i < data.Length; i++)
//{
//    switch (data[i])
//    {
//        case 1:
//            i++;
//            StackQueue.Push(data[i]);
//            break;
//        case 2:
//            Console.WriteLine(StackQueue.Pop());
//            break;
//        default:
//            break;
//    }
//}
#endregion

#region MaxSubArray
//int[] ips = Array.ConvertAll(lines[0].Trim().Split(' '), int.Parse);
//int[] arr = Array.ConvertAll(lines[1].Trim().Split(' '), int.Parse);

//solution.MaxOfSubArrays(arr, ips[1]);

#endregion

#region QueueByArray

//int n = int.Parse(lines[0].Trim());
//int[] data = Array.ConvertAll(lines[1].Trim().Split(' '), int.Parse);
//QueueByArray QueueByArray = new QueueByArray();
//for (int i = 0; i < data.Length; i++)
//{
//    switch (data[i])
//    {
//        case 1:
//            i++;
//            QueueByArray.push(data[i]);
//            break;
//        case 2:
//            Console.WriteLine(QueueByArray.pop());
//            break;
//        default:
//            break;
//    }
//}
#endregion

#region ReverseQueue
//Queue<int> q = new Queue<int>();
//q.Enqueue(1);
//q.Enqueue(2);
//q.Enqueue(3);
//q.Enqueue(4);
//q.Enqueue(5);
//solution.ReverseKElementsInQueue(q, 3);
#endregion

#region GenerateBinaryNumbers
solution.GenerateBinaryNumbers(5);
#endregion
