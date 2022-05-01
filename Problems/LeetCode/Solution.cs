using System.Text;

namespace LeetCode
{
    public class Solution
    {
        #region #38CountAndSay
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

        #region #39 CombinationSum

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

        #region #40 CombinationSum2
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

        #region #41 FirstMissingPositive
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

        #region #42 Trapping Rain Water
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

        #region #43 Multiply Strings

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
            permulteHelper(result, nums, 0);
            return result;
        }

        private void permulteHelper(IList<IList<int>> result, int[] nums, int start)
        {
            if (start == nums.Length)
            {
                result.Add(nums);
            }
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    swap(nums, start, i);
                    permulteHelper(result, nums, start + 1);
                    swap(nums, start, i);
                }
            }

        }

        private static void swap(int[] nums, int start, int i)
        {
            int temp = nums[i];
            nums[i] = nums[start];
            nums[start] = temp;
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
                    dic.Add(new String(ch), new List<int>() { i});   
                }
            }

            foreach (var item in dic.OrderBy(d=>d.Value.Count))
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

        #region #399  Evaluate Division

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, List<Node>> nodes = buildGraph(equations, values);
            double[] result = new double[queries.Count];

            for (int i = 0; i < queries.Count; i++)
            {
                result[i] = dfs(nodes, queries[i][0], queries[i][1], new HashSet<string>());
            }

            return result;
        }

        private double dfs(Dictionary<string, List<Node>> nodes, string src, string dest, HashSet<string> visited)
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

        private Dictionary<string, List<Node>> buildGraph(IList<IList<string>> equations, double[] values)
        {
            Dictionary<string, List<Node>> graph = new Dictionary<string, List<Node>>();

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

        private void updateGraph(Dictionary<string, List<Node>> graph, string key, string dest, double value)
        {
            Node node = new Node(dest, value);
            if (graph.ContainsKey(key))
            {
                graph[key].Add(node);
            }
            else
            {
                graph.Add(key, new List<Node>() { node });
            }
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

        #region #1423 MaxScore
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
    }
}
