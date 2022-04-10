// See https://aka.ms/new-console-template for more information
using HeapProblems;

//Console.WriteLine("Hello, World!");
Solution sol = new Solution();

//sol.BubbleSort(new int[] { 5, 1, 4, 2, 8 });
//sol.InsertionSort(new int[] { 5, 1, 4, 2, 8 });
//int[] arr = new int[] { 2, 8, 4, 9, 3, 23, 1, 43, 12, 11 };

//Console.WriteLine(String.Join(' ', arr));
////sol.createMaxHeap(arr,arr.Length,0);
//sol.HeapSort_V1(arr);
//Console.WriteLine(String.Join(' ', arr));


var lines = File.ReadAllLines(@"C:\Workspace\Study\Problems\mergeklinkedlist.txt");
int[] m = Array.ConvertAll(lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
int[] arr = Array.ConvertAll(lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
//Node[] arr = new Node[n];
//string[] ip = lines[1].Trim().Split(' ');
//int i = 0;
//for (int j = 0; j < n; j++)
//{
//    int N = int.Parse(ip[i]);
//    i++;
//    int x = int.Parse(ip[i]);
//    i++;
//    arr[j] = new Node(x);
//    Node curr = arr[j];
//    N--;
//    for (int k = 0; k < N; k++, i++)
//    {
//        x = int.Parse(ip[i]);
//        Node temp = new Node(x);
//        curr.next = temp;
//        curr = temp;
//    }
//}

var res = sol.kLargest(arr, m[0], m[1]);

//var res = sol.MaximumProduct(new int[] {24, 5, 64, 53, 26, 38},54);
//var res = sol.CostOfRopes(n1,n);


//List<List<int>> list = new List<List<int>>();

//for (int i = 0; i < n; i++)
//{
//    list.Add(new List<int>());
//    for (int j = 0; j < n; j++)
//    {
//        list[i].Add(n1[i*n + j]);
//    }
//}
//sol.mergeKArrays(ref list, n);

//MinHeap minHeap = new MinHeap(n);
//int[] tc = Array.ConvertAll(lines[1].Trim().Split(' '), int.Parse);
//for (int i = 0; i < tc.Length; i++)
//{
//    switch (tc[i])
//    {
//        case 1:
//            i++;
//            if(tc[i] == 730 || tc[i] == 824)
//            {

//            }
//            Console.WriteLine($"Inserting {tc[i]}" );
//            minHeap.insertKey(tc[i]);
//            minHeap.print();
//            break;
//        case 2:
//            i++;
//            minHeap.deleteKey(tc[i]);
//            Console.Write("Deleting node " + tc[i]);
//            minHeap.print();
//            break;
//        case 3:
//            int result =  minHeap.extractMin();
//            Console.Write("Getting Min " + result);
//            minHeap.print();
//            //  Console.WriteLine(result);
//            break;
//        default:
//            break;
//    }
//}
//int result = -1;

//minHeap.insertKey(4);
//minHeap.insertKey(2);
//result = minHeap.extractMin();
//Console.WriteLine(result);
//minHeap.insertKey(6);
//minHeap.deleteKey(0);
//result = minHeap.extractMin();
//Console.WriteLine(result);
//result = minHeap.extractMin();
//Console.WriteLine(result);
