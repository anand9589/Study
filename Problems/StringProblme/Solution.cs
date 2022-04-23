namespace StringProblems
{
    public class Solution
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> result = new List<int>();

            if (string.IsNullOrEmpty(s) || words.Length == 0) return result;

            int wordLen = words[0].Length;
            int wordsCount = words.Length;

            if (s.Length < (wordLen * wordsCount)) return result;

            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (map.ContainsKey(word))
                {
                    map[word]++;
                }
                else
                {
                    map.Add(word, 1);
                }
            }

            int startIndex = 0;

            Dictionary<string, int> visitedmap = new Dictionary<string, int>();
            while (startIndex <= s.Length - (wordLen * wordsCount))
            {
                var sp = s.Substring(startIndex, wordLen);

                if (map.ContainsKey(sp))
                {
                    var s1 = s.Substring(startIndex, (wordLen * wordsCount));

                    if (VerifyString(map, s1, wordLen))
                    {
                        result.Add(startIndex);
                    }
                }
                startIndex++;
            }

            return result;
        }

        private bool VerifyString(Dictionary<string, int> dct, string s1, int wordLen)
        {
            Dictionary<string, int> map = new Dictionary<string, int>(dct);

            for(int i = 0; i < s1.Length; i=i+wordLen)
            {
                string sub = s1.Substring(i, wordLen);
                if (map.ContainsKey(sub) && map[sub]>0)
                {
                    map[sub]--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

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
