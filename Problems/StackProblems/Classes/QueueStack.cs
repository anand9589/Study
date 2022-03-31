namespace StackProblems.Classes
{
    internal class QueueStack
    {
        Queue<int> q1 = new Queue<int>();
        Queue<int> q2 = new Queue<int>();

        //Complete the functions
        public void Push(int x)
        {
            q1.Enqueue(x);
        }

        public int Pop()
        {
            if (q1.Count == 0) return -1;

            while (q1.Count>1)
            {
                q2.Enqueue(q1.Dequeue());
            }

            var res = q1.Dequeue();

            while (q2.Count!=0)
            {
                q1.Enqueue(q2.Dequeue());
            }

            return res;
        }
    }
}
