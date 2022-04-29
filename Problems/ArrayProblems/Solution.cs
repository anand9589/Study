using System.Text;

namespace ArrayProblems
{
    internal class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    char c = board[i][j];

                    if (c != '.')
                    {
                        bool l = isValidValue(board, i, j);
                        if (!l) return false;
                    }
                }
            }
            return true;
        }

        private bool isValidValue(char[][] board, int x, int y)
        {
            //1st rule : Check within block


            //2nd rule :  Check column

            //3rd rule : Check row
            return sudokuFirstRule(board, x, y) && sudokuSecondRule(board, x, y) && sudokuThirdRule(board, x, y);
        }

        private bool sudokuFirstRule(char[][] board, int x, int y)
        {
            //there will be 9 blocks
            // {0,0} to {2,2}
            // {0,3} to {2,5}
            // {0,6} to {2,8}
            // {3,0} to {5,2}
            // {3,3} to {5,5}
            // {3,6} to {5,8}
            // {6,0} to {6,2}
            // {6,3} to {6,5}
            // {6,6} to {6,8}

            int x1 = getX1(x);
            int y1 = getX1(y);

            for (int i = x1; i < x1 + 3; i++)
            {
                for (int j = y1; j < y1 + 3; j++)
                {
                    if (i == x && j == y) continue;

                    if (board[i][j] == board[x][y]) return false;
                }
            }
            return true;
        }

        private bool sudokuSecondRule(char[][] boards, int x, int y)
        {

            for (int j = 0; j < boards[x].Length; j++)
            {
                if (j == y) continue;

                if (boards[x][j] == boards[x][y]) return false;
            }

            return true;
        }

        private bool sudokuThirdRule(char[][] boards, int x, int y)
        {

            for (int i = 0; i < boards.Length; i++)
            {
                if (i == x) continue;

                if (boards[i][y] == boards[x][y]) return false;
            }

            return true;
        }

        private static int getX1(int x)
        {
            if (x < 3)
            {
                return 0;
            }
            else if (x < 6)
            {
                return 3;
            }
            else
            {
                return 6;
            }
        }

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
                        else if (nums[low] + nums[high] > sum)
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

        public int ThreeSumClosest(int[] nums, int target)
        {

            int result = nums[0] + nums[1] + nums[nums.Length - 1];

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int low = i + 1;
                int high = nums.Length - 1;

                while (low < high)
                {
                    int sum = nums[i] + nums[low] + nums[high];

                    if (sum > target)
                    {
                        high--;
                    }
                    else
                    {
                        low++;
                    }

                    if (Math.Abs(sum - target) < Math.Abs(result - target))
                    {
                        result = sum;
                    }
                }
            }

            return result;
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 3; i++)
            {
                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    for (int k = j + 1; k < nums.Length - 1; k++)
                    {
                        for (int l = k + 1; l < nums.Length; l++)
                        {
                            if (nums[i] + nums[j] + nums[k] + nums[l] == target)
                            {
                                list.Add(new List<int>() { nums[i], nums[j], nums[k], nums[l] });
                                break;
                            }

                            while (l < nums.Length - 1 && nums[l] == nums[l + 1])
                            {
                                l++;
                            }
                        }
                        while (k < nums.Length - 2 && nums[k] == nums[k + 1])
                        {
                            k++;
                        }
                    }
                    while (j < nums.Length - 3 && nums[j] == nums[j + 1])
                    {
                        j++;
                    }
                }
                while (i < nums.Length - 4 && nums[i] == nums[i + 1])
                {
                    i++;
                }

            }

            return list;
        }

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> list = new List<string>();
            if (string.IsNullOrEmpty(digits)) return list;
            Dictionary<int, char[]> dctKeys = new Dictionary<int, char[]>();

            dctKeys.Add(2, new char[] { 'a', 'b', 'c' });
            dctKeys.Add(3, new char[] { 'd', 'e', 'f' });
            dctKeys.Add(4, new char[] { 'g', 'h', 'i' });
            dctKeys.Add(5, new char[] { 'j', 'k', 'l' });
            dctKeys.Add(6, new char[] { 'm', 'n', 'o' });
            dctKeys.Add(7, new char[] { 'p', 'q', 'r', 's' });
            dctKeys.Add(8, new char[] { 't', 'u', 'v' });
            dctKeys.Add(9, new char[] { 'w', 'x', 'y', 'z' });

            int num = int.Parse(digits);
            List<char[]> chars = new List<char[]>();
            while (num > 0)
            {
                int rem = num % 10;
                chars.Insert(0, dctKeys[rem]);
                num /= 10;
            }

            for (int i = 0; i < chars.Count; i++)
            {
                if (i == 0)
                {
                    foreach (var item in chars[i])
                    {
                        list.Add(item.ToString());
                    }
                }
                else
                {
                    int cnt = list.Count;
                    for (int k = 0; k < cnt; k++)
                    {
                        string s1 = list[0];
                        foreach (var item in chars[i])
                        {
                            list.Add(s1 + item.ToString());
                        }
                        list.RemoveAt(0);
                    }
                }
            }

            return list;
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

        public int RemoveDuplicates(int[] nums)
        {
            int pointer = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[pointer])
                {
                    pointer++;
                    nums[pointer] = nums[i];
                }
            }
            return pointer + 1;
        }

        public int RemoveElement(int[] nums, int val)
        {
            int decreseIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    decreseIndex++;
                }
                else
                {
                    nums[i - decreseIndex] = nums[i];
                }
            }
            return nums.Length - decreseIndex;
        }

        public int StrStr(string haystack, string needle)
        {

            return haystack.IndexOf(needle);
        }

        public int Divide(int dividend, int divisor)
        {
            if (dividend == 1 << 31 && divisor == -1) return int.MaxValue;

            bool signFlag = (dividend >= 0) == (divisor >= 0);

            dividend = Math.Abs(dividend);
            divisor = Math.Abs(divisor);
            int result = 0;
            while (dividend - divisor >= 0)
            {
                int count = 0;

                while (dividend - (divisor << 1 << count) >= 0)
                {
                    count++;
                }

                result += 1 << count;

                dividend -= divisor << count;
            }

            return signFlag ? result : -1 * result;
        }

        public void NextPermutation(int[] nums)
        {
            int i = nums.Length - 1;
            int j = nums.Length - 1;
            while (i > 0)
            {
                if (nums[i] > nums[i - 1])
                {
                    while (j >= i)
                    {
                        if (nums[j] > nums[i - 1])
                        {
                            swap(nums, i - 1, j);
                            break;
                        }
                        j--;
                    }
                    break;
                }
                i--;
            }
            j = nums.Length - 1;
            while (i < j)
            {
                swap(nums, i, j);
                i++;
                j--;
            }

        }

        private void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

    }
}
