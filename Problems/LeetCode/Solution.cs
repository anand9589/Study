using System.Text;

namespace LeetCode
{
    public class Solution
    {
        #region 38CountAndSay
        /// <summary>
        /// LeetCode #38
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay(int n)
        {
            if (n == 1) return "1";

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("1");
            for (int i = 2; i <= n; i++)
            {
                List<(char, int)> list = new List<(char, int)>();
                string s = stringBuilder.ToString();
                int k = 0;
                while (k < s.Length)
                {
                    var lastItem = list.LastOrDefault();

                    if (lastItem.Item1 == s[k])
                    {
                        int count = lastItem.Item2 + 1;
                        char c = s[k];
                        list[list.Count - 1] = (c, count);
                    }
                    else
                    {
                        list.Add((s[k], 1));
                    }
                    k++;
                }


                stringBuilder = new StringBuilder();
                for (int j = 0; j < list.Count; j++)
                {
                    stringBuilder.Append(list[j].Item2.ToString());

                    int n1 = (int)(list[j].Item1 - '0');

                    stringBuilder.Append(n1.ToString());
                }

            }

            return stringBuilder.ToString();
        }
        #endregion

        #region 39 CombinationSum

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();

            backtrack(result, new List<int>(), candidates, 0, target);

            return result;
        }

        private void backtrack(IList<IList<int>> result, List<int> list, int[] candidates, int start, int target)
        {
            if (target < 0) return;
            if (target == 0) result.Add(new List<int>(list));

            for (int i = start; i < candidates.Length; i++)
            {
                list.Add(candidates[i]);
                backtrack(result, list, candidates, i, target - candidates[i]);
                list.RemoveAt(list.Count - 1);
            }
        }

        #endregion

        #region 40 CombinationSum2
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates);
            backtrack2(result, new List<int>(), candidates, 0, target);

            return result;
        }

        private void backtrack2(IList<IList<int>> result, List<int> list, int[] candidates, int start, int target)
        {
            if (target < 0) return;
            if (target == 0)
            {
                result.Add(new List<int>(list));
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (i == start || candidates[i] != candidates[i - 1])
                {
                    list.Add(candidates[i]);
                    backtrack2(result, list, candidates, i + 1, target - candidates[i]);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
        #endregion

        #region 41 FirstMissingPositive
        public int FirstMissingPositive(int[] nums)
        {
            //List<int> rank = Enumerable.Range(1, nums.Length).ToList();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= 0 || nums[i] > nums.Length)
                {
                    nums[i] = nums.Length + 1;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int id = Math.Abs(nums[i]);

                if (id > nums.Length) continue;

                id--;

                if (nums[id] > 0) nums[id] = -nums[id];

            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0) return i + 1;
            }

            return nums.Length + 1;

            //return rank.Count == 0 ? nums.Length +1 : rank[0];
        }
        #endregion

        #region 42 Trapping Rain Water
        public int Trap(int[] height)
        {
            int n = height.Length;

            if (n <= 2) return 0;

            int result = 0;

            int start1 = 0;
            int end2 = n - 1;

            for (int i = 1; i < end2; i++)
            {
                if (height[i] >= height[start1])
                {
                    start1++;
                }
                else
                {
                    break;
                }
            }
            for (int i = end2 - 1; i > start1; i--)
            {
                if (height[i] >= height[end2])
                {
                    end2--;
                }
                else
                {
                    break;
                }
            }

            if (end2 - start1 <= 1) return 0;

            while (start1 < end2)
            {
                int end1 = -1;
                for (int i = start1 + 1; i < n; i++)
                {
                    if (height[i] >= height[start1])
                    {
                        end1 = i;

                        int min = Math.Min(height[start1], height[end1]);

                        for (int j = start1 + 1; j < end1; j++)
                        {
                            result += min - height[j];
                        }
                        start1 = i;
                    }
                }

                int start2 = -1;
                for (int i = end2 - 1; i >= start1; i--)
                {
                    if (height[i] >= height[end2])
                    {
                        start2 = i;

                        int min1 = Math.Min(height[start2], height[end2]);

                        for (int j = start2 + 1; j < end2; j++)
                        {
                            result += min1 - height[j];
                        }
                        end2 = i;
                    }

                }

            }


            return result;
        }
        #endregion

        #region 43 Multiply Strings

        public string Multiply(string num1, string num2)
        {
            while (num1.StartsWith("0"))
            {
                num1 = num1.Remove(0, 1);
                if (num1.Length == 0) return "0";
            }
            while (num2.StartsWith("0"))
            {
                num2 = num2.Remove(0, 1);
                if (num2.Length == 0) return "0";
            }
            int zeroCount = 0;
            List<StringBuilder> subresult = new List<StringBuilder>();
            StringBuilder result = new StringBuilder();
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int carryOn = 0;
                StringBuilder stringBuilder = new StringBuilder();
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    int n1 = num1[i] - '0';
                    int n2 = num2[j] - '0';

                    int ans = (n1 * n2) + carryOn;
                    StringBuilder res = new StringBuilder();
                    res.Append(ans);
                    if (res.Length > 1)
                    {
                        carryOn = res[0] - '0';
                        stringBuilder.Insert(0, res[1]);
                    }
                    else
                    {
                        carryOn = 0;
                        stringBuilder.Insert(0, res[0]);
                    }
                }
                if (carryOn > 0)
                {
                    stringBuilder.Insert(0, carryOn);
                }

                for (int k = 0; k < zeroCount; k++)
                {
                    stringBuilder.Append("0");
                }

                if (result.Length == 0)
                {
                    result.Append(stringBuilder.ToString());
                }
                else
                {
                    int ccc = 0;
                    StringBuilder ss = new StringBuilder();
                    for (int l = 0; l < stringBuilder.Length; l++)
                    {
                        StringBuilder stringBuilder1 = new StringBuilder();

                        int m1Index = stringBuilder.Length - 1 - l;
                        int m2Index = result.Length - 1 - l;
                        int m1 = m1Index >= 0 ? stringBuilder[m1Index] - '0' : 0;
                        int m2 = m2Index >= 0 ? result[m2Index] - '0' : 0;

                        int m3 = m1 + m2 + ccc;

                        stringBuilder1.Append(m3);

                        if (stringBuilder1.Length > 1)
                        {
                            ccc = stringBuilder1[0] - '0';
                            ss.Insert(0, stringBuilder1[1]);
                        }
                        else
                        {
                            ss.Insert(0, stringBuilder1.ToString());
                            ccc = 0;
                        }

                    }
                    if (ccc > 0)
                    {
                        ss.Insert(0, ccc);
                    }

                    result = new StringBuilder();
                    result.Append(ss);
                }
                subresult.Add(stringBuilder);
                zeroCount++;
            }

            return result.ToString();
        }

        #endregion

        #region 45. Jump Game II
        public int Jump(int[] nums)
        {
            int[] dp = Enumerable.Repeat(int.MaxValue, nums.Length).ToArray();
            int lastIndex = nums.Length - 1;

            dp[lastIndex] = 0;

            for (int i = lastIndex - 1; i >= 0; i--)
            {
                if (nums[i] + i >= lastIndex)
                {
                    dp[i] = 1;
                }
                else
                {
                    int min = i + 1;
                    for (int j = 2; j <= nums[i]; j++)
                    {
                        if (dp[min] > dp[j + i])
                        {
                            min = j + i;
                        }
                    }

                    dp[i] = 1 + dp[min];
                }
            }


            return dp[0];
        }
        #endregion

        #region 46. Permutations
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Permute_backtrack(result, nums, 0);
            return result;
        }

        private void Permute_backtrack(IList<IList<int>> result, int[] nums, int start)
        {
            if (start == nums.Length)
            {
                result.Add(new List<int>(nums));
                return;
            }
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    swap(i, start, nums);
                    Permute_backtrack(result, nums, start + 1);
                    swap(i, start, nums);
                }
            }
        }

        public IList<IList<int>> Permute_V2(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            LinkedList<int> ll = new LinkedList<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                ll.AddLast(nums[i]);
            }

            Permute_DFS(result, new LinkedList<int>(), ll);

            return result;
        }

        private void Permute_DFS(IList<IList<int>> result, LinkedList<int> linkedList, LinkedList<int> ll)
        {
            if (ll.Count == 0)
            {
                result.Add(new List<int>(linkedList.ToList()));
                return;
            }

            foreach (int n in ll)
            {
                LinkedList<int> temp1 = new LinkedList<int>(linkedList);
                LinkedList<int> temp2 = new LinkedList<int>(ll);

                temp1.AddLast(n);
                temp2.Remove(n);
                Permute_DFS(result, temp1, temp2);
            }
        }

        public IList<IList<int>> Permute_1(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Permute_Helper(result, new List<int>(), nums, 0, nums.Length);
            return result;
        }

        private void Permute_Helper(IList<IList<int>> list, IList<int> sublist, int[] nums, int start, int end)
        {
            if (start == end)
            {
                list.Add(new List<int>(sublist));

                return;
            }

            for (int i = start; i < end; i++)
            {
                sublist.Add(nums[i]);
                swap(i, start, nums);
                Permute_Helper(list, sublist, nums, start + 1, end);
                swap(i, start, nums);
                sublist.RemoveAt(sublist.Count - 1);
            }
        }
        #endregion

        #region 47. Permutations II
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            PermuteUnique_BackTrack(result, nums, 0);
            return result;
        }

        private void PermuteUnique_BackTrack(IList<IList<int>> result, int[] nums, int start)
        {
            if (start == nums.Length)
            {
                result.Add(new List<int>(nums));
                return;
            }
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    if (i != start && !canPermute(start, i, nums)) continue;
                    swap(i, start, nums);
                    PermuteUnique_BackTrack(result, nums, start + 1);
                    swap(i, start, nums);
                }
            }
        }

        private bool canPermute(int start, int i, int[] nums)
        {
            for (int j = start; j < i; j++)
            {
                if (nums[j] == nums[i]) return false;
            }
            return true;
        }
        #endregion
        #region 48. Rotate Image
        public void Rotate(int[][] matrix)
        {
            int[][] cp = new int[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                cp[i] = new int[matrix[i].Length];
                for (int j = 0; j < matrix.Length; j++)
                {
                    cp[i][j] = matrix[i][j];
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = cp[matrix.Length - j - 1][i];
                }
            }
        }
        #endregion

        #region 49. Group Anagrams
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Dictionary<string, IList<int>> dic = new Dictionary<string, IList<int>>();

            for (int i = 0; i < strs.Length; i++)
            {
                char[] ch = strs[i].ToCharArray();
                Array.Sort(ch);
                string s = new String(ch);
                if (dic.ContainsKey(s))
                {
                    dic[s].Add(i);
                }
                else
                {
                    dic.Add(new String(ch), new List<int>() { i });
                }
            }

            foreach (var item in dic.OrderBy(d => d.Value.Count))
            {
                List<string> list = new List<string>();
                foreach (var v in item.Value)
                {
                    list.Add(strs[v]);
                }
                result.Add(list);
            }

            //var c = strs.Select(
            //    (s, i) => new
            //    {
            //        s,
            //        i
            //    })
            //    .OrderBy(x => x.s.Length)
            //    .Select(y => new
            //    {
            //        a = new string(y.s.OrderBy(z => z).ToArray()),
            //        b = y.i
            //    });

            //result = c.GroupBy(x => x.a, elem => strs[elem.b])
            //                               .Select(g => (IList<string>)g.ToList()).ToList();

            return result;
        }
        #endregion

        #region 50. Pow(x, n)
        public double MyPow(double x, int n)
        {
            return powerHelper(x, n);
        }

        private double powerHelper(double x, int n)
        {
            if (n == 0) return 1.0;
            if (n == 1) return x;
            if (n == int.MinValue) return powerHelper(1 / x, int.MaxValue) * 1 / x;
            if (n < 0) return powerHelper((1 / x), -n);
            double result = powerHelper(x * x, n / 2);
            if (n % 2 == 1) result *= x;
            return result;
        }
        #endregion

        #region 53. Maximum Subarray
        public int MaxSubArray(int[] nums)
        {
            int max = nums.Max();
            int cur = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > cur + nums[i])
                {
                    cur = nums[i];
                }
                else
                {
                    cur += nums[i];
                }
                max = Math.Max(max, cur);
            }

            return max;
        }
        #endregion

        #region 54. Spiral Matrix
        public IList<int> SpiralOrder(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            bool[][] visited = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }

            IList<int> list = new List<int>();
            int x = 0;
            int y = n - 1;

            for (int i = x; i < n; i++)
            {
                list.Add(matrix[x][i]);
                visited[x][i] = true;
            }

            for (int i = 1; i < m; i++)
            {
                list.Add(matrix[i][y]);
                visited[i][y] = true;
            }

            return list;

            //while (true)
            //{
            //    while (y < n && !visited[x][y])
            //    {
            //        list.Add(matrix[x][y]);
            //        visited[x][y] = true;
            //        y++;
            //    }
            //    y = n - 1;
            //    x++;
            //    while (x < m)
            //    {
            //        list.Add(matrix[x][y]);
            //        visited[x][y] = true;
            //        x++;
            //    }
            //    x = m - 1;
            //    y--;

            //    while (y >= 0 && !visited[x][y])
            //    {
            //        list.Add(matrix[x][y]);
            //        visited[x][y] = true;
            //        y--;
            //    }
            //    y = 0;
            //    x--;
            //    while (x >= 0 && !visited[x][y])
            //    {
            //        list.Add(matrix[x][y]);
            //        visited[x][y] = true;
            //        x--;
            //    }
            //    m--;
            //    n--;
            //}
        }

        #endregion

        #region 55. Jump Game
        public bool CanJump(int[] nums)
        {
            if (nums[0] == 0) return false;

            int[] dp = new int[nums.Length];
            dp[nums.Length - 1] = 0;

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] + i >= nums.Length - 1)
                {
                    dp[i] = 1;
                }
                else
                {
                    for (int j = 1; j <= nums[i]; j++)
                    {
                        if (dp[i + j] > 0)
                        {
                            dp[i] = dp[i + j] + 1;
                            break;
                        }
                    }
                }
            }
            return dp[0] != 0;
        }
        #endregion

        #region 62. Unique Paths
        public int UniquePaths(int m, int n)
        {
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = Enumerable.Repeat(-1, n).ToArray();
            }
            return solveUniquePaths(dp, m - 1, n - 1);
        }

        private int solveUniquePaths(int[][] dp, int i, int j)
        {
            if (i == 0 && j == 0) return 1;

            if (i < 0 || j < 0) return 0;

            if (dp[i][j] != -1) return dp[i][j];

            dp[i][j] = solveUniquePaths(dp, i - 1, j) + solveUniquePaths(dp, i, j - 1);
            return dp[i][j];
        }
        #endregion

        #region 63. Unique Paths II
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            List<(int, int)> obstacles = new List<(int, int)>();
            for (int i = 0; i < obstacleGrid.Length; i++)
            {
                for (int j = 0; j < obstacleGrid[i].Length; j++)
                {
                    if (obstacleGrid[i][j] == 1) obstacles.Add((i, j));
                }
            }

            int[][] dp = new int[obstacleGrid.Length][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[obstacleGrid[i].Length];
            }
            bool fillZero = obstacles.Contains((0, 0));
            for (int j = 1; j < dp[0].Length; j++)
            {
                if (obstacles.Contains((0, j)) || fillZero)
                {
                    dp[0][j] = 0;
                    fillZero = true;
                }
                else
                {
                    dp[0][j] = 1;
                }
            }
            fillZero = obstacles.Contains((0, 0));
            for (int j = 1; j < dp.Length; j++)
            {
                if (obstacles.Contains((j, 0)) || fillZero)
                {
                    dp[j][0] = 0;
                    fillZero = true;
                }
                else
                {
                    dp[j][0] = 1;
                }
            }
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[i].Length; j++)
                {
                    if (obstacles.Contains((i, j)))
                    {
                        dp[i][j] = 0;
                    }
                    else
                    {
                        int leftVal = dp[i - 1][j];
                        int topVal = dp[i][j - 1];
                        dp[i][j] = leftVal + topVal;
                    }

                }
            }

            return dp[obstacleGrid.Length - 1][obstacleGrid[0].Length - 1];
        }
        #endregion

        #region 64. Minimum Path Sum
        public int MinPathSum(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (i == 0 && j == 0) continue;

                    grid[i][j] = getVal(grid, i, j);
                }
            }
            return grid[grid.Length - 1][grid[0].Length - 1];
        }

        private int getVal(int[][] grid, int i, int j)
        {
            int topval = j == 0 ? int.MaxValue : grid[i][j - 1];
            int leftVal = i == 0 ? int.MaxValue : grid[i - 1][j];

            return Math.Min(topval, leftVal) + grid[i][j];
        }
        #endregion

        #region 70. Climbing Stairs
        public int ClimbStairs(int n)
        {
            if (n <= 3) return n;

            int one = 2;
            int two = 3;

            for (int i = 4; i <= n; i++)
            {
                int temp = one + two;

                one = two;
                two = temp;
            }
            return two;
        }
        #endregion

        #region 72. Edit Distance
        public int MinDistance(string word1, string word2)
        {
            int i;
            int m = word1.Length;
            int n = word2.Length;
            int[][] dp = new int[m + 1][];

            for (i = 0; i <= m; i++)
            {
                dp[i] = new int[n + 1];
            }
            int j;
            int c;
            for (i = 0; i < m + 1; i++)
            {
                for (j = 0; j < n + 1; j++)
                {
                    c = int.MaxValue;
                    if (i == 0)
                    {
                        dp[i][j] = j;

                    }
                    else if (j == 0)
                    {
                        dp[i][j] = i;
                    }
                    if (i != 0 && j != 0)
                    {

                        if (word1[i - 1] == word2[j - 1])
                        {
                            dp[i][j] = dp[i - 1][j - 1];
                        }
                        if (word1[i - 1] != word2[j - 1])
                        {
                            c = Math.Min(c, dp[i - 1][j - 1]);
                            c = Math.Min(c, dp[i][j - 1]);
                            c = Math.Min(c, dp[i - 1][j]);
                            dp[i][j] = 1 + c;
                        }
                    }

                }
            }
            return dp[m][n];
            //if (word1.Length == 0) return word2.Length;

            //if (word2.Length == 0) return word1.Length;
            //int m = word1.Length;
            //int n = word2.Length;

            //int[][] dp = new int[m][];
            //for (int i = 0; i < m; i++)
            //{
            //    dp[i] = new int[n];
            //}
            //for (int i = 0; i < m; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        dp[i][j] = word1[i] == word2[j] ? 0 : 1;
            //    }
            //}

            //for (int i = 1; i < dp[0].Length; i++)
            //{
            //    dp[0][i] = dp[0][i - 1] + dp[0][i];
            //}

            //for (int i = 1; i < dp.Length; i++)
            //{
            //    dp[i][0] = dp[i - 1][0] + dp[i][0];
            //}
            //for (int i = 1; i < dp.Length; i++)
            //{
            //    for (int j = 1; j < dp[0].Length; j++)
            //    {
            //        dp[i][j] = getValue(dp, i, j);
            //    }
            //}

            //return dp[m - 1][n - 1];
        }

        private int getValue(int[][] dp, int i, int j)
        {

            int leftVal = dp[i][j - 1];
            int topVal = dp[i - 1][j];
            int diagoalVal = dp[i - 1][j - 1];

            int min = Math.Min(topVal, Math.Min(leftVal, diagoalVal));

            return min + dp[i][j];
        }

        private void dynamicUpdate(int[][] dp, int i, int j, ref int result)
        {
            if (i >= dp.Length || j >= dp[0].Length) return;

            if (dp[i][j] == 0)
            {
                dp[i][j] = result;

                if (i + 1 == dp.Length && j + 1 == dp[0].Length) return;

                if (i + 1 < dp.Length) i++;
                if (j + 1 < dp[0].Length) j++;

                dynamicUpdate(dp, i, j, ref result);
            }
            else
            {
                result = result + dp[i][j];

                dp[i][j] = result;


                if (i + 1 < dp.Length && dp[i + 1][j] == 0)
                {
                    dynamicUpdate(dp, i + 1, j, ref result);
                }
                else if (j + 1 < dp[0].Length && dp[i][j + 1] == 0)
                {
                    dynamicUpdate(dp, i, j + 1, ref result);
                }
                else if (i + 1 < dp.Length && j + 1 < dp[0].Length)
                {
                    dynamicUpdate(dp, i + 1, j + 1, ref result);
                }
                else if (i + 1 < dp.Length)
                {
                    dynamicUpdate(dp, i + 1, j, ref result);
                }
                else
                {
                    dynamicUpdate(dp, i, j + 1, ref result);
                }
            }
        }
        #endregion

        #region 85. Maximal Rectangle
        public int MaximalRectangle(char[][] matrix)
        {
            int[][] intArray = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                intArray[i] = new int[matrix[i].Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (i == 0)
                    {
                        intArray[i][j] = matrix[i][j] - '0';
                    }
                    else
                    {
                        if (matrix[i][j] != '0')
                        {
                            intArray[i][j] = intArray[i - 1][j] + matrix[i][j] - '0';
                        }
                    }
                }
            }


            return 0;
        }

        #endregion

        #region 94. Binary Tree Inorder Traversal
        public IList<int> InorderTraversal_ByStack(TreeNode root)
        {
            IList<int> list = new List<int>();

            if (root != null)
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);

                while (stack.Count > 0)
                {
                    TreeNode treeNode = stack.Peek();

                    if (treeNode.left != null)
                    {
                        stack.Push(treeNode.left);
                        treeNode.left = null;
                    }
                    else
                    {
                        list.Add(treeNode.val);
                        stack.Pop();
                        if (treeNode.right != null)
                        {
                            stack.Push((TreeNode)treeNode.right);
                            treeNode.right = null;
                        }
                    }
                }
            }

            return list;
        }


        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();

            if (root != null)
            {
                InorderTraversalHelper(list, root);
            }
            return list;
        }

        private void InorderTraversalHelper(IList<int> list, TreeNode root)
        {
            if (root == null) return;
            InorderTraversalHelper(list, root.left);
            list.Add(root.val);
            InorderTraversalHelper(list, root.right);
        }

        #endregion

        #region 98. Validate Binary Search Tree

        public bool IsValidBST(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null)) return true;
            if (root.left != null && root.val <= root.left.val)
            {
                return false;
            }
            if (root.right != null && root.val >= root.right.val)
            {
                return false;
            }
            return IsValidBSTHelper(root.left, root.val - 1) && IsValidBSTHelper(root.right, root.val + 1);
        }

        private bool IsValidBSTHelper(TreeNode treeNode, int maxVal)
        {
            return false;
            //if (treeNode == null) return true;
            //if ((treeNode.val < maxVal) || (treeNode.val > right)) return false;
            //return IsValidBSTHelper(treeNode.left, left, treeNode.val - 1) && IsValidBSTHelper(treeNode.right, treeNode.val + 1, right);
        }
        #endregion

        #region 100. Same Tree
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;

            if ((p == null && q != null) || (p != null && q == null)) return false;

            return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        #endregion

        #region 101. Symmetric Tree
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return IsSymmetricHelper(root.left, root.right);
        }

        private bool IsSymmetricHelper(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
                return left == right;
            if (left.val != right.val)
                return false;
            return IsSymmetricHelper(left.left, right.right) && IsSymmetricHelper(left.right, right.left);
        }
        #endregion

        #region 102. Binary Tree Level Order Traversal

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> level = new List<IList<int>>();

            if (root != null)
            {
                Queue<(int, TreeNode)> q = new Queue<(int, TreeNode)>();

                q.Enqueue((0, root));

                while (q.Count > 0)
                {
                    var d = q.Dequeue();
                    int l = d.Item1;
                    TreeNode treeNode = d.Item2;
                    if (level.Count == l)
                    {
                        level.Add(new List<int>());
                    }

                    level[l].Add(treeNode.val);

                    if (treeNode.left != null)
                    {
                        q.Enqueue((l + 1, treeNode.left));
                    }
                    if (treeNode.right != null)
                    {
                        q.Enqueue((l + 1, treeNode.right));
                    }
                }
            }
            return level;
        }

        #endregion

        #region 103. Binary Tree Zigzag Level Order Traversal

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> level = new List<IList<int>>();

            if (root != null)
            {
                Stack<(int, TreeNode)> stack1 = new Stack<(int, TreeNode)>();
                Stack<(int, TreeNode)> stack2 = new Stack<(int, TreeNode)>();

                stack1.Push((0, root));

                while (stack1.Count > 0 || stack2.Count > 0)
                {
                    while (stack1.Count > 0)
                    {
                        var t = stack1.Pop();
                        TreeNode treeNode = t.Item2;
                        int l = t.Item1;

                        if (level.Count == l)
                        {
                            level.Add(new List<int>());
                        }
                        else
                        {
                            level[l].Add((int)treeNode.val);
                        }

                        if (treeNode.left != null)
                        {
                            stack2.Push((l + 1, treeNode.left));
                        }

                        if (treeNode.right != null)
                        {
                            stack2.Push((l + 1, treeNode.right));
                        }

                    }

                    while (stack2.Count > 0)
                    {
                        var t = stack2.Pop();
                        TreeNode treeNode = t.Item2;
                        int l = t.Item1;

                        if (level.Count == l)
                        {
                            level.Add(new List<int>());
                        }
                        else
                        {
                            level[l].Add((int)treeNode.val);
                        }

                        if (treeNode.right != null)
                        {
                            stack1.Push((l + 1, treeNode.right));
                        }

                        if (treeNode.left != null)
                        {
                            stack1.Push((l + 1, treeNode.left));
                        }
                    }
                }
            }
            return level;
        }

        #endregion

        #region 104. Maximum Depth of Binary Tree
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            if (root.left == null && root.right == null) return 1;

            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }
        #endregion

        #region 107. Binary Tree Level Order Traversal II
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> level = new List<IList<int>>();

            if (root != null)
            {
                Queue<(int, TreeNode)> q = new Queue<(int, TreeNode)>();

                q.Enqueue((0, root));

                while (q.Count > 0)
                {
                    var d = q.Dequeue();
                    int l = d.Item1;
                    TreeNode treeNode = d.Item2;
                    if (level.Count == l)
                    {
                        level.Insert(0, new List<int>());
                    }

                    level[0].Add(treeNode.val);

                    if (treeNode.left != null)
                    {
                        q.Enqueue((l + 1, treeNode.left));
                    }
                    if (treeNode.right != null)
                    {
                        q.Enqueue((l + 1, treeNode.right));
                    }
                }
            }
            return level;
        }
        #endregion

        #region 111. Minimum Depth of Binary Tree
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            if (root.left == null && root.right == null) return 1;

            if (root.left == null)
            {
                return 1 + MinDepth(root.right);
            }
            else if (root.right == null)
            {
                return 1 + MinDepth(root.left);
            }
            else
            {

                return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
            }
        }
        #endregion

        #region 112. Path Sum

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            if (root.val == targetSum) return true;

            int val = root.val;

            if (root.left != null)
            {
                root.left.val += val;
                bool leftResult = HasPathSum(root.left, targetSum);
                if (leftResult)
                {
                    return true;
                }
            }
            if (root.right != null)
            {
                root.right.val += val;
                bool leftResult = HasPathSum(root.right, targetSum);
                if (leftResult)
                {
                    return true;
                }
            }
            return false;
        }



        #endregion

        #region 116. Populating Next Right Pointers in Each Node
        public Node Connect(Node root)
        {
            if (root != null)
            {
                Queue<(int, Node)> q = new Queue<(int, Node)>();
                q.Enqueue((0, root));

                while (q.Count > 0)
                {
                    var q1 = q.Dequeue();

                    int l = q1.Item1;
                    Node n = q1.Item2;


                    if (q.Count != 0 && q.Peek().Item1 == l)
                    {
                        n.Next = q.Peek().Item2;
                    }

                    if (n.Left != null) q.Enqueue((l + 1, n.Left));
                    if (n.Right != null) q.Enqueue((l + 1, n.Right));
                }
            }
            return root;
        }
        #endregion

        #region 216. Combination Sum III
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> list = new List<IList<int>>();

            CombinationSum3_Helper(list, new LinkedList<int>(), 1, k, n);

            return list;
        }

        private void CombinationSum3_Helper(IList<IList<int>> list, LinkedList<int> ll, int start, int k, int target)
        {
            if (k < 0 || target < 0)
            {
                return;
            }

            if (k == 0 && target == 0)
            {
                list.Add(ll.ToList());
                return;
            }

            for (int i = start; i <= 9; i++)
            {
                ll.AddLast(i);
                CombinationSum3_Helper(list, ll, i + 1, k - 1, target - i);
                ll.RemoveLast();
            }
        }
        #endregion

        #region 263. Ugly Number

        public bool IsUgly(int n)
        {
            return false;
        }

        #endregion

        #region 264. Ugly Number II
        public int NthUglyNumber(int n)
        {
            if (n == 1) return 1;
            List<int> list = new List<int>();
            list.Add(1);
            NthUglyNumber_helper(list, n, 2);
            return list.Last();
        }

        private void NthUglyNumber_helper(List<int> list, int n, int curr)
        {
            if (curr % 2 == 0 || curr % 3 == 0 || curr % 5 == 0)
            {
                list.Add((int)curr);
                if (list.Count == n) return;
            }

            NthUglyNumber_helper(list, n, curr + 1);

        }

        //private List<int> factors(int n)
        //{
        //    List<int> factors = new List<int>();

        //    for (int i = 2; i < length; i++)
        //    {

        //    }

        //    return factors;
        //}

        #endregion

        #region 399  Evaluate Division

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, List<Node_V1>> nodes = buildGraph(equations, values);
            double[] result = new double[queries.Count];

            for (int i = 0; i < queries.Count; i++)
            {
                result[i] = dfs(nodes, queries[i][0], queries[i][1], new HashSet<string>());
            }

            return result;
        }

        private double dfs(Dictionary<string, List<Node_V1>> nodes, string src, string dest, HashSet<string> visited)
        {

            if (!nodes.ContainsKey(src) || !nodes.ContainsKey(dest)) return -1.0;

            if (src == dest) return 1.0;

            visited.Add(src);

            foreach (var node in nodes[src])
            {
                if (!visited.Contains(node.Key))
                {

                    double ans = dfs(nodes, node.Key, dest, visited);

                    if (ans != -1.0)
                    {
                        return ans * node.Value;
                    }
                }
            }

            return -1.0;
        }

        private Dictionary<string, List<Node_V1>> buildGraph(IList<IList<string>> equations, double[] values)
        {
            Dictionary<string, List<Node_V1>> graph = new Dictionary<string, List<Node_V1>>();

            for (int i = 0; i < equations.Count; i++)
            {
                var equation = equations[i];
                string node1 = equation[0];
                string node2 = equation[1];

                double val = values[i];

                updateGraph(graph, node1, node2, val);
                updateGraph(graph, node2, node1, 1 / val);
            }

            return graph;
        }

        private void updateGraph(Dictionary<string, List<Node_V1>> graph, string key, string dest, double value)
        {
            Node_V1 node = new Node_V1(dest, value);
            if (graph.ContainsKey(key))
            {
                graph[key].Add(node);
            }
            else
            {
                graph.Add(key, new List<Node_V1>() { node });
            }
        }


        #endregion

        #region 456. 132 Pattern
        public bool Find132pattern(int[] nums)
        {
            if (nums.Length < 3) return false;
            int[] min = new int[nums.Length];
            min[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                min[i] = Math.Min(min[i - 1], nums[i]);
            }

            Stack<int> stack = new Stack<int>();

            for (int i = nums.Length - 1; i >= 0; i++)
            {
                if (nums[i] > min[i])
                {
                    while (stack.Count > 0 && stack.Peek() <= min[i])
                    {
                        stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() < nums[i]) return true;

                    stack.Push(nums[i]);
                }
            }
            return false;
        }
        #endregion

        #region 496. Next Greater Element I
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int[] dp = Enumerable.Repeat(-1, nums2.Length).ToArray();

            Stack<int> stack = new Stack<int>();
            stack.Push(nums2.Length - 1);
            for (int i = nums2.Length - 2; i >= 0; i--)
            {
                while (stack.Count > 0 && nums2[stack.Peek()] <= nums2[i])
                {
                    stack.Pop();
                }
                if (stack.Count == 0)
                {
                    dp[i] = -1;
                }
                else
                {
                    dp[i] = stack.Peek();
                }
                stack.Push(i);
            }

            int[] result = new int[nums1.Length];

            for (int i = 0; i < nums1.Length; i++)
            {
                int index = Array.IndexOf(nums2, nums1[i]);

                result[i] = dp[index] == -1 ? -1 : nums2[dp[index]];
            }

            return result;
        }
        #endregion

        #region 503. Next Greater Element II
        public int[] NextGreaterElements(int[] nums)
        {
            int[] result = new int[(int)nums.Length];

            int[] dp = new int[nums.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[stack.Peek()] <= nums[i])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    int k = nums[i];
                    int j = 0;
                    while (nums[j] <= k && j < i)
                    {
                        j++;
                    }
                    dp[i] = j == i ? -1 : j;
                }
                else
                {
                    dp[i] = stack.Peek();
                }
                stack.Push(i);
            }

            for (int i = 0; i < result.Length; i++)
            {
                if (dp[i] == -1)
                {
                    result[i] = -1;
                }
                else
                {
                    result[i] = nums[dp[i]];
                }
            }
            return result;
        }
        #endregion

        #region 556. Next Greater Element III
        public int NextGreaterElement(int n)
        {
            if (n == int.MaxValue) return -1;
            List<int> numlist = new List<int>();

            while (n > 0)
            {
                int rem = n % 10;
                numlist.Insert(0, rem);

                n /= 10;
            }
            int swapIndex = -1;
            for (int i = numlist.Count - 1; i > 0; i--)
            {
                if (numlist[i] > numlist[i - 1])
                {
                    if (numlist.Count == 10 && i == 1 && numlist[i] > 1) return -1;
                    swapIndex = i - 1;
                    break;
                }
            }
            if (swapIndex == -1) return -1;

            var p = numlist.Skip(swapIndex + 1).Take(numlist.Count - swapIndex).ToArray();
            Array.Sort(p);

            for (int i = 0; i < p.Length; i++)
            {
                if (numlist[swapIndex] < p[i])
                {
                    int temp = p[i];
                    p[i] = numlist[swapIndex];
                    numlist[swapIndex] = temp;
                    break;
                }
            }
            swapIndex++;
            for (int i = swapIndex; i < numlist.Count; i++)
            {
                numlist[i] = p[i - swapIndex];
            }
            int result = 0;

            foreach (var item in numlist)
            {
                result = (result * 10) + item;
            }

            return result < 0 ? -1 : result;
        }
        #endregion

        #region 581. Shortest Unsorted Continuous Subarray
        public int FindUnsortedSubarray(int[] nums)
        {
            if (nums.Length <= 1) return 0;

            if (nums.Length == 2)
            {
                if (nums[0] <= nums[1]) return 0;
                return 2;
            }

            int start = -1, end = -1, max = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (max > nums[i])
                {
                    if (start == -1)
                    {
                        start = i - 1;
                    }

                    while (start - 1 >= 0 && nums[start - 1] > nums[i]) start--;
                    end = i + 1;
                }
                else
                {
                    max = nums[i];
                }
            }
            return end - start;
        }

        #endregion

        #region 844. Backspace String Compare
        public bool BackspaceCompare(string s, string t)
        {
            s = ProcessString(s);
            t = ProcessString(t);
            return false;
        }

        private string ProcessString(string s)
        {
            StringBuilder sb = new StringBuilder();
            int backSpaceCount = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];
                if (c == '#')
                {
                    backSpaceCount++;
                }
                else
                {
                    if (backSpaceCount > 0) { backSpaceCount--; continue; }
                    sb.Insert(0, c);
                }
            }
            return sb.ToString();
        }
        #endregion

        #region 1209. Remove All Adjacent Duplicates in String II
        public string RemoveDuplicates(string s, int k)
        {
            Stack<(char, int, int)> stack = new Stack<(char, int, int)>();
            stack.Push((s[0], 1, 0));
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                if (top.Item2 == k)
                {
                    s = s.Remove(top.Item3, k);

                    if (stack.Count == 0 && s.Length > 0)
                    {
                        stack.Push((s[0], 1, 0));
                    }
                    continue;
                }


                int cIndex = top.Item3 + top.Item2;
                if (cIndex == s.Length) break;
                char c = s[cIndex];
                if (c == top.Item1)
                {
                    stack.Push((top.Item1, ++top.Item2, top.Item3));
                }
                else
                {
                    stack.Push(top);

                    stack.Push((c, 1, cIndex));
                }

            }
            return s;
        }
        #endregion

        #region 1423 MaxScore
        /// <summary>
        /// LeetCode #1423
        /// </summary>
        /// <param name="cardPoints"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxScore(int[] cardPoints, int k)
        {
            int sum = cardPoints.Sum();
            int length = cardPoints.Length;

            if (length == k) return sum;

            int frame = 0;
            int res = 0;

            for (int i = 0; i < length - k - 1; i++)
            {
                frame += cardPoints[i];
            }

            for (int i = length - k - 1; i < length; i++)
            {
                frame += cardPoints[i];

                res = Math.Max(res, sum - frame);

                frame -= cardPoints[i - (length - k - 1)];
            }

            return res;
        }
        #endregion

        #region 1641. Count Sorted Vowel Strings
        public int CountVowelStrings(int n)
        {
            List<List<int>> vowelStrings = new List<List<int>>();

            CountVowelStrings_helper(vowelStrings, new LinkedList<int>(), n, 1);

            return vowelStrings.Count;
        }

        private void CountVowelStrings_helper(List<List<int>> vowelStrings, LinkedList<int> ll, int n, int curr)
        {
            if (curr > 5) return;

            if (n == 0)
            {
                vowelStrings.Add(ll.ToList());
                return;
            }

            ll.AddLast(curr);

            CountVowelStrings_helper(vowelStrings, ll, n - 1, curr);
            ll.RemoveLast();

            CountVowelStrings_helper(vowelStrings, ll, n, curr + 1);
        }
        #endregion

        #region 1679. Max Number of K-Sum Pairs

        public int MaxOperations(int[] nums, int k)
        {
            Array.Sort(nums);
            int result = 0;
            List<int> list = new List<int>();

            int startIndex = 0;
            int endIndex = nums.Length - 1;

            while (startIndex < endIndex && nums[startIndex] < k)
            {
                if (nums[startIndex] + nums[endIndex] == k)
                {
                    list.Add(startIndex);
                    list.Add(endIndex);
                    result++;
                    startIndex++;
                    endIndex--;
                }
                else
                {
                    if (nums[startIndex] + nums[endIndex] > k)
                    {
                        endIndex--;
                    }
                    else
                    {
                        startIndex++;
                    }
                }
            }

            return result;
        }

        #endregion

        #region Bipartite Graph
        /// <summary>
        /// Union find
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite_V3(int[][] graph)
        {
            UF uf = new UF(graph.Length);

            for (int i = 0; i < graph.Length; i++)
            {
                foreach (var item in graph[i])
                {
                    if (uf.Find(item) == uf.Find(i)) return false;

                    uf.Union(item, graph[i][0]);
                }
            }
            return true;
        }

        /// <summary>
        /// BFS, Graph Coloring By Queue
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite_V2(int[][] graph)
        {
            int[] color = Enumerable.Repeat(0, graph.Length).ToArray();

            for (int i = 0; i < graph.Length; i++)
            {
                if (color[i] == 0)
                {
                    color[i] = 1;
                    Queue<int> q = new Queue<int>();
                    q.Enqueue(i);

                    while (q.Count > 0)
                    {
                        int n = q.Dequeue();

                        foreach (var item in graph[n])
                        {
                            if (color[n] == color[item]) return false;
                            else if (color[item] == 0)
                            {
                                q.Enqueue(item);
                                color[item] = -color[n];
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// DFS, Graph Coloring
        /// 0 - No
        /// -1 - Red
        /// 1 - Blue
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite_V1(int[][] graph)
        {
            int[] color = Enumerable.Repeat(0, graph.Length).ToArray();
            for (int i = 0; i < graph.Length; i++)
            {
                if (color[i] == 0 && !validColor(graph, color, 1, i)) return false;
            }
            return true;
        }

        private bool validColor(int[][] graph, int[] color, int c, int node)
        {
            if (color[node] != 0)
            {
                return color[node] == c;
            }

            color[node] = c;

            foreach (var item in graph[node])
            {
                if (!validColor(graph, color, -c, item)) return false;
            }

            return true;
        }

        #endregion

        #region 292week
        //Largest 3-Same-Digit Number in String
        public string LargestGoodInteger(string num)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < num.Length - 3; i++)
            {

                if (!list.Contains(num[i]) && num[i] == num[i + 1] && num[i] == num[i + 2])
                {
                    list.Add(num[i]);
                    i = i + 2;
                }
            }
            if (list.Count == 0) return "";
            char c = list.Max();
            return new string(new char[] { c, c, c });
        }

        public int CountTexts(string pressedKeys)
        {
            Dictionary<char, char[]> dct = new Dictionary<char, char[]>();

            dct.Add('2', new char[] { 'a', 'b', 'c' });
            dct.Add('3', new char[] { 'd', 'e', 'f' });
            dct.Add('4', new char[] { 'g', 'h', 'i' });
            dct.Add('5', new char[] { 'j', 'k', 'l' });
            dct.Add('6', new char[] { 'm', 'n', 'o' });
            dct.Add('7', new char[] { 'p', 'q', 'r' });
            dct.Add('8', new char[] { 's', 't', 'u', 'v' });
            dct.Add('9', new char[] { 'w', 'x', 'y', 'z' });

            return 0;
        }

        public bool HasValidPath(char[][] grid)
        {

            int m = grid.Length;
            int n = grid[0].Length;

            if (m > 0 && n > 0)
            {
                if (grid[m - 1][n - 1] != ')') return false;
            }

            return false;
        }

        public int AverageOfSubtree(TreeNode root)
        {
            List<(TreeNode, int, int)> results = new List<(TreeNode, int, int)>();
            Stack<(int, TreeNode)> stack = new Stack<(int, TreeNode)>();

            stack.Push((0, root));

            while (stack.Count > 0)
            {
                var s = stack.Peek();


            }
            return 0;
        }

        private int AverageOfSubtree_Tr(List<(TreeNode, int, int)> results, TreeNode root)
        {
            if (root == null) return 0;

            int left = AverageOfSubtree_Tr(results, root.left);
            int right = AverageOfSubtree_Tr(results, root.right);

            return 0;
        }

        #endregion


        private void swap(int i, int start, int[] nums)
        {
            if (i == nums.Length) return;
            int temp = nums[i];
            nums[i] = nums[start];
            nums[start] = temp;
        }
    }
}
