namespace HeapProblems
{
    internal class Queue_V5
    {
        private int capacity;
        private int pointer;
        private int[] arr;
        public Queue_V5(int cap)
        {
            this.capacity = cap;
            pointer = 0;
            arr = new int[capacity];
        }

        public void Enqueue(int data)
        {
            if (pointer >= capacity) return;

            arr[pointer++] = data;

            decreaseKey(pointer - 1);
        }

        public int Dequeue()
        {
            int maxValue = arr[0];

            arr[0] = arr[--pointer];

            increaseKey(0);

            return maxValue;
        }

        private void increaseKey(int k)
        {
            int leftIndex = left(k);
            int rightIndex = right(k);

            if (leftIndex < pointer && rightIndex < pointer)
            {
                int maxChildIndex = arr[leftIndex] > arr[rightIndex] ? leftIndex : rightIndex;

                if (arr[maxChildIndex] > arr[k])
                {
                    swap(maxChildIndex, k);
                    increaseKey(maxChildIndex);
                }
            }
            else if (leftIndex < pointer)
            {

                if (arr[leftIndex] < arr[k])
                {
                    swap(leftIndex, k);
                    increaseKey(leftIndex);
                }
            }
        }

        private void decreaseKey(int k)
        {
            if (k <= 0) return;

            int parentIndex = parent(k);

            if (arr[parentIndex] < arr[k])
            {
                swap(parentIndex, k);
                decreaseKey(parentIndex);
            }
        }

        private void swap(int parentIndex, int k)
        {
            int temp = arr[parentIndex];
            arr[parentIndex] = arr[k];
            arr[k] = temp;
        }

        private int parent(int k)
        {
            return (k - 1) / 2;
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
