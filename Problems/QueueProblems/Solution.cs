namespace QueueProblems
{
    internal class Solution
    {
        public static int Tour(int[] p, int[] d, int n)
        {
            int balance = 0;
            int petrolSum = 0;
            int distanceSum = 0;
            //your Code here
            Queue<int> q = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                petrolSum += p[i];
                distanceSum+= d[i];

                if(p[i] + balance >= d[i])
                {
                    balance = balance + p[i]-d[i];
                    q.Enqueue(i);
                }
                else
                {
                    balance = 0;
                    q.Clear();
                }
            }

            if (q.Count == 0 || petrolSum<distanceSum) return -1;  

            if (q.First() == 0 && q.Last() == n - 1) return q.First();

            for (int i = 0; i < q.First(); i++)
            {
                if (p[i] + balance >= d[i])
                {
                    balance = balance + p[i] - d[i];
                    q.Enqueue(i);
                }
                else
                {
                    while (q.Count != 0)
                    {
                        q.Dequeue();
                    }
                }
            }


            return q.Count == n ? q.First() : -1;
        }
    }
}
