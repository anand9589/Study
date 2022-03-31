namespace QueueProblems
{
    internal class Solution
    {
        public int Tour(int[] p, int[] d, int n)
        {
            int balance = 0;
            //your Code here
            Queue<int> q = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                if(p[i] >= d[i] + balance)
                {
                    balance += p[i]-d[i];
                    q.Enqueue(i);
                }
            }

            return 0;
        }
    }
}
