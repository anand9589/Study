﻿namespace QueueProblems
{
    internal class StackQueue
    {
        readonly Stack<int> st1 = new();
        readonly Stack<int> st2 = new();

        //Complete the functions
        public void Push(int x)
        {
            st1.Push(x);
        }

        public int Pop()
        {
            if (st1.Count == 0) return -1;
            while (st1.Count > 1)
            {
                st2.Push(st1.Pop());
            }
            int res = st1.Pop();
            while (st2.Count != 0)
            {
                st1.Push(st2.Pop());
            }
            return res;
        }
    }
}
