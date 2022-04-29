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
    }
}
