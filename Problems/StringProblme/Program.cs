using StringProblems;

//"wordgoodgoodgoodbestword"
//["word", "good", "best", "good"]

//string str1 = "wordgoodgoodgoodbestword";
//string[] words = new string[] { "word", "good", "best", "good" };
//[1,3,5,6]
//5
int[] nums = new int[] { 1,3,5,6 };
Solution solution = new Solution();
var result = solution.SearchInsert(nums, 7);
Console.WriteLine(result);