﻿// See https://aka.ms/new-console-template for more information

using LeetCode;
var data = File.ReadAllLines(@"C:\Workspace\Study\Problems\Practice.txt");

////int[][] input
var d = data[0].Split("],[");
int[][] matrix = new int[d.Length][];

for (int i = 0; i < d.Length; i++)
{
    d[i] = d[i].Replace("\"", "");
    string[] p = d[i].Split(",").ToArray();
    matrix[i] = new int[p.Length];
    for (int j = 0; j < p.Length; j++)
    {
        matrix[i][j] = int.Parse(p[j]);
    }
}
//int[][] inputArray = new int[d.Length][];
//for (int i = 0; i < d.Length; i++)
//{
//    inputArray[i] = Array.ConvertAll(d[i].Split(','), int.Parse);
//}
//int sr = int.Parse(data[1]);
//int sc = int.Parse(data[2]);
//int newColor = int.Parse(data[3]);
//int k = int.Parse(data[1]);
Solution solution = new Solution();
solution.UniquePathsWithObstacles(matrix);
//solution.FloodFill(inputArray,sr,sc,newColor);
//ListNode last = new ListNode(5);
//last = new ListNode(4, last);
//last = new ListNode(3, last);
//last = new ListNode(2, last);
//last = new ListNode(1, last);
//last = new ListNode(0, last);
//solution.AddBinary("1010", "1011");
//[-1,0,3,5,9,12]
//0
//var p = solution.Search(new int[] { -1, 0, 3, 5, 9, 12 }, 0);
//Console.WriteLine(p);
//solution.SetZeroes(inputArray);]
