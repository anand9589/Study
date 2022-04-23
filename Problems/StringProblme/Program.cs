using StringProblems;

//"wordgoodgoodgoodbestword"
//["word", "good", "best", "good"]

string str1 = "wordgoodgoodgoodbestword";
string[] words = new string[] { "word", "good", "best", "good" };

Solution solution = new Solution();
var result = solution.FindSubstring(str1, words);
Console.WriteLine(result);