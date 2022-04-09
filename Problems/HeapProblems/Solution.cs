namespace HeapProblems
{
    internal class Solution
    {
        public int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        public int[] InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;

                while (j > 0 && arr[j] < arr[j - 1])
                {

                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                    j--;
                }

            }
            return arr;
        }

        public int[] SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                int j = i + 1;
                while (j < arr.Length)
                {
                    if (arr[minIndex] > arr[j])
                    {
                        minIndex = j;
                    }
                    j++;
                }
                if (minIndex != i)
                {
                    int temp = arr[minIndex];
                    arr[minIndex] = arr[i];
                    arr[i] = temp;
                }
            }
            return arr;
        }

        public int[] MergeSort(int[] arr)
        {
            int len = arr.Length;
            if (len == 1) return arr;

            int mid = len / 2;

            int[] leftArr = new int[mid];
            int[] rightArr = new int[len - mid];

            for (int i = 0; i < mid; i++)
            {
                leftArr[i] = arr[i];
            }

            for (int i = mid; i < len; i++)
            {
                rightArr[i - mid] = arr[i];
            }

            leftArr = MergeSort(leftArr);
            rightArr = MergeSort(rightArr);

            return merge(leftArr, rightArr);
        }

        private int[] merge(int[] leftArr, int[] rightArr)
        {
            int mIndex = 0, nIndex = 0, index = 0;
            int[] arr = new int[leftArr.Length + rightArr.Length];

            while (index < leftArr.Length + rightArr.Length)
            {
                if (mIndex < leftArr.Length && nIndex < rightArr.Length)
                {
                    arr[index++] = leftArr[mIndex] < rightArr[nIndex] ? leftArr[mIndex++] : rightArr[nIndex++];
                }
                else if (mIndex < leftArr.Length)
                {
                    arr[index++] = leftArr[mIndex++];
                }
                else
                {
                    arr[index++] = rightArr[nIndex++];
                }
            }

            return arr;
        }

        public void QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int j = partition(arr, start, end);
                QuickSort(arr, start, j);
                QuickSort(arr, j + 1, end);
            }
        }

        private int partition(int[] arr, int start, int end)
        {
            int pivot = arr[start];

            int i = start, j = end;


            while (i < j)
            {
                while (arr[i] <= pivot)
                {
                    i++;
                }

                while (arr[j] > pivot)
                {
                    j--;
                }

                if (i < j)
                {
                    swap(arr, i, j);
                }
            }
            swap(arr, start, j);

            return j;
        }

        private static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public void createMaxHeap(int[] arr, int len, int k = 0)
        {
            if (k == arr.Length) return;
            for (int i = len - 1; i >= k; i--)
            {
                int parentNodeIndex = (i - 1) / 2;

                if (arr[parentNodeIndex] < arr[i])
                {
                    swap((int[])arr, i, parentNodeIndex);
                    //Console.WriteLine(String.Join(' ', arr));
                }

            }
            createMaxHeap(arr, len, k + 1);
        }

        public void HeapSort_V1(int[] arr)
        {
            //createMaxHeap((int[])arr, arr.Length,0);

            //swap(arr, arr.Length - 1, 0);

            for (int i = arr.Length; i > 0; i--)
            {
                createMaxHeap(arr, i, 0);
                swap(arr, i - 1, 0);
                Console.WriteLine(String.Join(' ', arr));
            }
        }

        public void HeapSort(int[] arr, int n)
        {
            buildHeap(arr, n);
            for (int i = n - 1; i > 0; i--)
            {
                swap(arr, 0, i);
                heapify(arr, i, 0);
            }
        }

        private void buildHeap(int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                heapify(arr, n, i);
            }
        }

        private void heapify(int[] arr, int n, int i)
        {
            int maxValue = i;

            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[maxValue])
            {
                maxValue = left;
            }

            if (right < n && arr[right] > arr[maxValue])
            {
                maxValue = right;
            }

            if (maxValue != i)
            {
                swap(arr, i, maxValue);
                heapify(arr, n, maxValue);
            }
        }

        public long minCost(int[] arr, int n)
        {
            // Your code here
            long result = 0;

            SortedQueue pq = new SortedQueue(arr);
            //for (int i = 0; i < n; i++)
            //{
            //    pq.Enqueue(arr[i]);
            //}

            while (pq.Count!=2)
            {
                var min1 = pq.Dequeue();
                var min2 = pq.Dequeue();

                long cost = min1 + min2;
                pq.Enqueue(cost);
                result += cost;
            }

            if (pq.Count == 2)
            {
                long cost = pq.Dequeue() + pq.Dequeue();
                result += cost;
            }

            if(pq.Count == 1)
            {
                result+=pq.Dequeue();
            }

            return result;
        }

        private int getMinValueFromChild(int[] arr, int parentIndex, int len)
        {
            int left = 2 * parentIndex + 1;
            int right = 2 * parentIndex + 2;
            int result = 0;

            if(left < len && arr[left] < arr[right])
            {
                result = arr[left];
                swap(arr, left, arr.Length-1);
            }
            else if(right < len && arr[right] < arr[left])
            {
                result = arr[right];
                swap(arr, right, arr.Length - 1);
            }

            return result;
        }


        private void buildMinHeap(int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                minHeapify(arr, n, i);
            }
        }

        private void minHeapify(int[] arr, int n, int i)
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
                swap(arr, i, minValueIndex);
                minHeapify(arr, n, minValueIndex);
            }

        }


        public List<int> mergeKArrays(ref List<List<int>> arr, int K)
        {
            //code here
            List<int> result = new List<int>();
            Queue_V2 queue_V2 = new Queue_V2(K);
            for (int i = 0; i < arr.Count; i++)
            {
                queue_V2.Enqueue(new KeyValuePair<int, int>(i, arr[i][0]));
                arr[i].RemoveAt(0);
            }

            for (int i = 0; i < K*K; i++)
            {
                KeyValuePair<int, int> pair = queue_V2.Dequeue();
                result.Add(pair.Value);

                int enqVal = int.MaxValue;
                if (arr[pair.Key].Count > 0)
                {
                    enqVal = arr[pair.Key][0];
                    arr[pair.Key].RemoveAt(0);
                }
                queue_V2.Enqueue_V1(new KeyValuePair<int, int>(pair.Key, enqVal));
            }

            return result;
        }

    }


}
