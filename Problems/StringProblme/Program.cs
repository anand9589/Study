string str1 = "abcabcabcd";
string str2 = "abcd";

int result = IsContains(str1, str2);
Console.WriteLine(result);
int IsContains(string s, string x)
{
    for (int i = 0; i <= s.Length - x.Length; i++)
    {
        if(s[i] == x[0])
        {
            bool isMatch = true;
            for (int j = 1; j < x.Length; j++)
            {
                if(x[j] != s[i + j])
                {
                    isMatch = false;
                    break;
                }
            }
            if (isMatch) return i;
        }
    }
    return -1;
}