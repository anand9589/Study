namespace ArrayProblems
{
    internal class Solution
    {
        public bool Find132Pattern(int[] arr)
        {
            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = i + 1; j < arr.Length - 1; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if (arr[i] < arr[j] && arr[i] < arr[k] && arr[j] > arr[k])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool Find132Pattern_V1(int[] arr)
        {
            int min = arr[0];
            for (int j = 1; j < arr.Length - 1; j++)
            {
                if (min > arr[j])
                {
                    min = arr[j];
                    continue;
                }
                for (int k = j + 1; k < arr.Length; k++)
                {
                    if (min < arr[j] && min < arr[k] && arr[j] > arr[k])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
