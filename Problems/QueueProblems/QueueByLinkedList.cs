namespace QueueProblems
{
    internal class QueueByLinkedList
    {
        QueueNode Head = null;
        public void push(int x)
        {
            if(Head == null)
            {
                Head = new QueueNode(x);
            }
            else
            {
                var temp = Head;

                while (temp.next != null)
                {
                    temp = temp.next;
                }

                temp.next = new QueueNode(x);
            }
        }

        public int pop()
        {
            if(Head == null) return -1;
            var res = Head.data;
            Head = Head.next;
            return res;
        }
    }
}
