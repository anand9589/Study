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


        //Complete this function
        public int[] kLargest(int[] arr, int n, int k)
        {
            //Your code here
            int[] result = new int[k];
            Queue_V5 queue_V5 = new Queue_V5(n);
            for (int i = 0; i < n; i++)
            {
                queue_V5.Enqueue(arr[i]);
            }

            for (int i = 0; i < k; i++)
            {
                result[i] = queue_V5.Dequeue();
            }
            return result;
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

            while (pq.Count != 2)
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

            if (pq.Count == 1)
            {
                result += pq.Dequeue();
            }

            return result;
        }

        private int getMinValueFromChild(int[] arr, int parentIndex, int len)
        {
            int left = 2 * parentIndex + 1;
            int right = 2 * parentIndex + 2;
            int result = 0;

            if (left < len && arr[left] < arr[right])
            {
                result = arr[left];
                swap(arr, left, arr.Length - 1);
            }
            else if (right < len && arr[right] < arr[left])
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

            for (int i = 0; i < K * K; i++)
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

        public long CostOfRopes(int[] arr, int n)
        {
            if (n < 2) return 0;
            long result = 0;
            Queue_V3 queue_V3 = new Queue_V3(n);

            foreach (var item in arr)
            {
                queue_V3.Enqueue(item);
            }

            while (queue_V3.Count > 0)
            {

                long cost = queue_V3.Dequeue();

                result += cost;


            }

            return (long)result;
        }

        public Node mergeKLists(Node[] arr, int K)
        {
            //code here
            Node node = null;
            Queue_V4 queue_V4 = new Queue_V4(K);
            foreach (Node n in arr)
            {
                queue_V4.Enqueue(n);
            }
            node = queue_V4.Dequeue();
            queue_V4.Enqueue(node.next);

            Node temp = node;
            while (queue_V4.Count > 0)
            {
                temp.next = queue_V4.Dequeue();
                temp = temp.next;
                queue_V4.Enqueue(temp.next);
            }

            return node;
        }
        public int LargestInteger(int num)
        {

            //Console.WriteLine(Math.Pow(10,2));

            int len = num.ToString().Length;
            int[] arr = new int[len];

            for (int i = len - 1; i >= 0; i--)
            {
                int rem = num % 10;
                arr[i] = rem;
                num = num / 10;
            }

            int max = getNumber(arr, len);

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (j == i) continue;
                    if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
                    {
                        swap(arr, i, j);
                        max = Math.Max(max, getNumber(arr, len));
                    }
                }
            }

            return max;
        }
        private void swap1(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

        }

        private int getNumber(int[] arr, int len)
        {
            int res = 0;
            for (int i = 0; i < len; i++)
            {
                res = res + (arr[i] * (int)(Math.Pow(10, (len - i - 1))));
            }
            return res;
        }
        public int MaximumProduct(int[] nums, int k)
        {
            for (int i = 0; i < k; i++)
            {
                Array.Sort(nums);
                nums[0]++;
            }

            int result = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                result = result * nums[i];
            }
            return result;

        }

        public int MinCostConnectPoints(int[][] points)
        {
            int cost = 0;
            List<(int, int, int)> edges = new List<(int, int, int)>();
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var a = points[i];
                    var b = points[j];

                    int distance = Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);
                    edges.Add((i, j, distance));
                }
            }

            EdgeData edgeData = new EdgeData(points.Length);

            foreach (var edge in edges.OrderBy(x => x.Item3))
            {
                if (edgeData.Union(edge.Item1, edge.Item2))
                {
                    cost += edge.Item3;
                }
            }

            return cost;
        }

        private int calculateDistance(int[] startPoint, int[] endPoint)
        {

            int x1 = Math.Abs(endPoint[0] - startPoint[0]);
            int x2 = Math.Abs(endPoint[1] - startPoint[1]);

            return x1 + x2;
        }
    }


}
