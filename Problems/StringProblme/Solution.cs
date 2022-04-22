namespace StringProblems
{
    internal class Solution
    {

        public int IsContains(string s, string x)
        {
            for (int i = 0; i <= s.Length - x.Length; i++)
            {
                if (s[i] == x[0])
                {
                    bool isMatch = true;
                    for (int j = 1; j < x.Length; j++)
                    {
                        if (x[j] != s[i + j])
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
    }
}
