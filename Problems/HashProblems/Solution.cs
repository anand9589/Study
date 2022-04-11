namespace HashProblems
{
    internal class Solution
    {
        public int doUnion(int[] a, int[] b, int n, int m)
        {
            // Your code goes here

            return a.Union(b).Count();

        }

        public int findLongestConseqSubseq_v1(int[] arr, int n)
        {
            //Your code here
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (map.ContainsKey(arr[i]))
                {
                    map[arr[i]]++;
                }
                else
                {
                    map.Add(arr[i], arr[i]);
                }
            }
            int longestCount = 1;

            int oldKey = map.Keys.First();

            for (int i = 1; i < map.Keys.Count; i++)
            {
                int newKey = map.Keys.ElementAt(i);
                if (oldKey + 1 == newKey)
                {
                    longestCount++;
                }
                else
                {
                    longestCount = 1;
                }
                oldKey = newKey;
            }
            return longestCount;
        }


        public int findLongestConseqSubseq(int[] arr, int n)
        {
            Array.Sort(arr);

            int longestCount = 1;
            int maxLongestCount = 1;
            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] == arr[i + 1]) continue;
                if (arr[i + 1] - arr[i] == 1)
                {
                    maxLongestCount = Math.Max(maxLongestCount, ++longestCount);
                }
                else
                {
                    longestCount = 1;
                }
            }

            return maxLongestCount;
        }
        public bool find3Numbers(int[] arr, int n, int X)
        {
            //code here
            arr = arr.Where(x => x < X - 2).OrderBy(x => x).ToArray();
            n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                int start = i + 1;
                int end = n - 1;

                while (start < end)
                {
                    if (arr[i] + arr[start] + arr[end] == X)
                    {
                        return true;
                    }

                    if (arr[i] + arr[start] + arr[end] < X)
                    {
                        start++;
                    }
                    else
                    {
                        end--;
                    }
                }
            }
            return false;
        }

        public void frequencyCount(int[] arr, int N, int P)
        { //Your code here
            Dictionary<int, int> counts = new Dictionary<int, int>();

            for (int i = 0; i < N; i++)
            {
                if (arr[i] <= P)
                {

                    if (counts.ContainsKey(arr[i]))
                    {
                        counts[arr[i]]++;
                    }
                    else
                    {
                        counts.Add(arr[i], 1);
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                arr[i] = counts.ContainsKey(i + 1) ? counts[i + 1] : 0;
            }

        }
        public int firstRepeated(int[] arr, int n)
        {
            // Your code here
            Dictionary<int, int> count = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                if (count.ContainsKey(arr[i]))
                {
                    return arr[i];
                }
                else
                {
                    count.Add(arr[i], 1);
                }
            }
            return -1;
        }

        public int maxLen(int[] arr, int N)
        {
            // Your code here
            int longestSubArray = 0;
            int sum = 0;
            Dictionary<int, int> counts = new Dictionary<int, int>();

            for (int i = 0; i < N; i++)
            {
                if (arr[i] == 0)
                {
                    sum = sum - 1;
                }
                else
                {
                    sum = sum + 1;
                }
                if (sum == 0)
                {
                    longestSubArray = i + 1;
                }
                else
                {
                    if (counts.ContainsKey(sum))
                    {
                        int startIndex = counts[sum];

                        longestSubArray = Math.Max(longestSubArray, i - startIndex);
                    }
                    else
                    {
                        counts.Add(sum, i);
                    }
                }
            }

            return longestSubArray;
        }

        public int NumberofElementsInIntersection(int[] a, int[] b, int n, int m)
        {
            // Your code goes here
            //return a.
            return a.Intersect(b).Count();
        }
        public char nonrepeatingCharacter(string s)
        {
            //Your code here

            Dictionary<char, int> counts = new Dictionary<char, int>();


            foreach (char ch in s)
            {
                if (counts.ContainsKey(ch))
                {
                    counts[ch]++;
                }
                else
                {
                    counts.Add((char)ch, 1);
                }
            }

            foreach (var k in counts.Keys)
            {
                if (counts[k] == 1) return k;
            }

            return '$';
        }

        //Complete this function
        public string smallestWindow(string s, string p)
        {
            //Your code here
            Dictionary<char, int> charIndexs = new Dictionary<char, int>();
            Dictionary<char, int> char11 = new Dictionary<char, int>();
            for (int i = 0; i < p.Length; i++)
            {
                if (charIndexs.ContainsKey(p[i]))
                {
                    charIndexs[p[i]]++;
                }
                else
                {
                    charIndexs.Add(p[i], 1);
                    char11.Add(p[i], 0);
                }
            }

            int startIndex = 0;
            int endIndex = 0;
            int minLen = int.MaxValue;
            char[] ch = null;
            while (endIndex < s.Length)
            {
                if (char11.ContainsKey(s[endIndex]))
                {
                    char11[s[endIndex]]++;
                    while (getAllChars(char11, charIndexs))
                    {
                        if (endIndex - startIndex + 1 < minLen)
                        {
                            minLen = endIndex - startIndex + 1;
                            ch = s.Skip(startIndex).Take(minLen).ToArray();
                        }
                        if (char11.ContainsKey(s[startIndex]))
                        {
                            char11[s[startIndex]]--;
                        }
                        startIndex++;
                    }
                }


                endIndex++;
            }

            // var res = s.Skip(startIndex).Take(minLen).ToArray();

            return new String(ch);
        }

        public bool check(long[] A, long[] B, int n)
        {
            // Your code goes here
            Array.Sort(A);
            Array.Sort(B);
            for (int i = 0; i < n; i++)
            {
                if (A[i]!=B[i]) return false; 
            }
            return true;
        }

        private bool getAllChars(Dictionary<char, int> char11, Dictionary<char, int> charIndexs)
        {
            foreach (var k in char11.Keys)
            {
                if (char11[k] < charIndexs[k])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
