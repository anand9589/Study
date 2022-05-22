// See https://aka.ms/new-console-template for more information

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
//var res = solution.UpdateMatrix(matrix);
//Console.WriteLine(res);
//solution.FloodFill(inputArray,sr,sc,newColor);
//ListNode last = new ListNode(5);
//last = new ListNode(4, last);
//last = new ListNode(3, last);
//last = new ListNode(2, last);
//last = new ListNode(1, last);
//last = new ListNode(0, last);

//solution.CoinChange(new int[] { 1, 2, 5 }, 9);
//solution.AddBinary("1010", "1011");
//[-1,0,3,5,9,12]
//0
//var p = solution.Search(new int[] { -1, 0, 3, 5, 9, 12 }, 0);
//Console.WriteLine(p);
//solution.SetZeroes(inputArray);]
//[91,54,63,99,24,45,78]
//[35,32,45,98,6,1,25]
///*17*/

//solution.MaximumBags(new int[] { 91, 54, 63, 99, 24, 45, 78 }, new int[] { 35, 32, 45, 98, 6, 1, 25 }, 17);

//var res = solution.TotalStrength(new int[] { 1, 3, 1, 2 });
var res = solution.ShortestBridge(matrix);
Console.WriteLine(res);