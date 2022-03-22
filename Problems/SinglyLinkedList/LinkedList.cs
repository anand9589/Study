namespace SinglyLinkedList
{
    internal class LinkedList<T>
    {
        public Node<T> Head { get; set; }

        //public LinkedList(Node head)
        //{
        //    this.Head = head;
        //}

        /// <summary>
        /// added node at the end of the linked list
        /// </summary>
        /// <param name="data"></param>
        internal void Push(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node<T> temp = Head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = newNode;
            }
        }

        internal bool IsPalindrome()
        {
            if (Head == null) return false;
            Node<T> temp = Head;
            Stack<T> stack = new Stack<T>();

            while (temp != null)
            {
                stack.Push(temp.Data);
                temp = temp.Next;
            }

            temp = Head;

            while (temp != null)
            {
                if (!temp.Data.Equals(stack.Pop())) return false;

                temp = temp.Next;
            }

            return true;
        }

        internal void RemoveDuplicatesFromSortedList()
        {
            if (Head == null) return;

            Node<T> node = Head;

            while (node != null && node.Next != null)
            {
                while (node.Next != null && node.Data.Equals(node.Next.Data))
                {
                    node.Next = node.Next.Next;
                }
                node = node.Next;
            }
        }

        internal void RemoveDuplicatesFromUnsortedList()
        {
            if (Head == null)
            {
                return;
            }
            List<T> list = new List<T>() { Head.Data };
            Node<T> node = Head;
            while (node != null)
            {

                while (node.Next != null && list.Contains(node.Next.Data))
                {
                    node.Next = node.Next.Next;
                }
                if (node.Next != null) list.Add(node.Next.Data);

                node = node.Next;
            }
        }

        internal void SwapNodes(T x, T y)
        {
            if (x.Equals(y) || Head == null) return;
            Node<T> nodeA_Prev = null;
            Node<T> nodeB_Prev = null;
            Node<T> nodeA = null;
            Node<T> nodeB = null;

            Node<T> node = Head;

            //check head nodes
            if (node.Data.Equals(x))
            {
                nodeA = Head;
            }
            else if (node.Data.Equals(y))
            {
                nodeB = Head;
            }

            while (node != null || (nodeA != null && nodeB != null))
            {
                if (node.Next.Data.Equals(x))
                {
                    nodeA_Prev = node;
                    nodeA = node.Next;
                }
                else if (node.Next.Data.Equals(y))
                {
                    nodeB_Prev = node;
                    nodeB = node.Next;
                }

                if (nodeA != null && nodeB != null) break;
                node = node.Next;


            }

            if (nodeA_Prev == null && nodeB.Next == null)
            {
                //Node<T> temp = nodeA.Next;
                swapNodeWhenNodeHeadTail(nodeB_Prev, nodeA, nodeB);
            }
            else if (nodeB_Prev == null && nodeA.Next == null)
            {

                swapNodeWhenNodeHeadTail(nodeA_Prev, nodeB, nodeA);
            }
            else if (nodeA_Prev == null)
            {
                swapNodeWhenDataIsOnHead(nodeB_Prev, nodeA, nodeB);
            }
            else if (nodeB_Prev == null)
            {
                swapNodeWhenDataIsOnHead(nodeA_Prev, nodeB, nodeA);
            }
            else if (nodeA.Next == null)
            {
                swapNodeWhenDataIsOnTail(nodeA_Prev, nodeB_Prev, nodeA, nodeB);
            }
            else if (nodeB.Next == null)
            {
                swapNodeWhenDataIsOnTail(nodeB_Prev, nodeA_Prev, nodeB, nodeA);
            }
            else
            {
                if (nodeA.Next.Equals(nodeB))
                {
                    swapNodeWhenNodesAreBackToBack(nodeA_Prev, nodeA, nodeB);
                }
                else if (nodeB.Next.Equals(nodeA))
                {
                    swapNodeWhenNodesAreBackToBack(nodeB_Prev, nodeB, nodeA);
                }
                else
                {
                    Node<T> temp = nodeB.Next;
                    nodeB.Next = nodeA.Next;
                    nodeA.Next = temp;

                    nodeA_Prev.Next = nodeB;
                    nodeB_Prev.Next = nodeA;

                }
            }
        }

        private void swapNodeWhenNodeHeadTail(Node<T> tailNode_prev, Node<T> headNode, Node<T> tailNode)
        {
            if (tailNode_prev.Equals(headNode))
            {
                Head = tailNode;
                tailNode.Next = headNode;
                headNode.Next = null;
            }
            else
            {
                tailNode.Next = headNode.Next;
                headNode.Next = null;
                tailNode_prev.Next = headNode;
                Head = tailNode;

            }
        }

        private static void swapNodeWhenDataIsOnTail(Node<T> node1_Prev, Node<T> node2_Prev, Node<T> node1, Node<T> node2)
        {
            if (node2.Next.Equals(node1))
            {
                node2.Next = null;
                node1.Next = node2;
                node2_Prev.Next = node1;
            }
            else
            {
                node1.Next = node2.Next;
                node2.Next = null;
                node1_Prev.Next = node2;
                node2_Prev.Next = node1;
            }
        }

        private static void swapNodeWhenNodesAreBackToBack(Node<T> node_Prev, Node<T> node1, Node<T> node2)
        {
            Node<T> temp = node2.Next;
            node2.Next = node1;
            node1.Next = temp;
            node_Prev.Next = node2;
        }

        private void swapNodeWhenDataIsOnHead(Node<T> nodeB_Prev, Node<T> nodeA, Node<T> nodeB)
        {
            Node<T> temp = nodeB.Next;
            //Head = nodeB;
            if (nodeA.Next == nodeB)
            {
                //temp = nodeB.Next;
                nodeB.Next = nodeA;
                nodeA.Next = temp;
            }
            else
            {
                nodeB.Next = nodeA.Next;
                nodeA.Next = temp;

                nodeB_Prev.Next = nodeA;
            }
            Head = nodeB;
        }

        /// <summary>
        /// Get middle node
        /// </summary>
        /// <returns></returns>
        internal T GetMiddleNode()
        {
            if (Head == null) return default;

            Node<T> slow = Head;
            Node<T> fast = Head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return slow.Data;

        }
        /// <summary>
        /// print linkedlist
        /// </summary>
        internal void Print()
        {
            Node<T> temp = Head;

            while (temp != null)
            {
                Console.Write($" {temp.Data} ");
                temp = temp.Next;
            }
        }
    }
}
