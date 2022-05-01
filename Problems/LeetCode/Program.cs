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
Solution solution = new Solution();
var res = solution.BackspaceCompare("ab#c", "ad#c");
Console.WriteLine(res);