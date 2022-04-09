namespace HeapProblems
{
    internal class SortedQueue
    {
        private long[] arr;
        private int n;

        public int Count { get { return n; } }

        public SortedQueue(int[] arr)
        {

            n = arr.Length;
            this.arr = new long[n];
            for (int i = 0; i < n; i++)
            {
                this.arr[i] = arr[i];
            }
            buildMinHeap();
        }

        private void buildMinHeap()
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                minHeapify(i);
            }
        }

        private void minHeapify(int i)
        {
            int minValueIndex = i;

            int left = i * 2 + 1;
            int right = i * 2 + 2;

            if (left < n && arr[left] < arr[i])
            {
                minValueIndex = left;
            }
            if (right < n && arr[right] < arr[i])
            {
                minValueIndex = right;
            }

            if (minValueIndex != i)
            {
                swap(i, minValueIndex);
                minHeapify(i);
            }
        }

        private void swap(int i, int j)
        {
            long temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public void Enqueue(long data)
        {
            arr[n] = data;
            DecreaseKey(n);
            n++;
            //buildMinHeap();
        }

        public int parent(int k)
        {
            return (k - 1) / 2;
        }

        public void DecreaseKey(int k)
        {
            int p = parent(k);
            while (k > 0 && this.arr[k] < this.arr[p])
            {
                swap(k, p);
                k = p;
                p = parent(k);
            }
        }

        public long Dequeue()
        {
            n--;
            swap(0, n);
            buildMinHeap();
            return arr[n];
        }
    }
}
