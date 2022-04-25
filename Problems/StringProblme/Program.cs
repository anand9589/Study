using StringProblems;

//"wordgoodgoodgoodbestword"
//["word", "good", "best", "good"]

//string str1 = "wordgoodgoodgoodbestword";
//string[] words = new string[] { "word", "good", "best", "good" };

//Solution solution = new Solution();
//var result = solution.FindSubstring(str1, words);
//Codec Codec = new Codec();
//var result = Codec.Encode("https://leetcode.com/problems/design-tinyurl");
//Console.WriteLine(result);
  
PeekingIterator peekingIterator = new PeekingIterator(GetData());
var p = peekingIterator.Next();

IEnumerator<int> GetData()
{
    for (int i = 1; i < 4; i++)
    {
        yield return i;
    }
}