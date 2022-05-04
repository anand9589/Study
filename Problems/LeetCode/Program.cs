// See https://aka.ms/new-console-template for more information

using LeetCode;
//[10,1,2,7,6,1,5]
//8
//IList<IList<string>> eq = new List<IList<string>>();
//eq.Add(new List<string>() { "a", "b" });
//eq.Add(new List<string>() { "b", "c" });
//double[] val = new double[] { 2.0, 3.0 };
//IList<IList<string>> queries = new List<IList<string>>();
//queries.Add(new List<string>() { "a", "c" });
//queries.Add(new List<string>() { "b", "a" });
//queries.Add(new List<string>() { "a", "e" });
//queries.Add(new List<string>() { "a", "a" });
//queries.Add(new List<string>() { "x", "x" });
//2.00000
//- 2147483648
Solution solution = new Solution();
//var res = solution.UniquePathsWithObstacles(new int[][] { new int[] { 0, 0 } }/*, 0 }, new int[] { 0, 1, 0 },new int[] { 0, 0, 0 }}*/);
//var res = solution.MinPathSum(new int[][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } });
//var res = solution.MinDistance("mart", "karma");

var res = solution.NextGreaterElement(1999999999);
Console.WriteLine(res);