namespace HeapProblems
{
    internal class MinHeap
    {
        public int[] harr;
        public int capacity, heap_size;
        public MinHeap(int cap)
        {
            heap_size = 0;
            capacity = cap;
            harr = new int[cap];
        }
        public int parent(int i) { return (i - 1) / 2; }
        public int left(int i) { return (2 * i + 1); }
        public int right(int i) { return (2 * i + 2); }

        //Function to extract minimum value in heap and then to store 
        //next minimum value at first index.
        public int extractMin()
        {
            // Your code here.
            if (heap_size == 0)
            {
                return -1;
            }

            int minElement = harr[0];

            swap(heap_size-1, 0);
            heap_size--;
            buildMinHeap();
            return minElement;
        }

        //Function to insert a value in Heap.
        public void insertKey(int k)
        {
            // Your code here.
            harr[heap_size] = k;
            heap_size++;
            buildMinHeap();

        }

        //Function to delete a key at ith index.
        public void deleteKey(int i)
        {
            if (heap_size <= i) return;
            // Your code here.
            swap(heap_size - 1, i);
            heap_size--;
            buildMinHeap();
            //decreaseKey(heap_size-1, harr[heap_size - 1]);
            //MinHeapify(0);

        }

        private  void swap(int i, int j)
        {
            int temp = harr[i];
            harr[i] = harr[j];
            harr[j] = temp;
        }

        private void buildMinHeap()
        {
            for (int i = heap_size / 2 - 1; i >= 0; i--)
            {
                minheapify(i);
            }
        }

        private void buildMaxHeap()
        {
            for (int i = heap_size / 2 - 1; i >= 0; i--)
            {
                maxheapify(i);
            }
        }

        private void maxheapify(int i)
        {
            int maxValue = i;

            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < heap_size && harr[left] > harr[maxValue])
            {
                maxValue = left;
            }

            if (right < heap_size && harr[right] > harr[maxValue])
            {
                maxValue = right;
            }

            if (maxValue != i)
            {
                swap(i, maxValue);
                maxheapify(maxValue);
            }
        }

        private void minheapify( int i)
        {
            int minValue = i;

            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < heap_size && harr[left] < harr[minValue])
            {
                minValue = left;
            }

            if (right < heap_size && harr[right] < harr[minValue])
            {
                minValue = right;
            }

            if (minValue != i)
            {
                swap( i, minValue);
                minheapify( minValue);
            }
        }

        //Function to change value at ith index and store that value at first index.
        public void decreaseKey(int i, int new_val)
        {
            harr[i] = new_val;
            while (i != 0 && harr[parent(i)] > harr[i])
            {
                int temp = harr[i];
                harr[i] = harr[parent(i)];
                harr[parent(i)] = temp;
                i = parent(i);
            }
        }

        /* You may call below MinHeapify function in
          above codes. Please do not delete this code
          if you are not writing your own MinHeapify */
        public void MinHeapify(int i)
        {
            int l = left(i);
            int r = right(i);
            int smallest = i;
            if (l < heap_size && harr[l] < harr[i]) smallest = l;
            if (r < heap_size && harr[r] < harr[smallest]) smallest = r;
            if (smallest != i)
            {
                int temp = harr[i];
                harr[i] = harr[smallest];
                harr[smallest] = temp;
                MinHeapify(smallest);
            }
        }

        public void print()
        {
            for (int i = 0; i < heap_size; i++)
            {
                Console.Write($" {harr[i]} ");
            }
            Console.WriteLine();
        }
    }

}
