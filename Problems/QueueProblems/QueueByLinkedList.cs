namespace QueueProblems
{
    internal class QueueByLinkedList
    {
        private QueueNode Head;
        public void Push(int x)
        {
            if(Head == null)
            {
                Head = new QueueNode(x);
            }
            else
            {
                var temp = Head;

                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = new QueueNode(x);
            }
        }

        public int Pop()
        {
            if(Head == null) return -1;
            var res = Head.Data;
            Head = Head.Next;
            return res;
        }
    }
}
