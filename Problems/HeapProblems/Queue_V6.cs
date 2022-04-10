namespace HeapProblems
{
    internal class Queue_V6
    {
        private int capacity;
        private int pointer;
        private KeyValuePair<int, int>[] arr;

        public Queue_V6(int cap)
        {
            this.capacity = cap;
            arr = new KeyValuePair<int, int>[this.capacity];
            pointer = 0;
        }

        public void Enqueue(KeyValuePair<int, int> kv)
        {
            if (pointer >= capacity) return;

            arr[pointer++] = kv;

            decreaseKey(pointer - 1);
        }
        public KeyValuePair<int, int> Dequeue()
        {
            KeyValuePair<int, int> kv = arr[0];

            arr[0] = arr[--pointer];

            increaseKey(0);
            return kv;
        }

        private void increaseKey(int k)
        {
            int leftIndex = left(k);
            int rightIndex = right(k);

            if (leftIndex < pointer && rightIndex < pointer)
            {
                int minChildIndex = arr[leftIndex].Value < arr[rightIndex].Value ? leftIndex : rightIndex;

                check(k, minChildIndex);
            }
            else if (leftIndex < pointer)
            {
                check(k, leftIndex);
            }
        }

        private void check(int k, int minChildIndex)
        {
            if (arr[minChildIndex].Value < arr[k].Value)
            {
                swap(minChildIndex, k);
                increaseKey(minChildIndex);
            }
        }

        private void swap(int minChildIndex, int k)
        {
            var data = arr[minChildIndex];
            arr[minChildIndex] = arr[k];
            arr[k] = data;
        }

        private int right(int k)
        {
            return 2 * k + 2;
        }

        private int left(int k)
        {
            return 2 * k + 1;
        }

        private void decreaseKey(int k)
        {
            if (k <= 0) return;
            int parentIndex = parent(k);

            if (arr[parentIndex].Value > arr[k].Value)
            {
                swap(parentIndex, k);
                decreaseKey(parentIndex);
            }
        }

        private int parent(int k)
        {
            return (k - 1) / 2;
        }
    }
}
