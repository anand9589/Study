// See https://aka.ms/new-console-template for more information
using HeapProblems;

//Console.WriteLine("Hello, World!");
Solution sol = new Solution();

//sol.BubbleSort(new int[] { 5, 1, 4, 2, 8 });
//sol.InsertionSort(new int[] { 5, 1, 4, 2, 8 });
int[] arr = new int[] { 10, 16, 8, 12, 15, 7, 6, 3, 9, 5 };

Console.WriteLine(String.Join(' ', arr));
 sol.QuickSort(arr, 0, 9);
Console.WriteLine(String.Join(' ',arr));