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
                distanceSum += d[i];

                if (p[i] + balance >= d[i])
                {
                    balance = balance + p[i] - d[i];
                    q.Enqueue(i);
                }
                else
                {
                    balance = 0;
                    q.Clear();
                }
            }

            if (q.Count == 0 || petrolSum < distanceSum) return -1;

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

        public int[] MaxOfSubArrays(int[] arr, int k)
        {
            List<int> result = new();
            Queue<int> q = new();
            for (int i = 0; i < k; i++)
            {
                q.Enqueue(arr[i]);
            }
            result.Add(q.Max());

            for (int i = k; i < arr.Length; i++)
            {
                q.Dequeue();
                q.Enqueue(arr[i]);
                result.Add(q.Max());
            }
            return result.ToArray();
        }

        public int[] ReverseKElements(int[] arr, int k)
        {
            Queue<int> q = new Queue<int>();
            for (int i = 0; i < k; i++)
            {
                q.Enqueue(arr[i]);
            }

            for (int i = k - 1; i >= 0; i--)
            {
                arr[i] = q.Dequeue();
            }

            return arr;
        }
        public Queue<int> ReverseKElementsInQueue(Queue<int> q, int k)
        {
            int[] arr = q.ToArray();

            q.Clear();
            for (int i = k - 1; i >= 0; i--)
            {
                q.Enqueue(arr[i]);
            }
            for (int i = k; i < arr.Length; i++)
            {

                q.Enqueue(arr[i]);
            }
            return q;

        }

        public List<string> GenerateBinaryNumbers(int n)
        {
            //Your code here
            List<string> res = new()
            {
                "1"
            };
            for (int i = 2; i <= n; i++)
            {
                res.Add(GetBinaryNumber(i));
            }

            return res;
        }

        public string GetBinaryNumber(int n)
        {
            List<int> res = new();
            while (n!=0)
            {
                res.Insert(0,n%2);
                n /= 2;
            }

            return string.Join(string.Empty,res);
        }

    }
}
