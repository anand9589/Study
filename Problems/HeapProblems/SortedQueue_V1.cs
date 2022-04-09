namespace HeapProblems
{
    internal class SortedQueue_V1
    {
        int[] arr;
        int n;
        int capacity;

        public SortedQueue_V1(int cap)
        {
            this.capacity = cap;
            this.n = 0;
            this.arr = new int[this.capacity];
        }

        public void enqueue(int data)
        {
            arr[n] = data;
            decreaseKey(n);
            n++;
        }

        private void decreaseKey(int k)
        {
            int p = parent(k);
            while (k < n && arr[k] < arr[p])
            {
                swap(p, k);
                k = p;
                decreaseKey(k);
            }
        }

        private void swap(int p, int k)
        {
            arr[p] = arr[p] + arr[k];
            arr[k] = arr[p] - arr[k];
            arr[p] = arr[p] - arr[k];
        }

        private int parent(int k)
        {
            return k - 1 / 2;
        }

        private int left(int k)
        {
            return 2 * k + 1;
        }

        private int right(int k)
        {
            return 2 * k + 2;
        }
    }
}
