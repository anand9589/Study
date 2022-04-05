using System.Diagnostics;
using TreeProblem.Classes;

namespace TreeProblem
{
    internal class Solution
    {
        public bool IsBST(Node root)
        {
            if (root == null) return true;
            // Your code here
            bool result = true;

            if (root.Left != null)
            {
                if (root.Left.Data > root.Data) return false;

                result = IsBST_Sub(root.Left, root.Data, true);
            }
            if (!result) return false;

            if (root.Right != null)
            {
                if (root.Data > root.Right.Data) return false;

                result = IsBST_Sub(root.Right, root.Data, false);
            }

            return result;

        }

        private bool IsBST_Sub(Node root, int rootData, bool isLeft)
        {
            if (root == null) return true;

            if (isLeft)
            {
                if (root.Data > rootData) return false;
            }
            else
            {
                if (root.Data < rootData) return false;
            }

            // Your code here
            bool result = true;

            if (root.Left != null)
            {
                if (root.Left.Data > root.Data) return false;

                result = IsBST_Sub(root.Left, rootData, isLeft);
            }
            if (!result) return false;

            if (root.Right != null)
            {
                if (root.Data > root.Right.Data) return false;

                result = IsBST_Sub(root.Right, rootData, isLeft);
            }

            return result;
        }

        public List<int> LeftView(Node root)
        {
            //code here
            List<int> result = new List<int>();
            int level = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            //List<int> list = new List<int>();
            result = GetLeftView(root, level, map);

            return result;
        }

        private List<int> GetLeftView(Node root, int level, Dictionary<int, int> map)
        {
            if (root == null) return new List<int>();

            if (!map.ContainsKey(level))
            {
                map.Add(level, root.Data);
            }
            level++;
            if (root.Left != null)
            {
                GetLeftView(root.Left, level, map);
            }
            if (root.Right != null)
            {
                GetLeftView(root.Right, level, map);
            }
            return map.Values.ToList();



        }

        public int Diameter(Node root)
        {
            //code here
            if (root == null) return 0;
            int leftHeight = root.Left == null ? 0 : GetHeight(root.Left, 1);
            int rightHeight = root.Right == null ? 0 : GetHeight(root.Right, 1);

            Console.WriteLine($"{root.Data} {leftHeight} {rightHeight}");
            return Math.Max(leftHeight + rightHeight + 1, Math.Max(Diameter(root.Left), Diameter(root.Right)));
        }

        public int GetHeight(Node root, int level)
        {
            if (root == null || (root.Left == null && root.Right == null)) return level;

            int leftHeight = level;
            int rightHeight = level;

            if (root.Left != null)
            {
                leftHeight = GetHeight(root.Left, level + 1);
            }

            if (root.Right != null)
            {
                rightHeight = GetHeight(root.Right, level + 1);
            }

            return Math.Max(leftHeight, rightHeight);
        }

        public int GetDiameter(Node root, int level)
        {

            int leftHeight = level;
            int rightHeight = level;

            if (root.Left != null)
            {
                leftHeight = GetHeight(root.Left, level + 1);
            }

            if (root.Right != null)
            {
                rightHeight = GetHeight(root.Right, level + 1);
            }

            return leftHeight + rightHeight + 1;
        }

        public bool IsBalanced(Node root)
        {
            //code here
            if (root == null) return true;
            int leftHeight = root.Left == null ? 0 : GetHeight(root.Left, 1);
            int rightHeight = root.Right == null ? 0 : GetHeight(root.Right, 1);

            return Math.Abs(leftHeight - rightHeight) < 2 && IsBalanced(root.Left) && IsBalanced(root.Right);
        }

        public bool IsIdenticalV1(Node r1, Node r2)
        {
            //code here


            if (r1 != null && r2 != null)
            {
                if (!r1.Data.Equals(r2.Data)) return false;
            }
            if (r1 == null && r2 != null) return false;
            if (r1 != null && r2 == null) return false;

            return true && IsIdenticalV1(r1.Left, r2.Left) && IsIdenticalV1(r1.Right, r2.Right);
        }

        //public List<int> topView(Node root)
        //{
        //    //Your code here
        //    List<int> top = new List<int>();
        //    List<Node> topLevelNodes = topLevelTraversal(root);

        //    Dictionary<int, List<Node>> map = vericalLevelTraversal(root);

        //    map = map.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

        //    foreach (var item in map.Keys)
        //    {
        //        if (map[item].Count == 0)
        //        {
        //            top.Add(map[item][0].data);
        //        }
        //        else
        //        {
        //            foreach (var val in topLevelNodes)
        //            {
        //                if (map[item].Contains(val))
        //                {
        //                    top.Add(val.data);
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    return top;
        //}

        public List<Node> TopLevelTraversal(Node root)
        {
            List<Node> topLevelTraversal = new List<Node>();

            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node n = queue.Dequeue();
                topLevelTraversal.Add(n);

                if (n.Left != null)
                {
                    queue.Enqueue(n.Left);
                }
                if (n.Right != null)
                {
                    queue.Enqueue(n.Right);
                }
            }

            return topLevelTraversal;
        }

        public List<int> VerticalOrder(Node root)
        {
            //Your code here
            List<int> verticalOrder = new List<int>();

            Queue<KeyValuePair<Node, int>> queue = new Queue<KeyValuePair<Node, int>>();
            SortedDictionary<int, List<Node>> map = new SortedDictionary<int, List<Node>>();

            queue.Enqueue(new KeyValuePair<Node, int>(root, 0));
            map.Add(0, new List<Node>() { root });
            while (queue.Count > 0)
            {
                InserNode(queue, map);

            }

            foreach (var k in map.Keys)
            {
                verticalOrder.AddRange(map[k].Select(x => x.Data));
            }
            return verticalOrder;
        }

        private void InserNode(Queue<KeyValuePair<Node, int>> queue, SortedDictionary<int, List<Node>> map)
        {
            var r = queue.Dequeue();



            int ld = r.Value - 1;
            int rd = r.Value + 1;

            InserNodeInMap(queue, map, r.Key.Left, r.Value - 1);
            InserNodeInMap(queue, map, r.Key.Right, r.Value + 1);
        }

        private void InserNodeInMap(Queue<KeyValuePair<Node, int>> queue, SortedDictionary<int, List<Node>> map, Node r, int distance)
        {
            if (r != null)
            {
                if (map.ContainsKey(distance))
                {
                    map[distance].Add(r);
                }
                else
                {

                    map.Add(distance, new List<Node>() { r });
                }
                queue.Enqueue(new KeyValuePair<Node, int>(r, distance));
            }
        }

        public bool IsSumTree(Node root)
        {
            if (root == null) return true;


            int ls, rs;

            ls = root.Left == null ? 0 : GetSum(root.Left);
            rs = root.Right == null ? 0 : GetSum(root.Right);

            return root.Data == ls + rs;
        }

        public int GetSum(Node root)
        {
            if (root == null) return 0;

            return GetSum(root.Left) + root.Data + GetSum(root.Right);
        }

        public Dictionary<int, List<Node>> VericalLevelTraversal(Node root)
        {
            List<int> lst = new List<int>();
            Queue<Node> q = new Queue<Node>();

            Dictionary<int, List<Node>> map = new Dictionary<int, List<Node>>();
            map.Add(0, new List<Node>() { root });
            q.Enqueue(root);
            while (q.Count > 0)
            {
                InsertNode(q, map);
            }

            return map;
        }

        private static void InsertNode(Queue<Node> q, Dictionary<int, List<Node>> map)
        {
            Node r = q.Dequeue();
            //int distance = 0;
            var distance = map.FirstOrDefault(x => x.Value.Contains(r)).Key;

            int ld = distance - 1;
            int rd = distance + 1;
            InsertNodeInMap(q, map, r.Left, ld);
            InsertNodeInMap(q, map, r.Right, rd);
        }

        private static void InsertNodeInMap(Queue<Node> q, Dictionary<int, List<Node>> map, Node r, int ld)
        {
            if (r != null)
            {
                if (map.ContainsKey(ld))
                {
                    map[ld].Add(r);
                }
                else
                {
                    map.Add(ld, new List<Node>() { r });
                }
                q.Enqueue(r);
            }
        }

        public int MaximumSumOfDistance(Node root)
        {
            int result = int.MinValue;
            Dictionary<Node, int[]> map = new Dictionary<Node, int[]>();
            Dictionary<Node, int> map1 = new Dictionary<Node, int>();
            Stack<Node> stack = new Stack<Node>();
            result = Recurs(root, result, map, map1, stack);

            return result;
        }

        private static int Recurs(Node root, int result, Dictionary<Node, int[]> map, Dictionary<Node, int> map1, Stack<Node> stack)
        {
            Node temp = root;
            stack.Push(temp);
            while (temp.Left != null)
            {
                temp = temp.Left;
                stack.Push(temp);
            }
            while (temp.Right != null)
            {
                temp = temp.Right;
                stack.Push(temp);
            }

            while (stack.Count != 0)
            {
                int maxResult = int.MinValue;
                temp = stack.Peek();

                if (!map.ContainsKey(temp))
                {
                    map.Add(temp, new int[] { 0, 0 });
                }

                if (temp.Left != null)
                {
                    map[temp][0] = map1[temp.Left];
                }

                if (temp.Right != null)
                {
                    //map[temp][1] = map1[temp.right];
                    if (map1.ContainsKey(temp.Right))
                    {
                        map[temp][1] = map1[temp.Right];
                    }
                    else
                    {
                        result = Recurs(temp.Right, result, map, map1, stack);
                    }
                }
                if (!map1.ContainsKey(temp))
                {
                    maxResult = temp.Data + map[temp].Sum();
                    result = Math.Max(result, maxResult);
                    maxResult = Math.Max(temp.Data, temp.Data + map[temp].Max());
                    map1.Add(temp, maxResult);
                    stack.Pop();
                }
            }

            return result;
        }

        public List<int> SpiralTraversal(Node root)
        {
            List<int> result = new List<int>();

            Stack<Node> stack1 = new Stack<Node>();
            Stack<Node> stack2 = new Stack<Node>();

            stack1.Push(root);

            while (stack1.Count != 0)
            {
                Node temp = stack1.Pop();
                result.Add(temp.Data);

                if (temp.Right != null)
                {
                    stack2.Push(temp.Right);
                }
                if (temp.Left != null)
                {
                    stack2.Push(temp.Left);
                }

                if (stack1.Count == 0)
                {
                    while (stack2.Count != 0)
                    {
                        temp = stack2.Pop();
                        result.Add(temp.Data);

                        if (temp.Left != null)
                        {
                            stack1.Push(temp.Left);
                        }
                        if (temp.Right != null)
                        {
                            stack1.Push(temp.Right);
                        }
                    }
                }
            }
            return result;
        }

        public void Mirror(Node root)
        {
            //code here
            if (root != null)
            {
                Mirror(root.Left);
                Mirror(root.Right);
                Node temp = root.Left;

                root.Left = root.Right;
                root.Right = temp;
            }
        }

        public List<int> LevelOrder(Node node)
        {
            if (node == null) return new List<int>();
            //code here
            List<int> result = new List<int>();

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Node n = queue.Dequeue();
                result.Add(n.Data);

                if (n.Left != null)
                {
                    queue.Enqueue(n.Left);
                }

                if (n.Right != null)
                {
                    queue.Enqueue(n.Right);
                }
            }

            return result;

        }

        public List<int> BottomView(Node root)
        {
            // Your Code Here
            List<int> result = new List<int>();

            if (root != null)
            {
                var topL = TraversalV1(root);
                var verL = TraversalV2(root);

                foreach (var k in verL.Keys.OrderBy(x => x))
                {
                    if (verL[k].Count == 1)
                    {
                        result.Add(verL[k][0].Data);
                    }
                    else
                    {
                        //for (int i = topL.Count - 1; i >= 0; i--)
                        //{
                        //    if (verL[k].Contains(topL[i]))
                        //    {
                        //        result.Add(topL[i].data);
                        //        break;
                        //    }
                        //}
                        result.Add(verL[k].Last().Data);
                    }
                }

            }

            return result;
        }

        public List<Node> TraversalV1(Node root)
        {
            List<Node> result = new List<Node>();
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node n = queue.Dequeue();

                result.Add(n);

                if (n.Left != null)
                {
                    queue.Enqueue(n.Left);
                }

                if (n.Right != null)
                {
                    queue.Enqueue(n.Right);
                }

            }

            return result;
        }

        public Dictionary<int, List<Node>> TraversalV2(Node root)
        {
            Dictionary<int, List<Node>> result = new Dictionary<int, List<Node>>();
            Queue<KeyValuePair<Node, int>> queue = new Queue<KeyValuePair<Node, int>>();

            queue.Enqueue(new KeyValuePair<Node, int>(root, 0));
            result.Add(0, new List<Node>() { root });
            while (queue.Count > 0)
            {
                KeyValuePair<Node, int> kv = queue.Dequeue();

                InsertNodeInResult(result, queue, kv.Key.Left, kv.Value - 1);
                InsertNodeInResult(result, queue, kv.Key.Right, kv.Value + 1);
            }
            return result;
        }

        //public List<int> InOrderTraversal(Node root)
        //{
        //    List<int> result = new List<int>();
        //    Queue<Node> queue = new Queue<Node>();
        //    queue.Enqueue(root);

        //    while (queue.Count > 0)
        //    {
        //        Node n = queue.Dequeue();
        //        result.Add(n.data);

        //        if (n.left != null)
        //        {
        //            queue.Enqueue(n.left);
        //        }
        //        if (n.right != null)
        //        {
        //            queue.Enqueue(n.right);
        //        }
        //    }
        //    return result;
        //}

        public List<int> PreOrderTraversal(Node root)
        {
            List<int> result = new List<int>();

            PreOrderTraverse(root, result);
            return result;
        }

        public void PreOrderTraverse(Node root, List<int> res)
        {
            if (root == null) return;
            res.Add(root.Data);
            PreOrderTraverse(root.Left, res);
            PreOrderTraverse(root.Right, res);
        }

        public List<int> PostOrderTraversal(Node root)
        {
            List<int> result = new List<int>();
            PostOrderTraverse(root, result);
            return result;
        }

        public void PostOrderTraverse(Node root, List<int> res)
        {
            if (root == null) return;
            PostOrderTraverse(root.Left, res);
            PostOrderTraverse(root.Right, res);
            res.Add(root.Data);
        }

        public List<int> InOrderTraversal(Node root)
        {
            List<int> result = new List<int>();
            InOrderTraverse(root, result);
            return result;
        }

        public void InOrderTraverse(Node root, List<int> res)
        {
            if (root == null) return;
            InOrderTraverse(root.Left, res);
            res.Add(root.Data);
            InOrderTraverse(root.Right, res);
        }

        //Function to return the lowest common ancestor in a Binary Tree.
        public Node LCA(Node root, int n1, int n2)
        {
            //code here

            if (root == null) return null;


            FindLCA(root, n1, n2);

            return lcaNode;
        }

        public bool IsSubTree(Node T, Node S)
        {
            //code here

            if (T == null) return false;
            if (S == null) return true;

            if (IsIdenticalV1(T, S))
            {
                return true;
            }

            return IsSubTree(T.Left, S) || IsSubTree(T.Right, S);
        }

        public List<int> RightView(Node root)
        {
            //code here
            List<int> result = new List<int>();
            Dictionary<int, List<Node>> map = new Dictionary<int, List<Node>>();
            Queue<KeyValuePair<Node, int>> queue = new Queue<KeyValuePair<Node, int>>();

            queue.Enqueue(new KeyValuePair<Node, int>(root, 0));
            map.Add(0, new List<Node>() { root });

            while (queue.Count > 0)
            {
                KeyValuePair<Node, int> kv = queue.Dequeue();

                if (kv.Key.Left != null)
                {
                    InserElementInMap(map, queue, kv.Key.Left, kv.Value + 1);
                }
                if (kv.Key.Right != null)
                {
                    InserElementInMap(map, queue, kv.Key.Right, kv.Value + 1);
                }
            }

            foreach (var k in map.Keys)
            {
                result.Add(map[k].Last().Data);
            }
            return result;
        }

        //public bool isSubTree(Node T, Node S)
        //{
        //    //code here
        //    Node temp = T;
        //    Stack<Node> stack = new Stack<Node>();
        //    stack.Push(T);
        //    bool result = false;
        //    while (stack.Count > 0)
        //    {
        //        temp = stack.Pop();
        //        if (temp.data == S.data)
        //        {
        //            if (isSubPart(temp, S))
        //            {
        //                result = true;
        //                break;
        //            }
        //        }
        //        if (temp.left != null) stack.Push(temp.left);
        //        if (temp.right != null) stack.Push(temp.right);
        //    }

        //    return result;
        //}

        Node prev = null;
        //Function to convert binary tree to doubly linked list and return it.
        public Node BinaryTreeToDLL(Node root)
        {
            //code here

            Node head = ConvertToDoublyLinkedList(root, null);


            return head;


        }

        //Function to find the lowest common ancestor in a BST.
        public Node LCA_BST(Node root, int n1, int n2)
        {
            //Your code here

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Node n = queue.Dequeue();

                int nodeVal = n.Data;

                if (nodeVal > n1 && nodeVal > n2)
                {
                    queue.Enqueue(n.Left);
                }
                else if (nodeVal < n1 && nodeVal < n2)
                {
                    queue.Enqueue(n.Right);
                }
                else
                {
                    bool left, right;

                    if (n1 > n2)
                    {
                        left = IsContains(root, n2);
                        right = IsContains(root, n1);
                    }
                    else
                    {
                        left = IsContains(root, n1);
                        right = IsContains(root, n2);

                    }

                    if (left && right)
                    {
                        return n;
                    }
                }
            }
            return null;
        }

        public bool IsContains(Node root, int val)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Node n = queue.Dequeue();
                if (n.Data == val)
                {
                    return true;
                }

                if (n.Data > val && n.Left != null)
                {
                    queue.Enqueue(n.Left);
                }
                else if (n.Right != null)
                {
                    queue.Enqueue(n.Right);
                }
            }
            return false;
        }

        public Node DeleteNode(Node root, int X)
        {
            // Your code here

            if (root.Data == X)
            {
                Node n = Del(root);
                return n;
            }
            else
            {
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    Node node = queue.Dequeue();
                    if (node.Data == X)
                    {
                        node = Del(node);
                        return root;
                    }
                    else if (node.Data > X)
                    {
                        if (node.Left != null)
                        {
                            queue.Enqueue(node.Left);
                        }
                        else
                        {
                            return root;
                        }
                    }
                    else
                    {
                        if (node.Right != null)
                        {
                            queue.Enqueue(node.Right);
                        }
                        else
                        {
                            return root;
                        }
                    }
                }
            }
            return root;
        }

        private static Node Del(Node node)
        {
            if (node.Left == null && node.Right == null)
            {
                node = null;
                return node;
            }
            else if (node.Left == null)
            {
                node = node.Right;
                return node;
            }
            else if (node.Right == null)
            {
                node = node.Left;
                return node;
            }

            Node temp = node.Left;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(temp);

            while (queue.Count > 0)
            {
                Node r = queue.Dequeue();

                if (r.Right == null)
                {
                    r.Right = node.Right;
                    break;
                }
                queue.Enqueue(r.Right);
            }

            return temp;
        }

        //static Node prev = null;
        private Node ConvertToDoublyLinkedList(Node root, Node head)
        {
            if (root == null) return head;

            head = ConvertToDoublyLinkedList(root.Left, head);

            if (prev == null)
            {
                head = root;
            }
            else
            {
                root.Left = prev;
                prev.Right = root;

            }
            prev = root;

            return ConvertToDoublyLinkedList(root.Right, head);
        }

        private bool IsSubPart(Node root1, Node root2)
        {

            Stack<Node> stack1 = new Stack<Node>();
            Stack<Node> stack2 = new Stack<Node>();

            stack1.Push(root1);
            stack2.Push(root2);

            while (stack1.Count > 0 || stack2.Count > 0)
            {
                if (stack1.Count != stack2.Count) return false;
                Node n1 = stack1.Pop();
                Node n2 = stack2.Pop();

                if (n1.Data != n2.Data)
                {
                    return false;
                }

                if (n1.Left != null) stack1.Push(n1.Left);
                if (n1.Right != null) stack1.Push(n1.Right);
                if (n2.Left != null) stack2.Push(n2.Left);
                if (n2.Right != null) stack2.Push(n2.Right);
            }

            return true;
        }

        private static void InserElementInMap(Dictionary<int, List<Node>> map, Queue<KeyValuePair<Node, int>> queue, Node node, int level)
        {
            if (map.ContainsKey(level))
            {
                map[level].Add(node);
            }
            else
            {
                map.Add(level, new List<Node>() { node });
            }
            queue.Enqueue(new KeyValuePair<Node, int>(node, level));
        }

        private bool IsIdenticalV2(Node t, Node s)
        {
            if (t == null && s == null) return true;

            if (t != null && s != null)
            {
                return t.Data == s.Data && IsIdenticalV1(t.Left, s.Left) && IsIdenticalV1(t.Right, s.Right);
            }
            return false;
        }

        Node lcaNode = null;

        private bool FindLCA(Node root, int n1, int n2)
        {

            if (root == null) return false;

            bool left = FindLCA(root.Left, n1, n2);

            bool right = FindLCA(root.Right, n1, n2);
            bool curr = root.Data == n1 || n2 == root.Data;

            if ((left && right) || (right && curr) || (left && curr))
            {
                lcaNode = root;
            }

            return left || right || curr;
        }

        private static void InsertNodeInResult(Dictionary<int, List<Node>> result, Queue<KeyValuePair<Node, int>> queue, Node node, int distance)
        {
            if (node != null)
            {
                queue.Enqueue(new KeyValuePair<Node, int>(node, distance));
                if (result.ContainsKey(distance))
                {
                    result[distance].Add(node);
                }
                else
                {
                    result.Add(distance, new List<Node>() { node });
                }
            }
        }
    }
}
