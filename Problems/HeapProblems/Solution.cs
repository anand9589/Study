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
                else if(mIndex < leftArr.Length)
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
    }
}
