// See https://aka.ms/new-console-template for more information
using HeapProblems;

//Console.WriteLine("Hello, World!");
Solution sol = new Solution();

//sol.BubbleSort(new int[] { 5, 1, 4, 2, 8 });
//sol.InsertionSort(new int[] { 5, 1, 4, 2, 8 });
int[] arr = new int[] { 2, 8, 4, 9, 3, 23, 1, 43, 12, 11 };

Console.WriteLine(String.Join(' ', arr));
//sol.createMaxHeap(arr,arr.Length,0);
sol.HeapSort(arr);
Console.WriteLine(String.Join(' ', arr));