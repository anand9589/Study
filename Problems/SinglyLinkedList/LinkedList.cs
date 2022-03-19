namespace SinglyLinkedList
{
    internal class LinkedList
    {
        public Node Head { get; set; }

        //public LinkedList(Node head)
        //{
        //    this.Head = head;
        //}

        /// <summary>
        /// added node at the end of the linked list
        /// </summary>
        /// <param name="data"></param>
        internal void Push(int data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node temp = Head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = newNode;
            }
        }

        /// <summary>
        /// Get middle node
        /// </summary>
        /// <returns></returns>
        internal int GetMiddleNode()
        {
            if (Head == null) return -1;

            Node slow = Head;
            Node fast = Head;

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
            Node temp = Head;

            while (temp != null)
            {
                Console.Write($" {temp.Data} ");
                temp = temp.Next;
            }
        }
    }
}
