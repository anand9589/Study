namespace HackerRank
{
    public class Solution
    {
        public long repeatedString(string s, long n)
        {
            long result = 0;

            int len = s.Length;

            result = s.Count(x => x == 'a');

            long p = n % len;
            result = result * (n / len);

            if (p != 0)
            {
                for (long i = 0; i < p; i++)
                {
                    if (s[(int)i] == 'a') result++;
                }
            }

            return result;
        }

        public void checkMagazine(List<string> magazine, List<string> note)
        {
            Dictionary<string, long> counts = new Dictionary<string, long>();
            foreach (string n in note)
            {
                if (counts.ContainsKey(n))
                {
                    counts[n]++;
                }
                else
                {
                    counts.Add(n, 1);
                }
            }

            foreach (string n in magazine)
            {
                if (counts.ContainsKey(n))
                {
                    if (counts[n] == 1)
                    {
                        counts.Remove(n);
                    }
                    else
                    {
                        counts[n]--;
                    }
                }

                if(counts.Count == 0)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }

            Console.WriteLine("No");
        }

        public static string twoStrings(string s1, string s2)
        {
            return String.Empty;
        }
    }
}
