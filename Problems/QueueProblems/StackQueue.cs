namespace QueueProblems
{
    internal class StackQueue
    {
        Stack<int> st1 = new Stack<int>();
        Stack<int> st2 = new Stack<int>();

        //Complete the functions
        public void Push(int x)
        {
            st1.Push(x);
        }

        public int Pop()
        {
            if (st1.Count == 0) return -1;
            int res = -1;
            while (st1.Count > 1)
            {
                st2.Push(st1.Pop());
            }
            res = st1.Pop();
            while (st2.Count != 0)
            {
                st1.Push(st2.Pop());
            }
            return res;
        }
    }
}
