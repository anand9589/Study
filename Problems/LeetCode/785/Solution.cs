namespace LeetCode._785
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
