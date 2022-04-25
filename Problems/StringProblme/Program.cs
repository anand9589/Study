using StringProblems;

//"wordgoodgoodgoodbestword"
//["word", "good", "best", "good"]

//string str1 = "wordgoodgoodgoodbestword";
//string[] words = new string[] { "word", "good", "best", "good" };
//[5,1,2,3,4]
//1
int[] nums = new int[] { 1,3 };
Solution solution = new Solution();
var result = solution.SearchRange(nums, 1);
Console.WriteLine(result);