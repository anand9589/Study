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

                    if(arr[i] + arr[start] + arr[end] < X)
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
    }
}
