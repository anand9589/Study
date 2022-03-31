namespace QueueProblems.LRU
{
    internal class LRUDoublyLinkedList
    {
        public LRUNode Head { get; set; }
        public LRUNode Tail { get; set; }

        public LRUDoublyLinkedList()
        {
            Head = new LRUNode();
            Tail = new LRUNode();

            Head.Next = Tail;
            Tail.Previous = Head;
        }

        public int Length
        {
            get
            {
                int cntr = 0;

                LRUNode lRUNode = Head;

                while (lRUNode.Next != Tail)
                {
                    cntr++;
;                }

                return cntr;
            }
        }
    }
}
