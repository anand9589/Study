using System.Text;

namespace LeetCode
{

    class UF
    {
        private int[] parent;

        public UF(int size)
        {
            parent = Enumerable.Range(0, size).ToArray();
        }

        public void Union(int x, int y)
        {
            int px = Find(x);
            int py = Find(y);


            if (px != py)
            {
                parent[px] = y;
            }
        }

        public int Find(int x)
        {
            return parent[x] == x ? x : Find(parent[x]);
        }
    }
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
    }
}
