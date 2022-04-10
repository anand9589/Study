namespace HeapProblems
{
    internal class Queue_V3
    {
        private int capacity;
        private int lastIndex;
        private long[] arr;

        public int Count { get { return lastIndex; } }

        public Queue_V3(int cap)
        {
            capacity = cap;
            arr = new long[capacity];
            lastIndex = 0;
        }

        public void Enqueue(long data)
        {
            if (lastIndex >= capacity) return;

            arr[lastIndex] = data;
            decreseKey(lastIndex);
            lastIndex++;
        }

        public long Dequeue()
        {
            if (lastIndex == 0) return -1;
            if (lastIndex == 1) { lastIndex = 0; return arr[0]; }
            if (lastIndex == 2) { lastIndex = 0; return arr[0] + arr[1]; }
            long min1 = arr[0];
            long min2 = 0;
            if (lastIndex == 3) 
            {
                if (arr[1] < arr[2]) 
                {
                    min2 = arr[1];
                    arr[0] = arr[2];
                    arr[1] = min1 + min2;
                }
                else
                {
                    min2=arr[2];
                    arr[0] = arr[1];
                    arr[1] = min1 + min2;
                }
                lastIndex = 2;
            }
            else
            {
                int minChildIndex = -1;
                if(arr[1] < arr[2])
                {
                    minChildIndex = 1;
                }
                else
                {
                    minChildIndex = 2;
                }
                min2 = arr[minChildIndex];
                lastIndex--;
                long lastMax = arr[lastIndex];

                if(lastMax < min1+min2)
                {
                    arr[0] = lastMax;
                    arr[minChildIndex] = min1+min2;
                }
                else
                {
                    arr[0] = min1+min2;
                    arr[minChildIndex] = lastMax;
                }
                increasekey(minChildIndex);
                increasekey(0);
            }

            return min1 + min2;
            //long min1 = arr[0];
            ////lastIndex--;
            //arr[0] = int.MaxValue;
            //long min2 = -1;
            //int minIndex = -1;
            //if (arr[1] < arr[2])
            //{
            //    //min2 = arr[1];
            //    //lastIndex--;
            //    //arr[1] = int.MaxValue;
            //    minIndex = 1;
            //}
            //else
            //{
            //    //min2 = arr[2];
            //    //lastIndex--;
            //    //arr[2] = int.MaxValue;
            //    minIndex = 2;
            //}
            //increasekey(0);
            //increasekey(minIndex);
            //lastIndex -= 2;
            //return min1 + min2;
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

        private void decreseKey(int k)
        {
            if (k <= 0) return;

            int parentKey = parent(k);

            if (arr[parentKey] > arr[k])
            {
                swap(parentKey, k);
                decreseKey(parentKey);
            }
        }

        private void increasekey(int k)
        {
            if (k > lastIndex) return;

            int leftKey = left(k);
            int rightKey = right(k);

            int minChildKey = -1;
            if (leftKey < lastIndex && rightKey < lastIndex)
            {
                if (arr[leftKey] < arr[rightKey])
                {
                    minChildKey = leftKey;
                }
                else
                {
                    minChildKey = rightKey;
                }
            }
            else if (leftKey < lastIndex)
            {
                minChildKey = leftKey;
            }

            if (minChildKey != -1 && arr[k] > arr[minChildKey])
            {
                swap(k, minChildKey);
                increasekey(minChildKey);
            }
        }

        private void swap(int parentKey, int k)
        {
            long temp = arr[parentKey];
            arr[parentKey] = arr[k];
            arr[k] = temp;
        }
    }
}
