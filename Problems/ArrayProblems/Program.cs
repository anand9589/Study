﻿// See https://aka.ms/new-console-template for more information
using ArrayProblems;

Solution solution = new Solution();

#region 132Pattern
bool result = solution.Find132Pattern(new int[] { 3, 1, 4, 2 });
Console.WriteLine(result);
result = solution.Find132Pattern(new int[] { 1,2,3,4 });
Console.WriteLine(result);
#endregion