﻿// See https://aka.ms/new-console-template for more information
using ArrayProblems;

Solution solution = new Solution();

#region 132Pattern
//bool result = solution.Find132Pattern(new int[] { 3, 1, 4, 2 });
//Console.WriteLine(result);
//result = solution.Find132Pattern(new int[] { 1,2,3,4 });
//Console.WriteLine(result);
#endregion

//var k = solution.ShiftGrid(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } },9);

//var k = solution.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });
int[] nums = new int[] { 5,1,1};
solution.NextPermutation(nums);
Console.WriteLine(String.Join(",", nums));