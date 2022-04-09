namespace HeapProblems
{
    internal class Queue_V2
    {
        readonly KeyValuePair<int, int>[] keys;
        readonly int capacity;
        int ptr;

        public Queue_V2(int cap)
        {
            this.capacity = cap;
            keys = new KeyValuePair<int, int>[capacity];
            ptr = 0;
        }

        public void Enqueue(KeyValuePair<int, int> data)
        {
            if (ptr >= capacity) return;
            keys[ptr] = data;
            DecreaseKey(ptr);
            ptr++;
        }

        public void Enqueue_V1(KeyValuePair<int, int> data)
        {
            keys[0] = data;
            IncreaseKey(0);
            //ptr++;
        }

        public KeyValuePair<int, int> Dequeue()
        {
            return keys[0];
        }

        private int left(int k)
        {
            return 2 * k + 1;
        }

        private int right(int k)
        {
            return 2 * k + 2;
        }

        private int parent(int k)
        {
            return (k - 1) / 2;
        }

        private void IncreaseKey(int k)
        {
            int rootIndex = k;
            int leftIndex = left(rootIndex);
            int rightIndex = right(rootIndex);

            if (leftIndex < capacity && rightIndex < capacity)
            {
                int minchildIndex;
                if (keys[leftIndex].Value < keys[rightIndex].Value)
                {
                    minchildIndex = leftIndex;
                }
                else
                {
                    minchildIndex = rightIndex;
                }

                if (keys[minchildIndex].Value < keys[rootIndex].Value)
                {
                    swap(minchildIndex, rootIndex);
                    IncreaseKey(minchildIndex);
                }
            }
            else if (leftIndex < capacity)
            {
                if (keys[leftIndex].Value < keys[rootIndex].Value)
                {
                    swap(leftIndex, rootIndex);
                    IncreaseKey(leftIndex);
                }
            }

        }

        private void DecreaseKey(int k)
        {
            if (k == 0) return;

            int nodeIndex = k;
            int parentIndex = parent(nodeIndex);

            if (keys[nodeIndex].Value < keys[parentIndex].Value)
            {
                swap(nodeIndex, parentIndex);
                DecreaseKey(parentIndex);
            }
        }

        private void swap(int minchildIndex, int rootIndex)
        {
            KeyValuePair<int, int> pair = keys[minchildIndex];
            keys[minchildIndex] = keys[rootIndex];
            keys[rootIndex] = pair;
        }
    }
}
