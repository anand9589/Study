namespace QueueProblems
{
    internal class QueueNode
    {
        public int data;
        public QueueNode next;

        public QueueNode(int a)
        {
            this.data = a;
            this.next = null;
        }
    }
}
