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

        internal bool IsPalindromw()
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
