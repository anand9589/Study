// See https://aka.ms/new-console-template for more information
using HashProblems;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines(@"C:\Workspace\Study\Problems\longestSubsequence.txt");

int n = int.Parse(lines[0]);
int[] arr = Array.ConvertAll(lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

Solution solution = new Solution();
var res = solution.findLongestConseqSubseq(arr, n);
