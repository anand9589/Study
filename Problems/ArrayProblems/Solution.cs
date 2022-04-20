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

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);

            IList<IList<int>> list = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int low = i + 1;
                    int high = nums.Length - 1;

                    int sum = 0 - nums[i];

                    while (low < high)
                    {
                        if (nums[low] + nums[high] == sum)
                        {
                            list.Add(new List<int>() { nums[i], nums[low], nums[high] });

                            while (low < high && nums[low] == nums[low + 1]) low++;
                            while (low < high && nums[high] == nums[high - 1]) high--;

                            low++;
                            high--;
                        }
                        else if(nums[low] + nums[high] > sum)
                        {
                            high--;
                        }
                        else
                        {
                            low++;
                        }
                    }
                }

            }

            return list;
        }

        private bool CheckDataIsPresent(IList<IList<int>> list, IList<int> sublist)
        {
            foreach (var item in list)
            {
                var k = item.Intersect(sublist);
                if (k.Count() == 3) return true;
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

        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            IList<IList<int>> vs = new List<IList<int>>();
            List<int> vs1 = new List<int>();
            for (int i = 0; i < grid.Length; i++)
            {
                vs.Add(new List<int>());
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    vs1.Add(grid[i][j]);
                }
            }
            k = k % vs1.Count;
            int indexTOMove = vs1.Count - k;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    grid[i][j] = vs1[indexTOMove];
                    vs[i].Add(grid[i][j]);
                    indexTOMove++;

                    if (indexTOMove == vs1.Count)
                    {
                        indexTOMove = 0;
                    }
                }
            }

            return vs;

        }

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target) return new int[] { i, j };
                }
            }

            return new int[0];
        }
    }
}
