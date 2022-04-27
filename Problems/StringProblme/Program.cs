using StringProblems;

//"wordgoodgoodgoodbestword"
//["word", "good", "best", "good"]

//string str1 = "wordgoodgoodgoodbestword";
//string[] words = new string[] { "word", "good", "best", "good" };
//[1,3,5,6]
//5
//int[] nums = new int[] { 1,3,5,6 };
string str = "dcab";
IList<IList<int>> pairs = new List<IList<int>>();
pairs.Add(new List<int>() { 0, 3 }); pairs.Add(new List<int>() { 1, 2 }); pairs.Add(new List<int>() { 0, 2 });
Solution solution = new Solution();
var result = solution.SmallestStringWithSwaps(str, pairs);
Console.WriteLine(result);