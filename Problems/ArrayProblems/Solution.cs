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
    }
}
