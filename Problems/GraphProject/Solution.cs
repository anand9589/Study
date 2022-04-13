namespace GraphProject
{
    internal class Solution
    {

        //isCycle(node, vis, dfsVis, V, adj)
        //{
        //    // Mark the current node to be visited in both vis and dfsvis.
        //    vis[node] = true;
        //    dfsVis[node] = true;
        //    // Loop for the current node and it's adjacents
        //    for (let j = 0; j < adj[node].length; j++)
        //    {
        //        // If the current adjacent to the node is not visited.
        //        if (!vis[adj[node][j]])
        //        {
        //            // Then recursively check cycle in it
        //            if (this.isCycle(adj[node][j], vis, dfsVis, V, adj)) return true;
        //            // if the current node is visited in vis check in dfs vis.    
        //        }
        //        else if (dfsVis[adj[node][j]])
        //        {
        //            return true;
        //        }
        //    }
        //    // If nothing returned backtrack by marking current node back to unvisited in dfsVis
        //    dfsVis[node] = false;
        //    return false;
        //}

        private bool isCycle(int nodeIndex, bool[] visiting, bool[] visited, List<List<int>> adj)
        {
            visiting[nodeIndex] = true;
            visited[nodeIndex] = true;

            for (int i = 0; i < adj[nodeIndex].Count; i++)
            {
                int index = adj[nodeIndex][i];
                if (!visiting[index])
                {
                    if (isCycle(index, visiting, visited, adj)) return true;
                }
                else if (visited[index])
                {
                    return true;
                }
            }
            visited[nodeIndex] = false;
            return false;
        }

        public List<int> bfsOfGraph(int V, List<List<int>> adj)
        {
            // Code here
            List<int> bfs = new List<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                int i = queue.Dequeue();

                foreach (var item in adj[i])
                {
                    queue.Enqueue(item);
                }

                if (!bfs.Contains(i)) bfs.Add(i);
            }

            for (int i = 0; i < V; i++)
            {
                if (!bfs.Contains(i)) bfs.Add(i);

                foreach (int c in adj[i])
                {
                    if (!bfs.Contains(i)) bfs.Add(i);
                }
            }
            return bfs;
        }

        public List<int> BFS_Graph(int V, List<List<int>> adj)
        {
            List<int> bfs = new List<int>();
            bool[] visited = new bool[V];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                int k = queue.Dequeue();

                if (!visited[k]) bfs.Add(k);

                visited[k] = true;

                foreach (var e in adj[k])
                {
                    if (!visited[e])
                    {
                        queue.Enqueue(e);
                    }
                }
            }
            return bfs;
        }

        public List<int> DFS_Graph(int V, List<List<int>> adj)
        {
            List<int> bfs = new List<int>();
            bool[] visited = new bool[V];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int k = stack.Pop();

                if (!visited[k]) bfs.Add(k);

                visited[k] = true;

                foreach (var item in adj[k])
                {
                    if (!visited[item])
                    {
                        stack.Push(item);
                    }
                }
            }

            return bfs;
        }

        public int numIslands(ref List<List<int>> grid)
        {
            // Code here
            int result = 0;
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Count; j++)
                {
                    if (process(ref grid, i, j))
                    {
                        result++;
                    }
                }
            }

            return result;
        }
        private bool process(ref List<List<int>> grid, int i, int j)
        {
            if (i < 0 || j < 0 || i >= grid.Count || j >= grid[i].Count || grid[i][j] != 1) return false;

            grid[i][j] = 2;
            process(ref grid, i - 1, j);
            process(ref grid, i + 1, j);
            process(ref grid, i, j - 1);
            process(ref grid, i, j + 1);

            return true;

        }

        public int minSwaps(int[] nums)
        {
            KeyValuePair<int, int>[] pairs = new KeyValuePair<int, int>[nums.Length];
            // Code here
            for (int i = 0; i < nums.Length; i++)
            {
                pairs[i] = new KeyValuePair<int, int>(i, nums[i]);
            }

            pairs = pairs.OrderBy(x => x.Value).ToArray();
            int swapCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                while (pairs[i].Key != i)
                {
                    KeyValuePair<int, int> kv = pairs[i];
                    swapCount++;
                    swap(i, kv.Key, pairs);
                }
            }
            return swapCount;
        }

        private void swap(int i, int key, KeyValuePair<int, int>[] pairs)
        {
            var temp = pairs[i];
            pairs[i] = pairs[key];
            pairs[key] = temp;
        }

        //Function to return list containing vertices in Topological order. 
        public List<int> topoSort(int V, List<List<int>> adj)
        {
            //code here
            List<int> list = new List<int>();
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++)
            {
                topo(adj, ref stack, visited, i);
            }
            return stack.ToList();
        }

        private static void topo(List<List<int>> adj, ref Stack<int> stack, bool[] visited, int i)
        {
            if (!visited[i])
            {
                visited[i] = true;
                foreach (var item in adj[i])
                {
                    topo(adj, ref stack, visited, item);
                }
                stack.Push(i);
            }
        }

        //Function to find sum of weights of edges of the Minimum Spanning Tree.
        public int spanningTree(int V, ref List<List<List<int>>> adj)
        {
            // code here
            Dictionary<int, int> dict = new Dictionary<int, int>();
            Dictionary<int, int> dict2 = new Dictionary<int, int>();

            for (int i = 0; i < V; i++)
            {
                dict2.Add(i, int.MaxValue);
            }

            dict2[0] = 0;

            while (dict2.Count > 0)
            {
                var minkv = dict2.OrderBy(x => x.Value).FirstOrDefault();
                dict2.Remove(minkv.Key);

                dict.Add(minkv.Key, minkv.Value);

                foreach (var k in adj[minkv.Key])
                {
                    if (dict2.ContainsKey(k[0]))
                    {
                        dict2[k[0]] = Math.Min(dict2[k[0]], k[1]);
                    }
                }
            }
            return dict.Values.Sum();
        }

        //from the source vertex S.
        public List<int> dijkstra(int V, ref List<List<List<int>>> adj, int S)
        {
            //code here
            List<int> result = new List<int>();
            Dictionary<int, int> dicTemp = new Dictionary<int, int>();
            Dictionary<int, int> dicVisited = new Dictionary<int, int>();

            for (int i = 0; i < V; i++)
            {
                dicTemp[i] = int.MaxValue;
            }
            dicTemp[S] = 0;
            //dicVisited.Add(S, 0);

            while (dicTemp.Count > 0)
            {
                var d = dicTemp.OrderBy(x => x.Value).FirstOrDefault();

                dicTemp.Remove(d.Key);

                dicVisited.Add(d.Key, d.Value);

                int distance = d.Value;
                foreach (var lst in adj[d.Key])
                {
                    if (dicTemp.ContainsKey(lst[0])) dicTemp[lst[0]] = Math.Min(dicTemp[lst[0]], distance + lst[1]);
                }
            }

            return dicVisited.OrderBy(x => x.Key).ToDictionary(y => y.Key, y => y.Value).Values.ToList();

        }

        //// Function to detect cycle in a directed graph.
        //isCyclic(V, adj)
        //{
        //    // define the identifiers required
        //    // Create a vis array to keep track of all nodes visited overall.
        //    let visited = new Array(V).fill(false);
        //    // Create a dfs visited array to check if the curr node was visited in the same cycle or not
        //    let dfsVisited = new Array(V).fill(false);

        //    // Loop for all components/vertices of graphs
        //    for (let i = 0; i < V; i++)
        //    {
        //        // Check if the curr node is visited or not visited.
        //        // If not visited.. then call cycle check.
        //        if (!visited[i])
        //        {
        //            if (this.isCycle(i, visited, dfsVisited, V, adj)) return true;
        //        }
        //    }
        //    // In case true isn't returned thus no cycle found.
        //    return false;
        //}

        public bool isCyclic(int V, List<List<int>> adj)
        {
            bool[] visiting = new bool[V];
            bool[] visited = new bool[V];

            for (int i = 0; i < V; i++)
            {
                if (!visiting[i])
                {
                    if (isCycle(i, visiting, visited, adj)) return true;
                }
            }
            return false;
        }
        //public bool isCyclic(int V, List<List<int>> adj)
        //{
        //    bool[] visited = new bool[V];
        //    bool[] completed = new bool[V];
        //    int startNode = 0;
        //    Queue<int> queue = new Queue<int>();    
        //    queue.Enqueue(startNode);

        //    while(queue.Count > 0)
        //    {
        //        int curr = queue.Dequeue();
        //        if (!completed[curr])
        //        {
        //            visited[curr] = true;
        //            for (int i = 0; i < adj[curr].Count; i++)
        //            {

        //                if (visited[adj[curr][i]])
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    queue.Enqueue(adj[curr][i]);
        //                    visited[adj[curr][i]] = true;
        //                }
        //            }

        //            visited[curr] = false;
        //            completed[curr] = true;

        //            while (queue.Count == 0 && startNode < V && completed[startNode])
        //            {
        //                startNode++;
        //            }
        //            if (queue.Count == 0)
        //            {
        //                queue.Enqueue(startNode);
        //            }
        //            visited[curr] = false;
        //        }
        //    }
        //    return false;
        //}
        //// Function to detect cycle in a directed graph.
        //public bool isCyclic(int V, List<List<int>> adj)
        //{
        //    bool[] visitingArr = new bool[V];
        //    bool[] vistedArr = new bool[V];

        //    for (int i = 0; i < V; i++)
        //    {
        //        if (!vistedArr[i])
        //        {
        //            bool res = isCyclic_V1(adj, i, vistedArr, visitingArr);
        //            if (res)
        //            {
        //                return res;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //private bool isCyclic_V1(List<List<int>> adj, int i, bool[] vistedArr, bool[] visitingArr)
        //{
        //    if(adj[i].Count == 0)
        //    {
        //        vistedArr[i] = true;
        //        return false;
        //    }
        //    visitingArr[i] = true;
        //    if (vistedArr[i]) return false;
        //    for (int j = 0; j < adj[i].Count; j++)
        //    {
        //        if (isCyclic_V1(adj, adj[i][j], vistedArr, visitingArr))
        //        {
        //            return true;
        //        }
        //        vistedArr[adj[i][j]] = true;
        //    }

        //    vistedArr[i] = true;
        //    visitingArr[i] = false;
        //    return false;
        //}

        //private bool isCyclic1(int i, bool[] arr, List<List<int>> adj)
        //{
        //    if (arr[i]) return true;
        //    arr[i] = true;
        //    for (int j = 0; j < adj[i].Count; j++)
        //    {
        //        return isCyclic1(adj[i][j], arr, adj);
        //    }
        //    arr[i] = false;
        //    return false;
        //}


        //Function to find out minimum steps Knight needs to reach target position.
        public int minStepToReachTarget(ref List<int> KnightPos, ref List<int> TargetPos, int N)
        {
            // Code here
            int[][] visited = new int[N][];
            for (int i = 0; i < N; i++)
            {
                visited[i] = new int[N];
                for (int j = 0; j < N; j++)
                {
                    visited[i][j] = -1;
                }
            }
            Queue<int[]> queue = new Queue<int[]>();

            queue.Enqueue(new int[] { KnightPos[0], KnightPos[1] });
            visited[KnightPos[0] - 1][KnightPos[1] - 1] = 0;
            bool reachToTarget = false;
            while (queue.Count > 0 && !reachToTarget)
            {
                var kv = queue.Dequeue();

                exploreNextPossibleMoves(queue, visited, kv[0], kv[1], N);

                if (kv[0] == TargetPos[0] && kv[1] == TargetPos[1]) return visited[kv[0] - 1][kv[1] - 1];
            }
            return 0;
        }

        private void exploreNextPossibleMoves(Queue<int[]> queue, int[][] visited, int x, int y, int n)
        {
            //visited[x - 1][y - 1]++;
            updateCoordinates(queue, visited, x - 2, y + 1, n, visited[x - 1][y - 1] + 1);
            updateCoordinates(queue, visited, x - 2, y - 1, n, visited[x - 1][y - 1] + 1);
            updateCoordinates(queue, visited, x - 1, y - 2, n, visited[x - 1][y - 1] + 1);
            updateCoordinates(queue, visited, x + 1, y - 2, n, visited[x - 1][y - 1] + 1);
            updateCoordinates(queue, visited, x + 2, y - 1, n, visited[x - 1][y - 1] + 1);
            updateCoordinates(queue, visited, x + 2, y + 1, n, visited[x - 1][y - 1] + 1);
            updateCoordinates(queue, visited, x + 1, y + 2, n, visited[x - 1][y - 1] + 1);
            updateCoordinates(queue, visited, x - 1, y + 2, n, visited[x - 1][y - 1] + 1);
        }

        private static void updateCoordinates(Queue<int[]> queue, int[][] visited, int x, int y, int n, int cost)
        {
            if (x > 0 && x <= n && y > 0 && y <= n && visited[x - 1][y - 1] == -1)
            {
                visited[x - 1][y - 1] = cost;
                queue.Enqueue(new int[] { x, y });
            }
        }
    }
}
