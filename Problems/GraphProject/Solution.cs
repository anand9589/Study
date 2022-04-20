using System.Text;

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
        public int RomanToInt(String s)
        {
            Dictionary<string, int> dct = new Dictionary<string, int>();
            dct.Add("M", 1000);
            dct.Add("CM", 900);
            dct.Add("D", 500);
            dct.Add("CD", 400);
            dct.Add("C", 100);
            dct.Add("XC", 90);
            dct.Add("L", 50);
            dct.Add("XL", 40);
            dct.Add("X", 10);
            dct.Add("IX", 9);
            dct.Add("V", 5);
            dct.Add("IV", 4);
            dct.Add("I", 1);
            int startIndex = 0;
            int result = 0;
            //char[] prevCheck = new char[] {'I','X','C',}
            //while (startIndex<s.Length)
            //{

            //    if (startIndex<s.Length-1 && dct.ContainsKey(s.Substring(startIndex, 2))){

            //        int val = dct[s.Substring(startIndex,2)];
            //        result += val;
            //        startIndex += 2;
            //    }
            //    else
            //    {
            //        int val = dct[s.Substring(startIndex,1)];
            //        result += val;
            //        startIndex++;
            //    }
            //}

            foreach (var k in dct.Keys)
            {
                while (s.StartsWith(k))
                {
                    result += dct[k];
                    s = s.Remove(0, k.Length);
                }
            }
            return result;
        }

        public string IntToRoman(int num)
        {
            if (num < 1) return "";
            if (num > 3999) return "";

            Dictionary<string, int> dct = new Dictionary<string, int>();
            dct.Add("M", 1000);
            dct.Add("CM", 900);
            dct.Add("D", 500);
            dct.Add("CD", 400);
            dct.Add("C", 100);
            dct.Add("XC", 90);
            dct.Add("L", 50);
            dct.Add("XL", 40);
            dct.Add("X", 10);
            dct.Add("IX", 9);
            dct.Add("V", 5);
            dct.Add("IV", 4);
            dct.Add("I", 1);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var k in dct.Keys)
            {
                while (num >= dct[k])
                {
                    stringBuilder.Append(k);
                    num -= dct[k];
                }
            }
            //int lev = 0;
            //while (num >0)
            //{
            //    int rem = num % 10;

            //    int x = rem * (int)(Math.Pow(10, lev));
            //    if (dct.ContainsValue(x))
            //    {
            //        stringBuilder.Insert(0, dct.Keys.FirstOrDefault(y=>dct[y]==x));
            //    }
            //    else
            //    {
            //        var kv = dct.Where(y => y.Value < x).LastOrDefault();
            //        string ss = kv.Key;

            //    }
            //    lev++;
            //    num = num / 10;
            //}

            return stringBuilder.ToString();
        }
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

        public int LengthOfLongestSubstring(string s)
        {
            //s=s.Trim();
            if (s.Length == 0) return 0;
            int len = 0;
            int tempLen = 0;
            int index = 0;
            int startIndex = 0;
            Dictionary<char, int> dct = new Dictionary<char, int>();
            while (index < s.Length)
            {
                if (!dct.ContainsKey(s[index]))
                {
                    dct.Add(s[index], index);
                    tempLen++;
                    index++;
                }
                else
                {
                    len = Math.Max(len, tempLen);
                    tempLen = 0;
                    startIndex = dct[s[index]];

                    index = startIndex + 1;
                    startIndex = index;
                    dct.Clear();
                }
            }
            //Console.WriteLine(tempLen);
            len = Math.Max(len, tempLen);
            return len;

        }

        public int MyAtoi(string s)
        {
            s = s.Trim();

            List<char> list = s.ToList();
            bool isNegative = false;
            if (list[0] == '-')
            {
                list.RemoveAt(0);
                isNegative = true;
            }
            else if (list[0] == '+')
            {
                list.RemoveAt(0);
            }
            int res = 0;

            while (list.Count > 0)
            {
                if (list[0] >= 48 && list[0] <= 57)
                {
                    int lstDigit = list[0] - (int)'0';

                    if (res > int.MaxValue / 10 || (res == int.MaxValue / 10) && lstDigit > 7) return isNegative ? int.MinValue : int.MaxValue;
                    res = (res * 10) + lstDigit;
                    list.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }

            return isNegative ? -1 * res : res;
        }

        public TreeNode IncreasingBST(TreeNode root)
        {
            List<int> lst = new List<int>();

            inorder(root, lst);

            TreeNode temp = new TreeNode(0);

            TreeNode curr = temp;

            foreach (var item in lst)
            {
                curr.right = new TreeNode(item);
                curr = curr.right;
            }
            return temp.right;
        }

        private void inorder(TreeNode root, List<int> values)
        {
            if (root == null) return;

            inorder(root.left, values);
            values.Add(root.val);
            inorder(root.right, values);
        }

        public string DigitSum(string s, int k)
        {
            while (s.Length > k)
            {
                List<int> res = new List<int>();
                int c = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if (i != 0 && i % 3 == 0)
                    {
                        res.Add(c);
                        c = 0;
                    }
                    c = c + (s[i] - (int)'0');
                }

                res.Add((int)c);

                s = String.Join(string.Empty, res);

                // int sum = res.Sum();

                // s = sum.ToString();
            }

            return s;
        }

        public void RecoverTree(TreeNode root)
        {
            TreeNode first = null;
            TreeNode second = null;
            TreeNode prev = null;
            //[3,1,4,null,null,2]
            while (root != null) //root 3 rl 1 rr 4
            {
                if (root.left == null)
                {
                    if (prev != null && prev.val > root.val)
                    {
                        if (first == null)
                        {
                            first = prev;
                        }
                        second = root;

                    }
                    prev = root;
                    root = root.right;
                }
                else
                {
                    TreeNode temp = root.left; //temp 1

                    while (temp.right != null && temp.right != root)
                    {
                        temp = temp.right;
                    }

                    if (temp.right == null)
                    {
                        temp.right = root;
                        root = root.left;
                    }
                    else
                    {
                        temp.right = null;

                        if (prev != null && prev.val > root.val)
                        {
                            if (first == null)
                            {
                                first = prev;
                            }
                            second = root;

                        }
                        prev = root;

                        root = root.right;
                    }
                }
            }

            int tem = first.val;
            first.val = second.val;
            second.val = tem;
        }
        public int MaxTrailingZeros(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    int x = grid[i][j];
                    int y = grid[i][j + 1];
                    int z = grid[i + 1][j];

                    if ((x * y) % 10 == 0)
                    {

                    }
                }
            }

            return 0;
        }

        public int MinimumRounds(int[] tasks)
        {
            int result = 0;

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < tasks.Length; i++)
            {
                if (map.ContainsKey(tasks[i]))
                {
                    map[tasks[i]]++;
                }
                else
                {
                    map.Add(tasks[i], 1);
                }
            }

            foreach (var item in map.Keys)
            {
                if (map[item] == 1) return -1;

                result = result + getMinimumRound(map[item]);
            }

            return result;
        }

        private int getMinimumRound(int v)
        {
            if (v <= 3) return 1;
            if (v <= 5) return 2;
            return 1 + getMinimumRound(v - 3);
        }

        public int Reverse(int x)
        {
            int result = 0;
            int pop = 0;

            while (x != 0)
            {
                pop = x % 10;
                x /= 10;

                if (result > int.MaxValue / 10 || result == int.MaxValue / 10 && pop > 7) return 0;
                if (result < int.MinValue / 10 || result == int.MinValue / 10 && pop < -8) return 0;

                result = (result * 10) + pop;
            }
            return result;
        }

        int sum = 0;

        public TreeNode ConvertBST(TreeNode root)
        {
            if (root == null) return null;

            ConvertBST(root.right);
            sum += root.val;
            root.val = sum;
            ConvertBST(root.left);

            return root;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode temp = new ListNode(0);
            ListNode l3 = temp;

            int c = 0;

            while (l1 != null || l2 != null)
            {
                int x = l1 != null ? l1.val : 0;
                int y = l2 != null ? l2.val : 0;

                int sum = x + y + c;

                c = sum / 10;
                int z = sum % 10;

                ListNode lastNode = new ListNode(z);
                l3.next = lastNode;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;

                l3 = l3.next;
            }

            if (c > 0)
            {
                ListNode l = new ListNode(c);
                l3.next = l;
                l3 = l3.next;
            }

            return temp.next;
        }

        public bool ValidPalindrome(string s)
        {
            if (s.Length == 1) return true;

            int startIndex = 0;
            int endIndex = s.Length - 1;

            while (startIndex < endIndex)
            {
                if (s[startIndex] != s[endIndex])
                {
                    return removeAndCheck(s, startIndex + 1, endIndex) || removeAndCheck(s, startIndex, endIndex - 1);
                }
                startIndex++;
                endIndex--;
            }
            return true;
        }

        private bool removeAndCheck(string s, int startIndex, int endIndex)
        {

            while (startIndex < endIndex)
            {
                if (s[startIndex] != s[endIndex]) return false;

                startIndex++;
                endIndex--;
            }

            return true;
        }

        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if (root == null) return null;

            if (root.val < low)
            {
                return TrimBST(root.right, low, high);
            }
            else if (root.val > high)
            {
                return TrimBST(root.left, low, high);
            }

            root.left = TrimBST(root.left, low, high);
            root.right = TrimBST(root.right, low, high);
            return root;
        }

        public string Convert1(string s, int numRows)
        {
            if (s.Length == 1 || numRows == 1) return s;
            //List<char[]> list = new List<char[]>();

            //for (int i = 0; i < numRows; i++)
            //{
            //    list.Add(new char[numRows]);
            //}
            //int index = 0;
            //int tx = 0, ty = 0;
            //while (index < s.Length)
            //{
            //    while (ty < numRows)
            //    {
            //        list[tx][ty] = s[index];
            //        ty++;
            //        index++;
            //    }

            //    while (tx>=0)
            //    {

            //    }
            //}

            List<List<char>> chars = new List<List<char>>();

            for (int i = 0; i < numRows; i++)
            {
                List<char> slist = new List<char>();
                int incrementor = 0;
                for (int j = i; j < s.Length + numRows;)
                {
                    if (i == 0 || i == numRows - 1)
                    {
                        if (!addToList(s, slist, j))
                        {
                            break;
                        }
                        j += ((numRows - 1) * 2);
                    }
                    else
                    {
                        if (j < numRows)
                        {
                            if (!addToList(s, slist, j))
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (!addToList(s, slist, j - i))
                            {
                                break;
                            }
                            if (!addToList(s, slist, j + i))
                            {
                                break;
                            }
                        }
                        incrementor = incrementor + ((numRows - 1) * 2);
                        j = incrementor;
                    }
                }

                chars.Add(slist);
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in chars)
            {
                foreach (var k in item)
                {
                    sb.Append(k);
                }
            }

            return sb.ToString();
        }

        private static bool addToList(string s, List<char> chars, int j)
        {
            if (j >= s.Length) return false;

            chars.Add(s[j]);
            return true;
        }

        public string LongestPalindrome(string s)
        {
            int start = 0;
            int end = 0;
            int len1 = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int len = checkFromMiddle(s, i, i);
                int len2 = checkFromMiddle(s, i, i + 1);
                if (len > len2)
                {
                    if (len > len1)
                    {
                        len1 = len;
                        start = i - (len / 2);
                        end = i + (len / 2);
                    }
                }
                else
                {
                    if (len2 > len1)
                    {
                        len1 = len2;
                        start = i - (len2 / 2) + 1;
                        end = i + (len2 / 2);
                    }
                }
            }

            return s.Substring(start, (end - start) + 1);
        }

        public int checkFromMiddle(string s, int left, int right)
        {
            if (s == null) return 0;
            int len = 0;
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                if (left == right)
                {
                    len = 1;
                }
                else
                {
                    len += 2;
                }
                left--;
                right++;
            }

            return len;
        }

        //Function to find number of strongly connected components in the graph.
        public int kosaraju(int V, ref List<List<int>> adj)
        {
            //code here
            bool[] visited = new bool[V];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    //visited[i] = true;

                    //foreach (var k in adj[i])
                    //{
                    //    visited[k] = true;
                    //}
                    visitChildNode(ref adj, i, stack);
                }
            }

            List<List<int>> newList = new List<List<int>>();
            for (int i = 0; i < V; i++)
            {
                newList.Add(new List<int>());
            }

            for (int i = 0; i < V; i++)
            {
                visited[i] = false;

                foreach (var k in adj[i])
                {
                    newList[k].Add(i);
                }
            }

            return 0;
        }

        private void visitChildNode(ref List<List<int>> adj, int k, Stack<int> stack)
        {

        }
    }
}
