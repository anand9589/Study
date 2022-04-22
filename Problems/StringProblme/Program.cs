using StringProblems;

string str1 = "abcabcabcd";
string str2 = "abcd";

Solution solution = new Solution();
int result = solution.IsContains(str1, str2);
Console.WriteLine(result);