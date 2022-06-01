// See https://aka.ms/new-console-template for more information

using LeetCode;
var data = File.ReadAllLines(@"C:\Workspace\Study\Problems\Practice.txt");

////int[][] input
var d = data[0].Split("],[");
char[][] matrix = new char[d.Length][];

for (int i = 0; i < d.Length; i++)
{
    d[i] = d[i].Replace("\"", "");
    string[] p = d[i].Split(",").ToArray();
    matrix[i] = new char[p.Length];
    for (int j = 0; j < p.Length; j++)
    {
        matrix[i][j] = p[j][0];
    }
}
//int[][] matrix = new int[d.Length][];

//for (int i = 0; i < d.Length; i++)
//{
//    d[i] = d[i].Replace("\"", "");
//    string[] p = d[i].Split(",").ToArray();
//    matrix[i] = new int[p.Length];
//    for (int j = 0; j < p.Length; j++)
//    {
//        matrix[i][j] = int.Parse(p[j]);
//    }
//}
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
//var res = solution.MakeConnected(6,matrix);
//["Hello userTwooo","Hi userThree","Wonderful day Alice","Nice day userThree"]
//["Alice","userTwo","userThree","Alice"]

//["tP x M VC h lmD","D X XF w V","sh m Pgl","pN pa","C SL m G Pn v","K z UL B W ee","Yf yo n V U Za f np","j J sk f qr e v t","L Q cJ c J Z jp E","Be a aO","nI c Gb k Y C QS N","Yi Bts","gp No g s VR","py A S sNf","ZS H Bi De dj dsh","ep MA KI Q Ou"]
//["OXlq","IFGaW","XQPeWJRszU","Gb","HArIr","Gb","FnZd","FnZd","HArIr","OXlq","IFGaW","XQPeWJRszU","EMoUs","Gb","EMoUs","EMoUs"]
//var res = solution.LargestWordCount(new string[] { "tP x M VC h lmD", "D X XF w V", "sh m Pgl", "pN pa", "C SL m G Pn v", "K z UL B W ee", "Yf yo n V U Za f np", "j J sk f qr e v t", "L Q cJ c J Z jp E", "Be a aO", "nI c Gb k Y C QS N", "Yi Bts", "gp No g s VR", "py A S sNf", "ZS H Bi De dj dsh", "ep MA KI Q Ou" }, new string[] { "OXlq", "IFGaW", "XQPeWJRszU", "Gb", "HArIr", "Gb", "FnZd", "FnZd", "HArIr", "OXlq", "IFGaW", "XQPeWJRszU", "EMoUs", "Gb", "EMoUs", "EMoUs" });

//var res = solution.MaximumImportance(5, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 0, 2 }, new int[] { 1, 3 }, new int[] { 2, 4 } });
//"$7383692 5q $5870426"
//64
//var res = solution.DiscountPrices("$7383692 5q $5870426", 64);
//var res = solution.TotalSteps(new int[] { 10, 1, 2, 3, 4, 5, 6, 1, 2, 3 });

var res = solution.Exist(matrix, "ABCESEEEFS");
Console.WriteLine(res);