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
            for (int i = 0; i < arr.Length-1; i++)
            {
                int minIndex = i;
                int j = i+1;
                while (j<arr.Length)
                {
                    if(arr[minIndex] > arr[j])
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
    }
}
