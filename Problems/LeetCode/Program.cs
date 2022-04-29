// See https://aka.ms/new-console-template for more information

using LeetCode;
//[10,1,2,7,6,1,5]
//8
Solution solution = new Solution();
var res = solution.FirstMissingPositive(new int[] { 1, 2, 0 });
Console.WriteLine(res);