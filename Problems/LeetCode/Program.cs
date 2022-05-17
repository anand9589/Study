// See https://aka.ms/new-console-template for more information

using LeetCode;
using static LeetCode.Solution;
var data = File.ReadAllLines(@"C:\Workspace\Study\Problems\Practice.txt");

////int[][] input
var d = data[0].Split("],[");
int[][] inputArray = new int[d.Length][];
for (int i = 0; i < d.Length; i++)
{
    inputArray[i] = Array.ConvertAll(d[i].Split(','), int.Parse);
}
//int k = int.Parse(data[1]);
Solution solution = new Solution();
//ListNode last = new ListNode(5);
//last = new ListNode(4, last);
//last = new ListNode(3, last);
//last = new ListNode(2, last);
//last = new ListNode(1, last);
//last = new ListNode(0, last);
//solution.AddBinary("1010", "1011");
var p = solution.CheckInclusion("hello","ooolleoooleh");
Console.WriteLine(p);
//solution.SetZeroes(inputArray);