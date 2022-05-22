using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        #region 3. Longest Substring Without Repeating Characters
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int result = 0;
            int count = 0;
            int i = 0;

            while (i < s.Length)
            {
                char c = s[i];

                if (map.ContainsKey(c))
                {
                    result = Math.Max(result, count);
                    count = 0;
                    int temp = map[c];
                    map.Clear();
                    i = temp + 1;
                }
                else
                {
                    map.Add(c, i);
                    count++;
                    i++;
                }
            }

            result = Math.Max(result, count);
            return result;
        }
        #endregion

        #region 19. Remove Nth Node From End of List
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode fast = head;
            Stack<ListNode> stack = new Stack<ListNode>();
            stack.Push(fast);
            while (fast.Next != null && fast.Next.Next != null)
            {
                fast = fast.Next.Next;
                stack.Push(stack.Peek().Next);
            }
            int total = 2 * stack.Count - 1;
            if (fast.Next != null)
            {
                total++;
            }
            if (n <= total)
            {
                int deleteNode = total - n + 1;

                if (deleteNode >= stack.Count)
                {
                    while (stack.Count < deleteNode)
                    {
                        stack.Push(stack.Peek().Next);
                    }
                }
                else
                {
                    while (stack.Count > deleteNode)
                    {
                        stack.Pop();
                    }
                }
                if (stack.Count > 1)
                {
                    ListNode l = stack.Pop();
                    ListNode temp = l.Next;
                    stack.Pop().Next = temp;
                }
                else
                {
                    head = head.Next;
                }
            }
            return head;
        }
        #endregion

        #region 21. Merge Two Sorted Lists
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            ListNode head = new ListNode(int.MaxValue);
            ListNode temp = head.Next;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    temp = list1;
                    list1 = list1.Next;
                }
                else
                {
                    temp = list2;
                    list2 = list2.Next;
                }
                temp = temp.Next;
            }

            while (list1 != null)
            {
                temp = list1;
                list1 = list1.Next;
                temp = temp.Next;
            }
            while (list2 != null)
            {
                temp = list2;
                list2 = list2.Next;
                temp = temp.Next;
            }

            return head.Next;

        }
        #endregion

        #region 34. Find First and Last Position of Element in Sorted Array
        public int[] SearchRange(int[] nums, int target)
        {
            int firstIndex = -1;
            int lastIndex = -1;

            int low = 0;
            int high = nums.Length - 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                if (nums[mid] == target)
                {
                    firstIndex = mid;
                    break;
                }

                if (nums[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            if (firstIndex != -1)
            {
                lastIndex = firstIndex;
                if (nums[low] == target)
                {
                    firstIndex = low;
                }
                else
                {
                    while (firstIndex > low && nums[firstIndex - 1] == target)
                    {
                        firstIndex--;
                    }
                }

                if (nums[high] == target)
                {
                    lastIndex = high;
                }
                else
                {
                    while (lastIndex < high && nums[lastIndex + 1] == target)
                    {
                        lastIndex++;
                    }
                }
            }
            else if (low == high)
            {
                if (nums[low] == target)
                {
                    firstIndex = low;
                    lastIndex = high;
                }
            }
            return new int[] { firstIndex, lastIndex };
        }
        #endregion

        #region 35. Search Insert Position
        public int SearchInsert(int[] nums, int target)
        {
            return SearchInsert_Helper(nums, target, 0, nums.Length - 1);
        }

        private int SearchInsert_Helper(int[] nums, int target, int low, int high)
        {
            if (low >= high)
            {
                if (nums[low] >= target)
                {
                    return low;
                }
                else
                {
                    return low + 1;
                }
            }
            if (nums[low] > target) return low;

            if (nums[high] < target) return high + 1;

            int mid = low + (high - low) / 2;

            if (nums[mid] >= target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
            return SearchInsert_Helper(nums, target, low, high);
        }
        #endregion

        #region 38. CountAndSay
        /// <summary>
        /// LeetCode #38
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay(int n)
        {
            if (n == 1) return "1";

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("1");
            for (int i = 2; i <= n; i++)
            {
                List<(char, int)> list = new List<(char, int)>();
                string s = stringBuilder.ToString();
                int k = 0;
                while (k < s.Length)
                {
                    var lastItem = list.LastOrDefault();

                    if (lastItem.Item1 == s[k])
                    {
                        int count = lastItem.Item2 + 1;
                        char c = s[k];
                        list[list.Count - 1] = (c, count);
                    }
                    else
                    {
                        list.Add((s[k], 1));
                    }
                    k++;
                }


                stringBuilder = new StringBuilder();
                for (int j = 0; j < list.Count; j++)
                {
                    stringBuilder.Append(list[j].Item2.ToString());

                    int n1 = (int)(list[j].Item1 - '0');

                    stringBuilder.Append(n1.ToString());
                }

            }

            return stringBuilder.ToString();
        }
        #endregion

        #region 39 CombinationSum

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();

            backtrack(result, new List<int>(), candidates, 0, target);

            return result;
        }

        private void backtrack(IList<IList<int>> result, List<int> list, int[] candidates, int start, int target)
        {
            if (target < 0) return;
            if (target == 0) result.Add(new List<int>(list));

            for (int i = start; i < candidates.Length; i++)
            {
                list.Add(candidates[i]);
                backtrack(result, list, candidates, i, target - candidates[i]);
                list.RemoveAt(list.Count - 1);
            }
        }

        #endregion

        #region 40 CombinationSum2
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates);
            backtrack2(result, new List<int>(), candidates, 0, target);

            return result;
        }

        private void backtrack2(IList<IList<int>> result, List<int> list, int[] candidates, int start, int target)
        {
            if (target < 0) return;
            if (target == 0)
            {
                result.Add(new List<int>(list));
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (i == start || candidates[i] != candidates[i - 1])
                {
                    list.Add(candidates[i]);
                    backtrack2(result, list, candidates, i + 1, target - candidates[i]);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
        #endregion

        #region 41 FirstMissingPositive
        public int FirstMissingPositive(int[] nums)
        {
            //List<int> rank = Enumerable.Range(1, nums.Length).ToList();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= 0 || nums[i] > nums.Length)
                {
                    nums[i] = nums.Length + 1;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int id = Math.Abs(nums[i]);

                if (id > nums.Length) continue;

                id--;

                if (nums[id] > 0) nums[id] = -nums[id];

            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0) return i + 1;
            }

            return nums.Length + 1;

            //return rank.Count == 0 ? nums.Length +1 : rank[0];
        }
        #endregion

        #region 42 Trapping Rain Water
        public int Trap(int[] height)
        {
            int n = height.Length;

            if (n <= 2) return 0;

            int result = 0;

            int start1 = 0;
            int end2 = n - 1;

            for (int i = 1; i < end2; i++)
            {
                if (height[i] >= height[start1])
                {
                    start1++;
                }
                else
                {
                    break;
                }
            }
            for (int i = end2 - 1; i > start1; i--)
            {
                if (height[i] >= height[end2])
                {
                    end2--;
                }
                else
                {
                    break;
                }
            }

            if (end2 - start1 <= 1) return 0;

            while (start1 < end2)
            {
                int end1 = -1;
                for (int i = start1 + 1; i < n; i++)
                {
                    if (height[i] >= height[start1])
                    {
                        end1 = i;

                        int min = Math.Min(height[start1], height[end1]);

                        for (int j = start1 + 1; j < end1; j++)
                        {
                            result += min - height[j];
                        }
                        start1 = i;
                    }
                }

                int start2 = -1;
                for (int i = end2 - 1; i >= start1; i--)
                {
                    if (height[i] >= height[end2])
                    {
                        start2 = i;

                        int min1 = Math.Min(height[start2], height[end2]);

                        for (int j = start2 + 1; j < end2; j++)
                        {
                            result += min1 - height[j];
                        }
                        end2 = i;
                    }

                }

            }


            return result;
        }
        #endregion

        #region 43 Multiply Strings

        public string Multiply(string num1, string num2)
        {
            while (num1.StartsWith("0"))
            {
                num1 = num1.Remove(0, 1);
                if (num1.Length == 0) return "0";
            }
            while (num2.StartsWith("0"))
            {
                num2 = num2.Remove(0, 1);
                if (num2.Length == 0) return "0";
            }
            int zeroCount = 0;
            List<StringBuilder> subresult = new List<StringBuilder>();
            StringBuilder result = new StringBuilder();
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int carryOn = 0;
                StringBuilder stringBuilder = new StringBuilder();
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    int n1 = num1[i] - '0';
                    int n2 = num2[j] - '0';

                    int ans = (n1 * n2) + carryOn;
                    StringBuilder res = new StringBuilder();
                    res.Append(ans);
                    if (res.Length > 1)
                    {
                        carryOn = res[0] - '0';
                        stringBuilder.Insert(0, res[1]);
                    }
                    else
                    {
                        carryOn = 0;
                        stringBuilder.Insert(0, res[0]);
                    }
                }
                if (carryOn > 0)
                {
                    stringBuilder.Insert(0, carryOn);
                }

                for (int k = 0; k < zeroCount; k++)
                {
                    stringBuilder.Append("0");
                }

                if (result.Length == 0)
                {
                    result.Append(stringBuilder.ToString());
                }
                else
                {
                    int ccc = 0;
                    StringBuilder ss = new StringBuilder();
                    for (int l = 0; l < stringBuilder.Length; l++)
                    {
                        StringBuilder stringBuilder1 = new StringBuilder();

                        int m1Index = stringBuilder.Length - 1 - l;
                        int m2Index = result.Length - 1 - l;
                        int m1 = m1Index >= 0 ? stringBuilder[m1Index] - '0' : 0;
                        int m2 = m2Index >= 0 ? result[m2Index] - '0' : 0;

                        int m3 = m1 + m2 + ccc;

                        stringBuilder1.Append(m3);

                        if (stringBuilder1.Length > 1)
                        {
                            ccc = stringBuilder1[0] - '0';
                            ss.Insert(0, stringBuilder1[1]);
                        }
                        else
                        {
                            ss.Insert(0, stringBuilder1.ToString());
                            ccc = 0;
                        }

                    }
                    if (ccc > 0)
                    {
                        ss.Insert(0, ccc);
                    }

                    result = new StringBuilder();
                    result.Append(ss);
                }
                subresult.Add(stringBuilder);
                zeroCount++;
            }

            return result.ToString();
        }

        #endregion

        #region 45. Jump Game II
        public int Jump(int[] nums)
        {
            int[] dp = Enumerable.Repeat(int.MaxValue, nums.Length).ToArray();
            int lastIndex = nums.Length - 1;

            dp[lastIndex] = 0;

            for (int i = lastIndex - 1; i >= 0; i--)
            {
                if (nums[i] + i >= lastIndex)
                {
                    dp[i] = 1;
                }
                else
                {
                    int min = i + 1;
                    for (int j = 2; j <= nums[i]; j++)
                    {
                        if (dp[min] > dp[j + i])
                        {
                            min = j + i;
                        }
                    }

                    dp[i] = 1 + dp[min];
                }
            }


            return dp[0];
        }
        #endregion

        #region 46. Permutations
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Permute_backtrack(result, nums, 0);
            return result;
        }

        private void Permute_backtrack(IList<IList<int>> result, int[] nums, int start)
        {
            if (start == nums.Length)
            {
                result.Add(new List<int>(nums));
                return;
            }
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    swap(i, start, nums);
                    Permute_backtrack(result, nums, start + 1);
                    swap(i, start, nums);
                }
            }
        }

        public IList<IList<int>> Permute_V2(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            LinkedList<int> ll = new LinkedList<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                ll.AddLast(nums[i]);
            }

            Permute_DFS(result, new LinkedList<int>(), ll);

            return result;
        }

        private void Permute_DFS(IList<IList<int>> result, LinkedList<int> linkedList, LinkedList<int> ll)
        {
            if (ll.Count == 0)
            {
                result.Add(new List<int>(linkedList.ToList()));
                return;
            }

            foreach (int n in ll)
            {
                LinkedList<int> temp1 = new LinkedList<int>(linkedList);
                LinkedList<int> temp2 = new LinkedList<int>(ll);

                temp1.AddLast(n);
                temp2.Remove(n);
                Permute_DFS(result, temp1, temp2);
            }
        }

        public IList<IList<int>> Permute_1(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Permute_Helper(result, new List<int>(), nums, 0, nums.Length);
            return result;
        }

        private void Permute_Helper(IList<IList<int>> list, IList<int> sublist, int[] nums, int start, int end)
        {
            if (start == end)
            {
                list.Add(new List<int>(sublist));

                return;
            }

            for (int i = start; i < end; i++)
            {
                sublist.Add(nums[i]);
                swap(i, start, nums);
                Permute_Helper(list, sublist, nums, start + 1, end);
                swap(i, start, nums);
                sublist.RemoveAt(sublist.Count - 1);
            }
        }
        #endregion

        #region 47. Permutations II
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            PermuteUnique_BackTrack(result, nums, 0);
            return result;
        }

        private void PermuteUnique_BackTrack(IList<IList<int>> result, int[] nums, int start)
        {
            if (start == nums.Length)
            {
                result.Add(new List<int>(nums));
                return;
            }
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    if (i != start && !canPermute(start, i, nums)) continue;
                    swap(i, start, nums);
                    PermuteUnique_BackTrack(result, nums, start + 1);
                    swap(i, start, nums);
                }
            }
        }

        private bool canPermute(int start, int i, int[] nums)
        {
            for (int j = start; j < i; j++)
            {
                if (nums[j] == nums[i]) return false;
            }
            return true;
        }
        #endregion

        #region 48. Rotate Image
        public void Rotate(int[][] matrix)
        {
            int[][] cp = new int[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                cp[i] = new int[matrix[i].Length];
                for (int j = 0; j < matrix.Length; j++)
                {
                    cp[i][j] = matrix[i][j];
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = cp[matrix.Length - j - 1][i];
                }
            }
        }
        #endregion

        #region 49. Group Anagrams
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Dictionary<string, IList<int>> dic = new Dictionary<string, IList<int>>();

            for (int i = 0; i < strs.Length; i++)
            {
                char[] ch = strs[i].ToCharArray();
                Array.Sort(ch);
                string s = new String(ch);
                if (dic.ContainsKey(s))
                {
                    dic[s].Add(i);
                }
                else
                {
                    dic.Add(new String(ch), new List<int>() { i });
                }
            }

            foreach (var item in dic.OrderBy(d => d.Value.Count))
            {
                List<string> list = new List<string>();
                foreach (var v in item.Value)
                {
                    list.Add(strs[v]);
                }
                result.Add(list);
            }

            //var c = strs.Select(
            //    (s, i) => new
            //    {
            //        s,
            //        i
            //    })
            //    .OrderBy(x => x.s.Length)
            //    .Select(y => new
            //    {
            //        a = new string(y.s.OrderBy(z => z).ToArray()),
            //        b = y.i
            //    });

            //result = c.GroupBy(x => x.a, elem => strs[elem.b])
            //                               .Select(g => (IList<string>)g.ToList()).ToList();

            return result;
        }
        #endregion

        #region 50. Pow(x, n)
        public double MyPow(double x, int n)
        {
            return powerHelper(x, n);
        }

        private double powerHelper(double x, int n)
        {
            if (n == 0) return 1.0;
            if (n == 1) return x;
            if (n == int.MinValue) return powerHelper(1 / x, int.MaxValue) * 1 / x;
            if (n < 0) return powerHelper((1 / x), -n);
            double result = powerHelper(x * x, n / 2);
            if (n % 2 == 1) result *= x;
            return result;
        }
        #endregion

        #region 51. N-Queens
        public IList<IList<string>> SolveNQueens(int n)
        {
            if (n == 1) return new List<IList<string>>() { new List<string>() { "Q" } };
            IList<IList<string>> result = new List<IList<string>>();
            IList<string> list = new List<string>();
            int[][] board = new int[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new int[n];
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    for (int x = 0; x < n; x++)
                    {
                        board[x] = new int[n];
                    }
                    SolveNQueens_Helper(list, board, i, j);
                }
            }

            list = list.OrderByDescending(x => x).ToList();

            foreach (var item in list)
            {
                int index = 0;
                IList<string> list2 = new List<string>();
                while (index < n * n)
                {
                    list2.Add(item.Substring(index, n));
                    index += n;
                }
                result.Add(list2);
            }

            return result;
        }
        private void SolveNQueens_Helper(IList<string> result, int[][] board, int i, int j)
        {
            if (i == board.Length || j == board.Length) return;
            for (int k = 1; k <= board.Length; k++)
            {
                board[i][j] = k;
                if (k == board.Length)
                {
                    fiilCorrespondingBoardValues(board, i, j);
                }
                else
                {
                    fiilCorrespondingBoardValues(board, i, j);
                    bool foundCell = false;
                    for (int x = 0; x < board.Length; x++)
                    {
                        foundCell = false;
                        for (int y = 0; y < board.Length; y++)
                        {
                            if (board[x][y] == 0)
                            {
                                i = x;
                                j = y;
                                foundCell = true;
                                break;
                            }
                        }
                        if (foundCell) break;
                    }
                    if (!foundCell)
                    {
                        return;
                    }
                }
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int a = 0; a < board.Length; a++)
            {
                for (int b = 0; b < board.Length; b++)
                {
                    if (board[a][b] == -1)
                    {
                        stringBuilder.Append('.');
                    }
                    else
                    {
                        stringBuilder.Append('Q');
                    }
                }
            }
            if (!result.Contains(stringBuilder.ToString()))
            {
                result.Add(stringBuilder.ToString());
            }
        }

        private void fiilCorrespondingBoardValues(int[][] board, int i, int j)
        {
            fillDiagonalValues1(board, i + 1, j + 1);
            fillDiagonalValues2(board, i - 1, j - 1);
            fillDiagonalValues3(board, i + 1, j - 1);
            fillDiagonalValues4(board, i - 1, j + 1);
            fillDiagonalValues5(board, i, j - 1);
            fillDiagonalValues6(board, i, j + 1);
            fillDiagonalValues7(board, i + 1, j);
            fillDiagonalValues8(board, i - 1, j);
        }

        private void fillDiagonalValues1(int[][] board, int i, int j)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board.Length || board[i][j] > 0) return;
            board[i][j] = -1;
            fillDiagonalValues1(board, i + 1, j + 1);
        }
        private void fillDiagonalValues2(int[][] board, int i, int j)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board.Length || board[i][j] > 0) return;
            board[i][j] = -1;
            fillDiagonalValues2(board, i - 1, j - 1);

        }
        private void fillDiagonalValues3(int[][] board, int i, int j)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board.Length || board[i][j] > 0) return;
            board[i][j] = -1;
            fillDiagonalValues3(board, i + 1, j - 1);

        }
        private void fillDiagonalValues4(int[][] board, int i, int j)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board.Length || board[i][j] > 0) return;
            board[i][j] = -1;
            fillDiagonalValues4(board, i - 1, j + 1);

        }

        private void fillDiagonalValues5(int[][] board, int i, int j)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board.Length || board[i][j] > 0) return;
            board[i][j] = -1;
            fillDiagonalValues5(board, i, j - 1);
        }
        private void fillDiagonalValues6(int[][] board, int i, int j)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board.Length || board[i][j] > 0) return;
            board[i][j] = -1;
            fillDiagonalValues6(board, i, j + 1);

        }
        private void fillDiagonalValues7(int[][] board, int i, int j)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board.Length || board[i][j] > 0) return;
            board[i][j] = -1;
            fillDiagonalValues7(board, i + 1, j);

        }
        private void fillDiagonalValues8(int[][] board, int i, int j)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board.Length || board[i][j] > 0) return;
            board[i][j] = -1;
            fillDiagonalValues8(board, i - 1, j);

        }
        #endregion

        #region 53. Maximum Subarray
        public int MaxSubArray(int[] nums)
        {
            int max = nums.Max();
            int cur = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > cur + nums[i])
                {
                    cur = nums[i];
                }
                else
                {
                    cur += nums[i];
                }
                max = Math.Max(max, cur);
            }

            return max;
        }
        #endregion

        #region 54. Spiral Matrix
        public IList<int> SpiralOrder(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            IList<int> list = new List<int>();
            int x = 0;
            int y = 0;

            while (list.Count < matrix.Length * matrix[0].Length)
            {
                int a = x;
                int b = y;
                while (b < n)
                {
                    list.Add(matrix[a][b]);
                    b++;
                }
                b--;
                a++;
                while (a < m)
                {
                    list.Add(matrix[a][b]);
                    a++;
                }
                if (list.Count == matrix.Length * matrix[0].Length) break;
                a--;
                b--;
                while (b >= y)
                {
                    list.Add(matrix[a][b]);
                    b--;
                }
                b++;
                a--;
                while (a > x)
                {
                    list.Add(matrix[a][b]);
                    a--;
                }
                x++;
                y++;
                m--;
                n--;
            }


            return list;
        }

        #endregion

        #region 55. Jump Game
        public bool CanJump(int[] nums)
        {
            if (nums[0] == 0) return false;

            int[] dp = new int[nums.Length];
            dp[nums.Length - 1] = 0;

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] + i >= nums.Length - 1)
                {
                    dp[i] = 1;
                }
                else
                {
                    for (int j = 1; j <= nums[i]; j++)
                    {
                        if (dp[i + j] > 0)
                        {
                            dp[i] = dp[i + j] + 1;
                            break;
                        }
                    }
                }
            }
            return dp[0] != 0;
        }
        #endregion

        #region 56. Merge Intervals
        public int[][] Merge(int[][] intervals)
        {
            List<(int, int)> list = new List<(int, int)>();
            Array.Sort(intervals, (a, b) => { return a[0] - b[0]; });
            list.Add((intervals[0][0], intervals[0][1]));
            for (int i = 1; i < intervals.Length; i++)
            {
                int lastIndex = list.Count - 1;
                if (intervals[i][0] <= list[lastIndex].Item2)
                {
                    if (intervals[i][1] > list[lastIndex].Item2)
                    {
                        int firstIndex = list[lastIndex].Item1;
                        list.RemoveAt(lastIndex);
                        list.Add((firstIndex, intervals[i][1]));
                    }
                }
                else
                {
                    list.Add((intervals[i][0], intervals[i][1]));
                }
            }
            int[][] result = new int[list.Count][];
            for (int i = 0; i < list.Count; i++)
            {
                result[i] = new int[] { list[i].Item1, list[i].Item2 };
            }
            return result;
        }

        #endregion

        #region 57. Insert Interval
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0) return new int[][] { newInterval };
            List<(int, int)> lst = new List<(int, int)>();
            int start = newInterval[0];
            int end = newInterval[1];

            var st = Insert_BinarySearch(intervals, 0, intervals.Length - 1, start);
            var en = Insert_BinarySearch(intervals, 0, intervals.Length - 1, end);
            int startIndex = st.Item2;
            int endIndex = en.Item2;

            for (int i = 0; i < startIndex; i++)
            {
                lst.Add((intervals[i][0], intervals[i][1]));
            }

            if (st.Item1)
            {
                if (en.Item1)
                {
                    lst.Add((intervals[startIndex][0], intervals[endIndex][1]));
                }
                else
                {
                    lst.Add((intervals[startIndex][0], end));
                }
            }
            else
            {
                if (en.Item1)
                {
                    lst.Add((start, intervals[endIndex][1]));
                }
                else
                {
                    lst.Add((start, end));
                }
            }

            if (en.Item1)
            {
                endIndex++;
            }

            for (int i = endIndex; i < intervals.Length; i++)
            {
                lst.Add((intervals[i][0], intervals[i][1]));
            }

            int[][] result = new int[lst.Count][];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[] { lst[i].Item1, lst[i].Item2 };
            }

            return result;
        }

        private (bool, int) Insert_BinarySearch(int[][] intervals, int left, int right, int target)
        {
            while (left <= right)
            {
                int mid = left + ((right - left) / 2);

                if ((intervals[mid][0] <= target && intervals[mid][1] >= target)) return (true, mid);

                if (intervals[mid][0] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return (false, left);
        }
        #endregion

        #region 58. Length of Last Word
        public int LengthOfLastWord(string s)
        {
            s = s.Trim();

            if (s.Length == 0) return 0;

            int i = s.Length - 1;
            int result = 0;
            while (i >= 0 && s[i] != ' ')
            {
                result++;
                i--;
            }
            return result;
        }
        #endregion

        #region 59. Spiral Matrix II
        public int[][] GenerateMatrix(int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }
            int counter = 1;
            int start = 0;
            int total = n * n;
            while (counter <= total)
            {
                int i = start;
                int j = start;
                while (j < n)
                {
                    result[i][j] = counter++;
                    j++;
                }
                j--;
                i++;
                while (i < n)
                {
                    result[i][j] = counter++;
                    i++;
                }
                i--;
                j--;
                while (j >= start)
                {
                    result[i][j] = counter++;
                    j--;
                }
                j++;
                i--;
                while (i > start)
                {
                    result[i][j] = counter++;
                    i--;
                }
                n--;
                start++;
            }

            return result;
        }
        #endregion

        #region 61. Rotate List
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null) return null;
            Stack<ListNode> stack = new Stack<ListNode>();
            stack.Push(head);

            while (stack.Peek().Next != null)
            {
                stack.Push(stack.Peek().Next);
            }
            k = k % stack.Count;
            if (k == 0) return head;
            stack.Peek().Next = head;
            ListNode temp = stack.Peek();
            for (int i = 0; i < k; i++)
            {
                temp = stack.Pop();
            }
            ListNode next = stack.Peek();
            next.Next = null;

            return temp;
        }
        #endregion

        #region 66. Plus One
        public int[] PlusOne(int[] digits)
        {
            int carryOn = 1;
            int lastDigit = digits.LastOrDefault();
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int res = digits[i] + carryOn;
                if (res <= 9)
                {
                    carryOn = 0;
                    digits[i] = res;
                    break;
                }
                else
                {
                    digits[i] = 0;
                }
            }

            return carryOn == 1 ? digits.Prepend(carryOn).ToArray() : digits;
        }
        #endregion

        #region 62. Unique Paths
        public int UniquePaths(int m, int n)
        {
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = Enumerable.Repeat(-1, n).ToArray();
            }
            return solveUniquePaths(dp, m - 1, n - 1);
        }

        private int solveUniquePaths(int[][] dp, int i, int j)
        {
            if (i == 0 && j == 0) return 1;

            if (i < 0 || j < 0) return 0;

            if (dp[i][j] != -1) return dp[i][j];

            dp[i][j] = solveUniquePaths(dp, i - 1, j) + solveUniquePaths(dp, i, j - 1);
            return dp[i][j];
        }
        #endregion

        #region 63. Unique Paths II 
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;
            if (obstacleGrid[0][0] == 1 || obstacleGrid[m - 1][n - 1] == 1) return 0;

            int[][] dp = new int[m][];

            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    dp[i][j] = obstacleGrid[i][j] == 1 ? 0 : 1;
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dp[i][j] == int.MaxValue) continue;
                    if (i == 0 && j == 0)
                    {
                        dp[i][j] = 1;
                    }
                    else if (i == 0)
                    {
                        dp[i][j] = dp[i][j - 1];
                    }
                    else if (j == 0)
                    {
                        dp[i][j] = dp[i - 1][j];
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                    }
                }
            }

            return dp[m - 1][n - 1] == int.MaxValue ? 0 : dp[m - 1][n - 1];
        }
        public int UniquePathsWithObstacles_V1(int[][] obstacleGrid)
        {
            List<(int, int)> obstacles = new List<(int, int)>();
            for (int i = 0; i < obstacleGrid.Length; i++)
            {
                for (int j = 0; j < obstacleGrid[i].Length; j++)
                {
                    if (obstacleGrid[i][j] == 1) obstacles.Add((i, j));
                }
            }

            int[][] dp = new int[obstacleGrid.Length][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[obstacleGrid[i].Length];
            }
            bool fillZero = obstacles.Contains((0, 0));
            for (int j = 1; j < dp[0].Length; j++)
            {
                if (obstacles.Contains((0, j)) || fillZero)
                {
                    dp[0][j] = 0;
                    fillZero = true;
                }
                else
                {
                    dp[0][j] = 1;
                }
            }
            fillZero = obstacles.Contains((0, 0));
            for (int j = 1; j < dp.Length; j++)
            {
                if (obstacles.Contains((j, 0)) || fillZero)
                {
                    dp[j][0] = 0;
                    fillZero = true;
                }
                else
                {
                    dp[j][0] = 1;
                }
            }
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[i].Length; j++)
                {
                    if (obstacles.Contains((i, j)))
                    {
                        dp[i][j] = 0;
                    }
                    else
                    {
                        int leftVal = dp[i - 1][j];
                        int topVal = dp[i][j - 1];
                        dp[i][j] = leftVal + topVal;
                    }

                }
            }

            return dp[obstacleGrid.Length - 1][obstacleGrid[0].Length - 1];
        }
        #endregion

        #region 64. Minimum Path Sum
        public int MinPathSum(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (i == 0 && j == 0) continue;

                    grid[i][j] = getVal(grid, i, j);
                }
            }
            return grid[grid.Length - 1][grid[0].Length - 1];
        }

        private int getVal(int[][] grid, int i, int j)
        {
            int topval = j == 0 ? int.MaxValue : grid[i][j - 1];
            int leftVal = i == 0 ? int.MaxValue : grid[i - 1][j];

            return Math.Min(topval, leftVal) + grid[i][j];
        }
        #endregion

        #region 67. Add Binary
        public string AddBinary(string a, string b)
        {

            List<char> list = new List<char>();
            int carryOn = 0;

            int alen = a.Length - 1;
            int blen = b.Length - 1;

            while (alen >= 0 || blen >= 0)
            {
                int num1 = alen >= 0 ? a[alen] - '0' : 0;
                int num2 = blen >= 0 ? b[blen] - '0' : 0;

                int res = num1 + num2 + carryOn;

                if (res < 2)
                {
                    list.Add((char)(res + (int)'0'));
                    carryOn = 0;
                }
                else
                {
                    if (res == 2)
                    {
                        list.Add('0');
                    }
                    else
                    {
                        list.Add('1');
                    }
                    carryOn = 1;
                }

                alen--;
                blen--;
            }
            if (carryOn == 1)
            {
                list.Add('1');
            }
            return new string(list.ToArray().Reverse().ToArray());
        }
        #endregion

        #region 69. Sqrt(x)
        public int MySqrt(int x)
        {
            if (x <= 1) return x;

            int i = 1;
            int sqr = 1;

            while (sqr < x)
            {
                if (int.MaxValue - (i + i + 1) < sqr) return i;
                sqr = sqr + i + i + 1;
                if (sqr == x)
                {
                    return i + 1;
                }
                i++;
            }


            return i - 1;
        }
        #endregion

        #region 70. Climbing Stairs
        public int ClimbStairs(int n)
        {
            if (n <= 3) return n;

            int one = 2;
            int two = 3;

            for (int i = 4; i <= n; i++)
            {
                int temp = one + two;

                one = two;
                two = temp;
            }
            return two;
        }
        #endregion

        #region 71. Simplify Path
        public string SimplifyPath(string path)
        {
            if (!path.StartsWith("/")) return "";

            string[] strs = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>();
            foreach (string str in strs)
            {
                if (str == ".") continue;
                if (str == "..")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                        continue;
                    }
                }
                stack.Push(str);

            }
            StringBuilder stringBuilder = new StringBuilder();

            while (stack.Count > 0)
            {
                stringBuilder.Insert(0, stack.Pop());
                stringBuilder.Insert(0, "/");
            }

            return stringBuilder.Length == 0 ? "/" : stringBuilder.ToString();
        }
        #endregion

        #region 72. Edit Distance
        public int MinDistance(string word1, string word2)
        {
            int i;
            int m = word1.Length;
            int n = word2.Length;
            int[][] dp = new int[m + 1][];

            for (i = 0; i <= m; i++)
            {
                dp[i] = new int[n + 1];
            }
            int j;
            int c;
            for (i = 0; i < m + 1; i++)
            {
                for (j = 0; j < n + 1; j++)
                {
                    c = int.MaxValue;
                    if (i == 0)
                    {
                        dp[i][j] = j;

                    }
                    else if (j == 0)
                    {
                        dp[i][j] = i;
                    }
                    if (i != 0 && j != 0)
                    {

                        if (word1[i - 1] == word2[j - 1])
                        {
                            dp[i][j] = dp[i - 1][j - 1];
                        }
                        if (word1[i - 1] != word2[j - 1])
                        {
                            c = Math.Min(c, dp[i - 1][j - 1]);
                            c = Math.Min(c, dp[i][j - 1]);
                            c = Math.Min(c, dp[i - 1][j]);
                            dp[i][j] = 1 + c;
                        }
                    }

                }
            }
            return dp[m][n];
            //if (word1.Length == 0) return word2.Length;

            //if (word2.Length == 0) return word1.Length;
            //int m = word1.Length;
            //int n = word2.Length;

            //int[][] dp = new int[m][];
            //for (int i = 0; i < m; i++)
            //{
            //    dp[i] = new int[n];
            //}
            //for (int i = 0; i < m; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        dp[i][j] = word1[i] == word2[j] ? 0 : 1;
            //    }
            //}

            //for (int i = 1; i < dp[0].Length; i++)
            //{
            //    dp[0][i] = dp[0][i - 1] + dp[0][i];
            //}

            //for (int i = 1; i < dp.Length; i++)
            //{
            //    dp[i][0] = dp[i - 1][0] + dp[i][0];
            //}
            //for (int i = 1; i < dp.Length; i++)
            //{
            //    for (int j = 1; j < dp[0].Length; j++)
            //    {
            //        dp[i][j] = getValue(dp, i, j);
            //    }
            //}

            //return dp[m - 1][n - 1];
        }

        private int getValue(int[][] dp, int i, int j)
        {

            int leftVal = dp[i][j - 1];
            int topVal = dp[i - 1][j];
            int diagoalVal = dp[i - 1][j - 1];

            int min = Math.Min(topVal, Math.Min(leftVal, diagoalVal));

            return min + dp[i][j];
        }

        private void dynamicUpdate(int[][] dp, int i, int j, ref int result)
        {
            if (i >= dp.Length || j >= dp[0].Length) return;

            if (dp[i][j] == 0)
            {
                dp[i][j] = result;

                if (i + 1 == dp.Length && j + 1 == dp[0].Length) return;

                if (i + 1 < dp.Length) i++;
                if (j + 1 < dp[0].Length) j++;

                dynamicUpdate(dp, i, j, ref result);
            }
            else
            {
                result = result + dp[i][j];

                dp[i][j] = result;


                if (i + 1 < dp.Length && dp[i + 1][j] == 0)
                {
                    dynamicUpdate(dp, i + 1, j, ref result);
                }
                else if (j + 1 < dp[0].Length && dp[i][j + 1] == 0)
                {
                    dynamicUpdate(dp, i, j + 1, ref result);
                }
                else if (i + 1 < dp.Length && j + 1 < dp[0].Length)
                {
                    dynamicUpdate(dp, i + 1, j + 1, ref result);
                }
                else if (i + 1 < dp.Length)
                {
                    dynamicUpdate(dp, i + 1, j, ref result);
                }
                else
                {
                    dynamicUpdate(dp, i, j + 1, ref result);
                }
            }
        }
        #endregion

        #region 73. Set Matrix Zeroes

        public void SetZeroes(int[][] matrix)
        {
            List<(int, int)> nonZero = new List<(int, int)>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (!nonZero.Contains((i, j)) && matrix[i][j] == 0)
                    {
                        for (int x = 0; x < matrix[i].Length; x++)
                        {
                            if (matrix[i][x] != 0)
                            {
                                nonZero.Add((i, x));
                            }
                            matrix[i][x] = 0;
                        }
                        for (int x = 0; x < matrix.Length; x++)
                        {
                            if (matrix[x][j] != 0)
                            {
                                nonZero.Add((x, j));
                            }
                            matrix[x][j] = 0;
                        }
                    }
                }
            }

            //foreach (var item in zeroCoordCol)
            //{
            //    for (int i = 0; i < matrix.Length; i++)
            //    {
            //        matrix[i][item] = 0;
            //    }
            //}

            //foreach (var item in zeroCoordRow)
            //{
            //    for (int i = 0; i < matrix[item].Length; i++)
            //    {
            //        matrix[item][i] = 0;
            //    }
            //}
        }

        public void SetZeroesV1(int[][] matrix)
        {
            List<int> zeroCoordRow = new List<int>();
            List<int> zeroCoordCol = new List<int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {

                    if (matrix[i][j] == 0)
                    {
                        if (!zeroCoordCol.Contains(j)) zeroCoordCol.Add(j);
                        if (!zeroCoordRow.Contains(i)) zeroCoordRow.Add(i);
                    }
                }
            }

            foreach (var item in zeroCoordCol)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][item] = 0;
                }
            }

            foreach (var item in zeroCoordRow)
            {
                for (int i = 0; i < matrix[item].Length; i++)
                {
                    matrix[item][i] = 0;
                }
            }
        }
        #endregion

        #region 74. Search a 2D Matrix
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int low = 0;
            int high = matrix.Length - 1;
            int rowIndex = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (matrix[mid][0] <= target && matrix[mid][matrix[mid].Length - 1] >= target)
                {
                    rowIndex = mid;
                    break;
                }
                else
                {
                    if (matrix[mid][0] < target)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }


            }
            if (rowIndex != -1)
            {
                low = 0;
                high = matrix[rowIndex].Length - 1;

                while (low <= high)
                {
                    int mid = low + (high - low) / 2;

                    if (matrix[rowIndex][mid] == target) return true;

                    if (matrix[rowIndex][mid] > target)
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
            }
            return false;
        }
        #endregion

        #region 75. Sort Colors

        int rIndex = -1;
        int wIndex = -1;
        bool bIndex = false;

        public void SortColors(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                SortColors_helper(nums, i);
                i++;
            }
        }

        private void SortColors_helper(int[] nums, int i)
        {
            if (nums[i] == 0)
            {
                rIndex++;
                if (wIndex != -1)
                {
                    wIndex++;
                }
            }

            if (nums[i] == 1)
            {
                if (wIndex != -1)
                {
                    wIndex++;
                }
                else
                {
                    wIndex = rIndex + 1;
                }
            }

            if (nums[i] == 2)
            {
                bIndex = true;
            }

            if (i - 1 < 0 || nums[i] >= nums[i - 1]) return;

            switch (nums[i])
            {
                case 0:

                    if (wIndex == -1)
                    {
                        nums[rIndex] = 0;
                        nums[i] = 2;
                    }
                    else
                    {
                        nums[rIndex] = 0;
                        nums[wIndex] = 1;
                        nums[i] = bIndex ? 2 : 1;
                    }
                    break;
                case 1:
                    nums[wIndex] = 1;
                    nums[i] = 2;
                    break;
            }
        }

        #endregion

        #region 85. Maximal Rectangle
        public int MaximalRectangle(char[][] matrix)
        {
            int[][] intArray = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                intArray[i] = new int[matrix[i].Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (i == 0)
                    {
                        intArray[i][j] = matrix[i][j] - '0';
                    }
                    else
                    {
                        if (matrix[i][j] != '0')
                        {
                            intArray[i][j] = intArray[i - 1][j] + matrix[i][j] - '0';
                        }
                    }
                }
            }


            return 0;
        }

        #endregion

        #region 94. Binary Tree Inorder Traversal
        public IList<int> InorderTraversal_ByStack(TreeNode root)
        {
            IList<int> list = new List<int>();

            if (root != null)
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);

                while (stack.Count > 0)
                {
                    TreeNode treeNode = stack.Peek();

                    if (treeNode.left != null)
                    {
                        stack.Push(treeNode.left);
                        treeNode.left = null;
                    }
                    else
                    {
                        list.Add(treeNode.val);
                        stack.Pop();
                        if (treeNode.right != null)
                        {
                            stack.Push((TreeNode)treeNode.right);
                            treeNode.right = null;
                        }
                    }
                }
            }

            return list;
        }


        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();

            if (root != null)
            {
                InorderTraversalHelper(list, root);
            }
            return list;
        }

        private void InorderTraversalHelper(IList<int> list, TreeNode root)
        {
            if (root == null) return;
            InorderTraversalHelper(list, root.left);
            list.Add(root.val);
            InorderTraversalHelper(list, root.right);
        }

        #endregion

        #region 98. Validate Binary Search Tree

        public bool IsValidBST(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null)) return true;
            if (root.left != null && root.val <= root.left.val)
            {
                return false;
            }
            if (root.right != null && root.val >= root.right.val)
            {
                return false;
            }
            return IsValidBSTHelper(root.left, root.val - 1) && IsValidBSTHelper(root.right, root.val + 1);
        }

        private bool IsValidBSTHelper(TreeNode treeNode, int maxVal)
        {
            return false;
            //if (treeNode == null) return true;
            //if ((treeNode.val < maxVal) || (treeNode.val > right)) return false;
            //return IsValidBSTHelper(treeNode.left, left, treeNode.val - 1) && IsValidBSTHelper(treeNode.right, treeNode.val + 1, right);
        }
        #endregion

        #region 100. Same Tree
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;

            if ((p == null && q != null) || (p != null && q == null)) return false;

            return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        #endregion

        #region 101. Symmetric Tree
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return IsSymmetricHelper(root.left, root.right);
        }

        private bool IsSymmetricHelper(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
                return left == right;
            if (left.val != right.val)
                return false;
            return IsSymmetricHelper(left.left, right.right) && IsSymmetricHelper(left.right, right.left);
        }
        #endregion

        #region 102. Binary Tree Level Order Traversal

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> level = new List<IList<int>>();

            if (root != null)
            {
                Queue<(int, TreeNode)> q = new Queue<(int, TreeNode)>();

                q.Enqueue((0, root));

                while (q.Count > 0)
                {
                    var d = q.Dequeue();
                    int l = d.Item1;
                    TreeNode treeNode = d.Item2;
                    if (level.Count == l)
                    {
                        level.Add(new List<int>());
                    }

                    level[l].Add(treeNode.val);

                    if (treeNode.left != null)
                    {
                        q.Enqueue((l + 1, treeNode.left));
                    }
                    if (treeNode.right != null)
                    {
                        q.Enqueue((l + 1, treeNode.right));
                    }
                }
            }
            return level;
        }

        #endregion

        #region 103. Binary Tree Zigzag Level Order Traversal

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> level = new List<IList<int>>();

            if (root != null)
            {
                Stack<(int, TreeNode)> stack1 = new Stack<(int, TreeNode)>();
                Stack<(int, TreeNode)> stack2 = new Stack<(int, TreeNode)>();

                stack1.Push((0, root));

                while (stack1.Count > 0 || stack2.Count > 0)
                {
                    while (stack1.Count > 0)
                    {
                        var t = stack1.Pop();
                        TreeNode treeNode = t.Item2;
                        int l = t.Item1;

                        if (level.Count == l)
                        {
                            level.Add(new List<int>());
                        }
                        else
                        {
                            level[l].Add((int)treeNode.val);
                        }

                        if (treeNode.left != null)
                        {
                            stack2.Push((l + 1, treeNode.left));
                        }

                        if (treeNode.right != null)
                        {
                            stack2.Push((l + 1, treeNode.right));
                        }

                    }

                    while (stack2.Count > 0)
                    {
                        var t = stack2.Pop();
                        TreeNode treeNode = t.Item2;
                        int l = t.Item1;

                        if (level.Count == l)
                        {
                            level.Add(new List<int>());
                        }
                        else
                        {
                            level[l].Add((int)treeNode.val);
                        }

                        if (treeNode.right != null)
                        {
                            stack1.Push((l + 1, treeNode.right));
                        }

                        if (treeNode.left != null)
                        {
                            stack1.Push((l + 1, treeNode.left));
                        }
                    }
                }
            }
            return level;
        }

        #endregion

        #region 104. Maximum Depth of Binary Tree
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            if (root.left == null && root.right == null) return 1;

            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }
        #endregion

        #region 107. Binary Tree Level Order Traversal II
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> level = new List<IList<int>>();

            if (root != null)
            {
                Queue<(int, TreeNode)> q = new Queue<(int, TreeNode)>();

                q.Enqueue((0, root));

                while (q.Count > 0)
                {
                    var d = q.Dequeue();
                    int l = d.Item1;
                    TreeNode treeNode = d.Item2;
                    if (level.Count == l)
                    {
                        level.Insert(0, new List<int>());
                    }

                    level[0].Add(treeNode.val);

                    if (treeNode.left != null)
                    {
                        q.Enqueue((l + 1, treeNode.left));
                    }
                    if (treeNode.right != null)
                    {
                        q.Enqueue((l + 1, treeNode.right));
                    }
                }
            }
            return level;
        }
        #endregion

        #region 111. Minimum Depth of Binary Tree
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            if (root.left == null && root.right == null) return 1;

            if (root.left == null)
            {
                return 1 + MinDepth(root.right);
            }
            else if (root.right == null)
            {
                return 1 + MinDepth(root.left);
            }
            else
            {

                return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
            }
        }
        #endregion

        #region 112. Path Sum

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            if (root.val == targetSum) return true;

            int val = root.val;

            if (root.left != null)
            {
                root.left.val += val;
                bool leftResult = HasPathSum(root.left, targetSum);
                if (leftResult)
                {
                    return true;
                }
            }
            if (root.right != null)
            {
                root.right.val += val;
                bool leftResult = HasPathSum(root.right, targetSum);
                if (leftResult)
                {
                    return true;
                }
            }
            return false;
        }



        #endregion

        #region 116. Populating Next Right Pointers in Each Node
        public Node Connect(Node root)
        {
            if (root != null)
            {
                Queue<(int, Node)> q = new Queue<(int, Node)>();
                q.Enqueue((0, root));

                while (q.Count > 0)
                {
                    var q1 = q.Dequeue();

                    int l = q1.Item1;
                    Node n = q1.Item2;


                    if (q.Count != 0 && q.Peek().Item1 == l)
                    {
                        n.Next = q.Peek().Item2;
                    }

                    if (n.Left != null) q.Enqueue((l + 1, n.Left));
                    if (n.Right != null) q.Enqueue((l + 1, n.Right));
                }
            }
            return root;
        }
        #endregion

        #region 167. Two Sum II - Input Array Is Sorted
        public int[] TwoSum(int[] numbers, int target)
        {
            int low = 0;
            int end = numbers.Length - 1;

            while (low < end)
            {
                int sum = numbers[low] + numbers[end];

                if (sum == target) break;

                if (sum > target)
                {
                    end--;
                }
                else
                {
                    low++;
                }
            }

            return new int[] { low, end };
        }
        #endregion

        #region 200. Number of Islands
        public int NumIslands(char[][] grid)
        {
            int result = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        result++;
                        fillConnected(grid, i, j);
                    }
                }
            }

            return result;
        }

        private void fillConnected(char[][] grid, int x, int y)
        {
            Queue<(int, int)> q = new Queue<(int, int)>();
            q.Enqueue((x, y));
            grid[x][y] = 'v';
            while (q.Count > 0)
            {
                var p = q.Dequeue();
                int i = p.Item1;
                int j = p.Item2;

                //i, j+1
                isConnectedCell(grid, q, i, j + 1);
                //i, j-1
                isConnectedCell(grid, q, i, j - 1);
                //i+1, j
                isConnectedCell(grid, q, i + 1, j);
                //i-1, j
                isConnectedCell(grid, q, i - 1, j);
            }
        }

        private void isConnectedCell(char[][] grid, Queue<(int, int)> q, int i, int j)
        {
            if (i >= 0 && j >= 0 && i < grid.Length && j < grid[i].Length && grid[i][j] == '1')
            {
                grid[i][j] = 'v';
                q.Enqueue((i, j));
            }
        }
        #endregion

        #region 206. Reverse Linked List
        public ListNode ReverseList_v1(ListNode head)
        {
            if (head == null) return head;

            Stack<ListNode> stack = new Stack<ListNode>();

            while (head != null)
            {
                stack.Push(head);
                head = head.Next;
            }
            ListNode newNode = stack.Pop();

            ListNode temp = newNode;

            while (stack.Count > 0)
            {
                temp.Next = stack.Pop();
                temp = temp.Next;
            }
            return newNode;
        }
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            return final_reverse(head, null);
        }
        private ListNode final_reverse(ListNode head, ListNode prev)
        {
            ListNode temp = head.Next;
            head.Next = prev;
            if (temp == null)
            {
                return head;
            }
            return final_reverse(temp, head);
        }
        #endregion

        #region 216. Combination Sum III
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> list = new List<IList<int>>();

            CombinationSum3_Helper(list, new LinkedList<int>(), 1, k, n);

            return list;
        }

        private void CombinationSum3_Helper(IList<IList<int>> list, LinkedList<int> ll, int start, int k, int target)
        {
            if (k < 0 || target < 0)
            {
                return;
            }

            if (k == 0 && target == 0)
            {
                list.Add(ll.ToList());
                return;
            }

            for (int i = start; i <= 9; i++)
            {
                ll.AddLast(i);
                CombinationSum3_Helper(list, ll, i + 1, k - 1, target - i);
                ll.RemoveLast();
            }
        }
        #endregion

        #region 263. Ugly Number

        public bool IsUgly(int n)
        {
            return false;
        }

        #endregion

        #region 264. Ugly Number II
        public int NthUglyNumber(int n)
        {
            if (n == 1) return 1;
            List<int> list = new List<int>();
            list.Add(1);
            NthUglyNumber_helper(list, n, 2);
            return list.Last();
        }

        private void NthUglyNumber_helper(List<int> list, int n, int curr)
        {
            if (curr % 2 == 0 || curr % 3 == 0 || curr % 5 == 0)
            {
                list.Add((int)curr);
                if (list.Count == n) return;
            }

            NthUglyNumber_helper(list, n, curr + 1);

        }

        //private List<int> factors(int n)
        //{
        //    List<int> factors = new List<int>();

        //    for (int i = 2; i < length; i++)
        //    {

        //    }

        //    return factors;
        //}

        #endregion

        #region 283. Move Zeroes
        public void MoveZeroes(int[] nums)
        {
            int zeros = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    zeros++;
                }
                else
                {
                    nums[i - zeros] = nums[i];
                }
            }

            for (int i = nums.Length - zeros; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
        #endregion

        #region 322. Coin Change
        public int CoinChange(int[] coins, int amount)
        {
            long target = (long)amount;
            List<int>[] table = new List<int>[target + 1];
            table[0] = new List<int>();

            for (int i = 0; i < amount; i++)
            {
                foreach (int coin in coins)
                {
                    if (coin > amount) continue;
                    List<int> comb = new List<int>();
                    if (table[i] != null && i + coin <= amount)
                    {
                        comb.AddRange(table[i]);
                        comb.Add(coin);
                        if (table[i + coin] is null || table[i + coin].Count > comb.Count)
                        {
                            table[i + coin] = comb;
                        }
                    }
                }
            }
            return table[amount] is null ? -1 : table[amount].Count;
        }
        #endregion

        #region 329. Longest Increasing Path in a Matrix
        public int LongestIncreasingPath(int[][] matrix)
        {
            int result = 0;
            List<(int, int, int)> path = new List<(int, int, int)>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    path.Add((matrix[i][j], i, j));
                }
            }
            path = path.OrderBy(x => x.Item1).ToList();
            int[][] dp = new int[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                dp[i] = Enumerable.Repeat(1, matrix[i].Length).ToArray();
            }

            foreach (var item in path)
            {
                updateDp(dp, matrix, item.Item2, item.Item3);
            }

            foreach (var item in dp)
            {
                result = Math.Max(result, item.Max());
            }
            return result;

        }

        private void updateDp(int[][] dp, int[][] matrix, int x, int y)
        {
            int val = dp[x][y];
            int matrixOld = matrix[x][y];
            //check top and update x-1, y
            checkCell(dp, matrix, x - 1, y, val + 1, matrixOld);

            //check bottom and update x+1, y
            checkCell(dp, matrix, x + 1, y, val + 1, matrixOld);

            //check left and update x, y
            checkCell(dp, matrix, x, y - 1, val + 1, matrixOld);

            //check right and update x, y
            checkCell(dp, matrix, x, y + 1, val + 1, matrixOld);
        }

        private void checkCell(int[][] dp, int[][] matrix, int x, int y, int v, int matrixOld)
        {
            if (x >= 0 && x < dp.Length && y >= 0 && y < dp[x].Length && v > dp[x][y] && matrixOld < matrix[x][y])
            {
                dp[x][y] = v;
            }
        }
        #endregion

        #region 344. Reverse String
        public void ReverseString(char[] s)
        {
            int low = 0;
            int end = s.Length - 1;

            while (low < end)
            {
                char temp = s[low];
                s[low] = s[end];
                s[end] = temp;
                low++;
                end--;
            }
        }
        #endregion

        #region 367. Valid Perfect Square
        public bool IsPerfectSquare(int num)
        {
            if (num == 1) return true;

            int low = 2;
            int high = num / 2;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                long sqr = (long)mid * (long)mid;

                if (sqr == num) return true;

                if (sqr < num)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return false;
        }
        #endregion

        #region 399  Evaluate Division

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, List<Node_V1>> nodes = buildGraph(equations, values);
            double[] result = new double[queries.Count];

            for (int i = 0; i < queries.Count; i++)
            {
                result[i] = dfs(nodes, queries[i][0], queries[i][1], new HashSet<string>());
            }

            return result;
        }

        private double dfs(Dictionary<string, List<Node_V1>> nodes, string src, string dest, HashSet<string> visited)
        {

            if (!nodes.ContainsKey(src) || !nodes.ContainsKey(dest)) return -1.0;

            if (src == dest) return 1.0;

            visited.Add(src);

            foreach (var node in nodes[src])
            {
                if (!visited.Contains(node.Key))
                {

                    double ans = dfs(nodes, node.Key, dest, visited);

                    if (ans != -1.0)
                    {
                        return ans * node.Value;
                    }
                }
            }

            return -1.0;
        }

        private Dictionary<string, List<Node_V1>> buildGraph(IList<IList<string>> equations, double[] values)
        {
            Dictionary<string, List<Node_V1>> graph = new Dictionary<string, List<Node_V1>>();

            for (int i = 0; i < equations.Count; i++)
            {
                var equation = equations[i];
                string node1 = equation[0];
                string node2 = equation[1];

                double val = values[i];

                updateGraph(graph, node1, node2, val);
                updateGraph(graph, node2, node1, 1 / val);
            }

            return graph;
        }

        private void updateGraph(Dictionary<string, List<Node_V1>> graph, string key, string dest, double value)
        {
            Node_V1 node = new Node_V1(dest, value);
            if (graph.ContainsKey(key))
            {
                graph[key].Add(node);
            }
            else
            {
                graph.Add(key, new List<Node_V1>() { node });
            }
        }


        #endregion

        #region 456. 132 Pattern
        public bool Find132pattern(int[] nums)
        {
            if (nums.Length < 3) return false;
            int[] min = new int[nums.Length];
            min[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                min[i] = Math.Min(min[i - 1], nums[i]);
            }

            Stack<int> stack = new Stack<int>();

            for (int i = nums.Length - 1; i >= 0; i++)
            {
                if (nums[i] > min[i])
                {
                    while (stack.Count > 0 && stack.Peek() <= min[i])
                    {
                        stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() < nums[i]) return true;

                    stack.Push(nums[i]);
                }
            }
            return false;
        }
        #endregion

        #region 417. Pacific Atlantic Water Flow
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            int m = heights.Length;
            int n = heights[0].Length;
            IList<IList<int>> list = new List<IList<int>>();

            bool[][] pacificOcean = new bool[m][];
            bool[][] atlanticOcean = new bool[m][];

            for (int i = 0; i < m; i++)
            {
                pacificOcean[i] = new bool[n];
                atlanticOcean[i] = new bool[n];
            }
            for (int i = 0; i < n; i++)
            {
                PacificAtlantic_Helper(heights, 0, i, int.MinValue, pacificOcean);
                PacificAtlantic_Helper(heights, m - 1, i, int.MinValue, atlanticOcean);
            }

            for (int i = 0; i < m; i++)
            {
                PacificAtlantic_Helper(heights, i, 0, int.MinValue, pacificOcean);
                PacificAtlantic_Helper(heights, n - 1, i, int.MinValue, atlanticOcean);
            }


            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (pacificOcean[i][j] && atlanticOcean[i][j]) list.Add(new List<int>() { i, j });
                }
            }


            return list;
        }

        private void PacificAtlantic_Helper(int[][] heights, int x, int y, int prev, bool[][] ocean)
        {
            if (x < 0 || y < 0 || x == heights.Length || y == heights[x].Length || ocean[x][y] || heights[x][y] < prev) return;

            ocean[x][y] = true;

            PacificAtlantic_Helper(heights, x + 1, y, heights[x][y], ocean);
            PacificAtlantic_Helper(heights, x - 1, y, heights[x][y], ocean);
            PacificAtlantic_Helper(heights, x, y + 1, heights[x][y], ocean);
            PacificAtlantic_Helper(heights, x, y - 1, heights[x][y], ocean);
        }
        #endregion

        #region 496. Next Greater Element I
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int[] dp = Enumerable.Repeat(-1, nums2.Length).ToArray();

            Stack<int> stack = new Stack<int>();
            stack.Push(nums2.Length - 1);
            for (int i = nums2.Length - 2; i >= 0; i--)
            {
                while (stack.Count > 0 && nums2[stack.Peek()] <= nums2[i])
                {
                    stack.Pop();
                }
                if (stack.Count == 0)
                {
                    dp[i] = -1;
                }
                else
                {
                    dp[i] = stack.Peek();
                }
                stack.Push(i);
            }

            int[] result = new int[nums1.Length];

            for (int i = 0; i < nums1.Length; i++)
            {
                int index = Array.IndexOf(nums2, nums1[i]);

                result[i] = dp[index] == -1 ? -1 : nums2[dp[index]];
            }

            return result;
        }
        #endregion

        #region 503. Next Greater Element II
        public int[] NextGreaterElements(int[] nums)
        {
            int[] result = new int[(int)nums.Length];

            int[] dp = new int[nums.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[stack.Peek()] <= nums[i])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    int k = nums[i];
                    int j = 0;
                    while (nums[j] <= k && j < i)
                    {
                        j++;
                    }
                    dp[i] = j == i ? -1 : j;
                }
                else
                {
                    dp[i] = stack.Peek();
                }
                stack.Push(i);
            }

            for (int i = 0; i < result.Length; i++)
            {
                if (dp[i] == -1)
                {
                    result[i] = -1;
                }
                else
                {
                    result[i] = nums[dp[i]];
                }
            }
            return result;
        }
        #endregion

        #region 542. 01 Matrix
        public int[][] UpdateMatrix(int[][] mat)
        {
            int[][] dp = new int[mat.Length][];
            bool[][] visited = new bool[mat.Length][];
            for (int i = 0; i < mat.Length; i++)
            {
                dp[i] = new int[mat[i].Length];
                visited[i] = new bool[mat[i].Length];
            }
            Queue<(int, int, int)> q = new Queue<(int, int, int)>();
            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j < dp[i].Length; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        q.Enqueue((0, i, j));
                        visited[i][j] = true;
                    }
                }
            }

            while (q.Count > 0)
            {
                (int val, int x, int y) = q.Dequeue();

                updatecells(mat, dp, visited, q, x + 1, y, val + 1);
                updatecells(mat, dp, visited, q, x - 1, y, val + 1);
                updatecells(mat, dp, visited, q, x, y + 1, val + 1);
                updatecells(mat, dp, visited, q, x, y - 1, val + 1);
            }
            return dp;
        }

        private void updatecells(int[][] mat, int[][] dp, bool[][] visited, Queue<(int, int, int)> q, int x, int y, int v)
        {
            if (x < 0 || y < 0 || x == mat.Length || y == mat[x].Length || visited[x][y] || mat[x][y] == 0 || v < mat[x][y]) return;
            dp[x][y] = v;
            q.Enqueue((v, x, y));
            visited[x][y] = true;
        }
        #endregion

        #region 556. Next Greater Element III
        public int NextGreaterElement(int n)
        {
            if (n == int.MaxValue) return -1;
            List<int> numlist = new List<int>();

            while (n > 0)
            {
                int rem = n % 10;
                numlist.Insert(0, rem);

                n /= 10;
            }
            int swapIndex = -1;
            for (int i = numlist.Count - 1; i > 0; i--)
            {
                if (numlist[i] > numlist[i - 1])
                {
                    if (numlist.Count == 10 && i == 1 && numlist[i] > 1) return -1;
                    swapIndex = i - 1;
                    break;
                }
            }
            if (swapIndex == -1) return -1;

            var p = numlist.Skip(swapIndex + 1).Take(numlist.Count - swapIndex).ToArray();
            Array.Sort(p);

            for (int i = 0; i < p.Length; i++)
            {
                if (numlist[swapIndex] < p[i])
                {
                    int temp = p[i];
                    p[i] = numlist[swapIndex];
                    numlist[swapIndex] = temp;
                    break;
                }
            }
            swapIndex++;
            for (int i = swapIndex; i < numlist.Count; i++)
            {
                numlist[i] = p[i - swapIndex];
            }
            int result = 0;

            foreach (var item in numlist)
            {
                result = (result * 10) + item;
            }

            return result < 0 ? -1 : result;
        }
        #endregion

        #region 557. Reverse Words in a String III
        public string ReverseWords(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in s.Split(' '))
            {
                char[] chs = item.ToCharArray();
                ReverseString(chs);
                var s1 = new string(chs);
                stringBuilder.Append(s1);
                stringBuilder.Append(' ');
            }
            return stringBuilder.ToString().Trim();
        }
        #endregion

        #region 567. Permutation in String
        public bool CheckInclusion(string s1, string s2)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int i = 0;
            while (i < s1.Length)
            {
                if (map.ContainsKey(s1[i]))
                {
                    map[s1[i]]++;
                }
                else
                {
                    map.Add(s1[i], 1);
                }
                i++;
            }

            i = 0;
            while (i < s2.Length)
            {
                if (map.ContainsKey(s2[i]))
                {
                    if (isValid(new Dictionary<char, int>(map), s2.Substring(i, s1.Length)))
                    {
                        return true;
                    }
                }
                i++;
            }
            return false;
        }

        private bool isValid(Dictionary<char, int> map, string sub)
        {
            int i = 0;
            while (i < sub.Length)
            {
                char c = sub[i];
                if (!map.ContainsKey(c)) return false;
                if (map[c] == 1)
                {
                    map.Remove(c);
                }
                else
                {
                    map[c]--;
                }
                i++;
            }
            return map.Count == 0;
        }
        #endregion

        #region 647. Palindromic Substrings
        public int CountSubstrings(string s)
        {
            int result = 0;

            if (s.Length > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    result += CountSubstrings_helper(i, i, s);
                    result += CountSubstrings_helper(i, i + 1, s);
                }
            }

            return result;
        }

        private int CountSubstrings_helper(int start, int end, string s)
        {
            int count = 0;
            while (start >= 0 && end < s.Length && s[start--] == s[end++])
            {
                count++;
            }
            return count;
        }
        #endregion

        #region 581. Shortest Unsorted Continuous Subarray
        public int FindUnsortedSubarray(int[] nums)
        {
            if (nums.Length <= 1) return 0;

            if (nums.Length == 2)
            {
                if (nums[0] <= nums[1]) return 0;
                return 2;
            }

            int start = -1, end = -1, max = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (max > nums[i])
                {
                    if (start == -1)
                    {
                        start = i - 1;
                    }

                    while (start - 1 >= 0 && nums[start - 1] > nums[i]) start--;
                    end = i + 1;
                }
                else
                {
                    max = nums[i];
                }
            }
            return end - start;
        }

        #endregion

        #region 695. Max Area of Island
        public int MaxAreaOfIsland(int[][] grid)
        {
            int result = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        result = Math.Max(result, getConnectedLand(grid, i, j));
                    }
                }
            }

            return result;
        }

        private int getConnectedLand(int[][] grid, int i, int j)
        {
            int count = 1;

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((i, j));
            grid[i][j] = int.MaxValue;

            while (queue.Count > 0)
            {
                (int x, int y) = queue.Dequeue();

                //x+1 y
                count += MaxAreaOfIsland_Connected(grid, queue, x + 1, y);

                //x-1 y
                count += MaxAreaOfIsland_Connected(grid, queue, x - 1, y);

                //x y+1
                count += MaxAreaOfIsland_Connected(grid, queue, x, y + 1);

                //x y-1
                count += MaxAreaOfIsland_Connected(grid, queue, x, y - 1);

            }

            return count;
        }

        private int MaxAreaOfIsland_Connected(int[][] grid, Queue<(int, int)> queue, int x, int y)
        {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[x].Length || grid[x][y] != 1) return 0;

            grid[x][y] = int.MaxValue;
            queue.Enqueue((x, y));
            return 1;
        }
        #endregion

        #region  704. Binary Search
        public int Search(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            int mid = (low + high) / 2;

            while (low <= high)
            {
                mid = (low + high) / 2;
                if (nums[mid] == target) return mid;

                if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
        #endregion

        #region 733. Flood Fill
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            Queue<(int, int)> q = new Queue<(int, int)>();
            int oldColor = image[sr][sc];
            image[sr][sc] = newColor;
            if (oldColor != newColor)
            {
                q.Enqueue((sr, sc));
                while (q.Count > 0)
                {
                    (int i, int j) = q.Dequeue();

                    // i-1 j
                    FloodFill_Helper(image, q, i - 1, j, oldColor, newColor);

                    // i j-1
                    FloodFill_Helper(image, q, i, j - 1, oldColor, newColor);

                    // i j+1
                    FloodFill_Helper(image, q, i, j + 1, oldColor, newColor);

                    // i+1 j
                    FloodFill_Helper(image, q, i + 1, j, oldColor, newColor);
                }
            }
            //FloodFill_Helper(image, q, oldColor, newColor);
            return image;
        }
        private void FloodFill_Helper(int[][] image, Queue<(int, int)> q, int i, int j, int oldColor, int newColor)
        {
            if (i >= 0 && j >= 0 && i < image.Length && j < image[i].Length && image[i][j] == oldColor)
            {
                image[i][j] = newColor;
                q.Enqueue((i, j));
            }
        }
        #endregion

        #region 743. Network Delay Time
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            return 0;
        }
        #endregion

        #region 744. Find Smallest Letter Greater Than Target
        public char NextGreatestLetter(char[] letters, char target)
        {
            int low = 0;
            int high = letters.Length - 1;
            int resIndex = -1;
            while (low <= high)
            {
                if (letters[low] > target)
                {
                    resIndex = low;
                    break;
                }

                if (letters[high] <= target)
                {
                    resIndex = high + 1;
                    break;
                }

                int mid = low + (high - low) / 2;

                if (letters[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return resIndex >= letters.Length || resIndex == -1 ? letters[0] : letters[resIndex];
        }
        #endregion

        #region 844. Backspace String Compare
        public bool BackspaceCompare(string s, string t)
        {
            s = ProcessString(s);
            t = ProcessString(t);
            return false;
        }

        private string ProcessString(string s)
        {
            StringBuilder sb = new StringBuilder();
            int backSpaceCount = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];
                if (c == '#')
                {
                    backSpaceCount++;
                }
                else
                {
                    if (backSpaceCount > 0) { backSpaceCount--; continue; }
                    sb.Insert(0, c);
                }
            }
            return sb.ToString();
        }
        #endregion

        #region 852. Peak Index in a Mountain Array
        public int PeakIndexInMountainArray(int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;

            int peekValue = int.MinValue;
            int peekIndex = -1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (peekValue < arr[mid])
                {
                    peekValue = arr[mid];
                    peekIndex = mid;
                }

                if (mid > 0 && arr[mid] < arr[mid - 1])
                {
                    high = mid - 1;
                }
                else if (mid < arr.Length - 1 && arr[mid] < arr[mid + 1])
                {
                    low = mid + 1;
                }
                else
                {
                    break;
                }

            }

            return peekIndex;
        }
        #endregion

        #region 876. Middle of the Linked List
        public ListNode MiddleNode(ListNode head)
        {
            Stack<ListNode> stack1 = new Stack<ListNode>();
            Stack<ListNode> stack2 = new Stack<ListNode>();

            stack1.Push(head);

            while (stack1.Peek().Next != null)
            {
                stack1.Push(stack1.Peek().Next);
            }

            while (stack2.Count < stack1.Count)
            {
                stack2.Push(stack1.Pop());
            }
            return stack2.Pop();
        }
        #endregion

        #region 934. Shortest Bridge
        public int ShortestBridge(int[][] grid)
        {
            int result = int.MaxValue;
            int n = grid.Length;
            Queue<(int, int)> queue = new Queue<(int, int)>();
            for (int i = 0; i < n; i++)
            {
                bool isFound = false;
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        queue.Enqueue((i, j));
                        grid[i][j] = 1000;
                        isFound = true;
                        break;
                    }
                }
                if (isFound) break;
            }

            while (queue.Count > 0)
            {
                (int x, int y) = queue.Dequeue();

                if (x + 1 < n && grid[x + 1][y] == 1)
                {
                    queue.Enqueue((x + 1, y));
                    grid[x + 1][y] = 1000;
                }
                if (y + 1 < n && grid[x][y + 1] == 1)
                {
                    queue.Enqueue((x, y + 1));
                    grid[x][y + 1] = 1000;
                }
                if (x - 1 >= 0 && grid[x - 1][y] == 1)
                {
                    queue.Enqueue((x - 1, y));
                    grid[x - 1][y] = 1000;
                }
                if (y - 1 >= 0 && grid[x][y - 1] == 1)
                {
                    queue.Enqueue((x, y - 1));
                    grid[x][y - 1] = 1000;
                }
            }

            Queue<(int, int, int)> queue1 = new Queue<(int, int, int)>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        queue1.Enqueue((0, i, j));
                        grid[i][j] = 2000;
                    }
                }
            }

            while (queue1.Count > 0)
            {
                (int level, int x, int y) = queue1.Dequeue();
                //result = Math.Max(result, level);
                bool isBottom = fillStack(grid, n, queue1, level + 1, x + 1, y);

                bool isRight = fillStack(grid, n, queue1, level + 1, x, y + 1);

                bool isLeft = fillStack(grid, n, queue1, level + 1, x, y - 1);

                bool isTop = fillStack(grid, n, queue1, level + 1, x - 1, y);

                if (isBottom || isTop || isLeft || isRight)
                {
                    result = Math.Min(result, level);
                }
            }
            return result;
        }

        private static bool fillStack(int[][] grid, int n, Queue<(int, int, int)> queue, int level, int x, int y)
        {
            if (x >= 0 && x < n && y >= 0 && y < n && grid[x][y] != 2000)
            {
                if (grid[x][y] == 1000) return true;
                int oldGridVal = grid[x][y];
                if (oldGridVal == 0 || level < oldGridVal)
                {
                    grid[x][y] = level;
                    queue.Enqueue((level, x, y));
                }
            }
            return false;
        }
        #endregion

        #region 994. Rotting Oranges
        public int OrangesRotting(int[][] grid)
        {
            int result = 0;
            int m = grid.Length;
            int n = grid[0].Length;
            bool[][] visited = new bool[m][];
            Queue<(int, int, int)> q = new Queue<(int, int, int)>();

            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        q.Enqueue((0, i, j));
                        visited[i][j] = true;
                    }
                    else if (grid[i][j] == 0)
                    {
                        visited[i][j] = true;
                    }
                }
            }

            while (q.Count > 0)
            {
                (int t, int x, int y) = q.Dequeue();

                result = Math.Max(result, t);
                OrangesRotting_Helper(grid, q, visited, x + 1, y, t + 1);
                OrangesRotting_Helper(grid, q, visited, x - 1, y, t + 1);
                OrangesRotting_Helper(grid, q, visited, x, y + 1, t + 1);
                OrangesRotting_Helper(grid, q, visited, x, y - 1, t + 1);

            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!visited[i][j]) return -1;
                }
            }

            return result;
        }
        private void OrangesRotting_Helper(int[][] grid, Queue<(int, int, int)> q, bool[][] visited, int x, int y, int time)
        {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[x].Length || visited[x][y]) return;

            visited[x][y] = true;
            q.Enqueue((time, x, y));
        }
        #endregion

        #region 1020. Number of Enclaves
        public int NumEnclaves(int[][] grid)
        {
            int result = 0;

            for (int i = 0; i < grid[0].Length; i++)
            {
                if (grid[0][i] == 1)
                {
                    updateAdjacentLands(grid, 0, i);
                }

                if (grid[grid.Length - 1][i] == 1)
                {
                    updateAdjacentLands(grid, grid.Length - 1, i);
                }
            }

            for (int i = 0; i < grid.Length; i++)
            {
                if (grid[i][0] == 1)
                {
                    updateAdjacentLands(grid, i, 0);
                }

                if (grid[i][grid[i].Length - 1] == 1)
                {
                    updateAdjacentLands(grid, i, grid[i].Length - 1);
                }
            }

            for (int i = 1; i < grid.Length - 1; i++)
            {
                for (int j = 1; j < grid[i].Length - 1; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private void updateAdjacentLands(int[][] grid, int v, int i)
        {
            Queue<(int, int)> q = new Queue<(int, int)>();
            q.Enqueue((v, i));

            while (q.Count > 0)
            {
                (int x, int y) = q.Dequeue();
                grid[x][y] = 0;
                checkAdjCell(grid, q, x - 1, y);
                checkAdjCell(grid, q, x + 1, y);
                checkAdjCell(grid, q, x, y - 1);
                checkAdjCell(grid, q, x, y + 1);
            }
        }

        private void checkAdjCell(int[][] grid, Queue<(int, int)> q, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < grid.Length && y < grid[x].Length && grid[x][y] == 1)
            {
                q.Enqueue((x, y));
            }
        }
        #endregion

        #region 1091. Shortest Path in Binary Matrix
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int n = grid.Length;
            if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1) return -1;
            if (n == 2) return n;

            Queue<(int, int, int)> q = new Queue<(int, int, int)>();
            bool[][] visited = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                visited[i] = new bool[n];
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        visited[i][j] = true;
                    }
                }
            }
            q.Enqueue((1, 0, 0));
            visited[0][0] = true;
            while (q.Count > 0)
            {
                (int val, int x, int y) = q.Dequeue();

                //bottom right x+1 y+1
                checkAdj(grid, q, visited, x + 1, y + 1, val + 1);

                //bottom x+1 y
                checkAdj(grid, q, visited, x + 1, y, val + 1);

                //right x y+1
                checkAdj(grid, q, visited, x, y + 1, val + 1);

                //bottom left x+1 y-1
                checkAdj(grid, q, visited, x + 1, y - 1, val + 1);

                //top right x-1 y+1
                checkAdj(grid, q, visited, x - 1, y + 1, val + 1);

                //top x-1 y
                checkAdj(grid, q, visited, x - 1, y, val + 1);

                //left x y-1
                checkAdj(grid, q, visited, x, y - 1, val + 1);

                //top left x-1 y-1
                checkAdj(grid, q, visited, x - 1, y - 1, val + 1);
            }
            return grid[n - 1][n - 1] == 0 ? -1 : grid[n - 1][n - 1];
        }

        private void checkAdj(int[][] grid, Queue<(int, int, int)> q, bool[][] visited, int x, int y, int v)
        {
            if (x < 0 || y < 0 || x == grid.Length || y == grid[x].Length || visited[x][y]) return;
            grid[x][y] = v;
            q.Enqueue((v, x, y));
            visited[x][y] = true;
        }

        public int ShortestPathBinaryMatrix_V1(int[][] grid)
        {
            int n = grid.Length;

            if (n == 0 || grid[0][0] == 1 || grid[n - 1][n - 1] == 1) return -1;

            if (n == 1) return 1;

            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        dp[i][j] = int.MaxValue;
                    }
                }
            }
            dp[0][0] = 1;

            Queue<(int, int)> queue = new Queue<(int, int)>();

            queue.Enqueue((0, 0));

            while (queue.Count > 0)
            {
                var q = queue.Dequeue();

                int i = q.Item1;
                int j = q.Item2;

                int c = dp[i][j];
                if (i == n - 1 && j == n - 1) break;
                //i-1 j-1
                chackAdj_v1(dp, queue, i - 1, j - 1, c + 1);

                //i-1 j
                chackAdj_v1(dp, queue, i - 1, j, c + 1);

                //i-1 j+1
                chackAdj_v1(dp, queue, i - 1, j + 1, c + 1);

                //i j+1
                chackAdj_v1(dp, queue, i, j + 1, c + 1);

                //i+1 j+1
                chackAdj_v1(dp, queue, i + 1, j + 1, c + 1);

                //i+1 j
                chackAdj_v1(dp, queue, i + 1, j, c + 1);

                //i+1 j-1
                chackAdj_v1(dp, queue, i + 1, j - 1, c + 1);

                //i j-1
                chackAdj_v1(dp, queue, i, j - 1, c + 1);
            }

            return dp[n - 1][n - 1] == int.MaxValue || dp[n - 1][n - 1] == 0 ? -1 : dp[n - 1][n - 1];
        }

        private void chackAdj_v1(int[][] dp, Queue<(int, int)> queue, int i, int j, int val)
        {
            if (i < 0 || j < 0 || j >= dp.Length || i >= dp.Length || dp[i][j] == int.MaxValue || (dp[i][j] != 0 && dp[i][j] <= val)) return;

            dp[i][j] = val;
            queue.Enqueue((i, j));
        }

        private void fillDp_v1(int[][] dp, int i, int j)
        {
            if (i == 0 && j == 0)
            {
                dp[i][j] = 1;
                return;
            }

            if (i == 0)
            {
                fill_v1(dp, i, j, dp[i][j - 1], int.MaxValue, int.MaxValue);
                return;
            }

            if (j == 0)
            {
                fill_v1(dp, i, j, dp[i - 1][j], int.MaxValue, int.MaxValue);
                return;
            }

            int topLeft = dp[i - 1][j - 1];
            int left = dp[i][j - 1];
            int top = dp[i - 1][j];
            fill_v1(dp, i, j, topLeft, left, top);
        }

        private static void fill_v1(int[][] dp, int i, int j, int val1, int val2, int val3)
        {
            int val = Math.Min(val1, Math.Min(val2, val3));
            if (val == int.MaxValue)
            {
                dp[i][j] = int.MaxValue;
            }
            else
            {
                dp[i][j] = val + 1;
            }
        }
        #endregion

        #region 1162. As Far from Land as Possible
        public int MaxDistance(int[][] grid)
        {
            int result = 0;
            int n = grid.Length;

            int[][] dp = new int[n][];
            Queue<(int, int, int)> q = new Queue<(int, int, int)>();
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (dp[i][j] == 1)
                    {
                        q.Enqueue((0, i, j));
                    }
                    else
                    {
                        dp[i][j] = int.MaxValue;
                    }
                }
            }
            if (q.Count == 0 || q.Count == n * n) return -1;
            while (q.Count > 0)
            {
                (int level, int x, int y) = q.Dequeue();
                result = Math.Max(result, level);
                checkCell_MaxDistance(dp, q, level + 1, x + 1, y);
                checkCell_MaxDistance(dp, q, level + 1, x - 1, y);
                checkCell_MaxDistance(dp, q, level + 1, x, y + 1);
                checkCell_MaxDistance(dp, q, level + 1, x, y - 1);
            }

            return result;
        }

        private void checkCell_MaxDistance(int[][] dp, Queue<(int, int, int)> q, int v, int x, int y)
        {
            if (x < 0 || y < 0 || x >= dp.Length || y >= dp.Length || v >= dp[x][y]) return;
            dp[x][y] = v;
            q.Enqueue((v, x, y));
        }
        #endregion

        #region 1209. Remove All Adjacent Duplicates in String II
        public string RemoveDuplicates(string s, int k)
        {
            Stack<(char, int, int)> stack = new Stack<(char, int, int)>();
            stack.Push((s[0], 1, 0));
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                if (top.Item2 == k)
                {
                    s = s.Remove(top.Item3, k);

                    if (stack.Count == 0 && s.Length > 0)
                    {
                        stack.Push((s[0], 1, 0));
                    }
                    continue;
                }


                int cIndex = top.Item3 + top.Item2;
                if (cIndex == s.Length) break;
                char c = s[cIndex];
                if (c == top.Item1)
                {
                    stack.Push((top.Item1, ++top.Item2, top.Item3));
                }
                else
                {
                    stack.Push(top);

                    stack.Push((c, 1, cIndex));
                }

            }
            return s;
        }
        #endregion

        #region 1254. Number of Closed Islands
        public int ClosedIsland(int[][] grid)
        {
            int result = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        if (isClosed(grid, new Queue<(int, int)>(), i, j))
                        {
                            result++;
                        }
                    }
                }
            }

            return result;
        }

        private bool isClosed(int[][] grid, Queue<(int, int)> queue, int i, int j)
        {

            if (i < 0 || j < 0 || i == grid.Length || j == grid[i].Length) return false;

            if (grid[i][j] == 1) return true;
            if (grid[i][j] == 0)
            {
                queue.Enqueue((i, j));
                grid[i][j] = int.MaxValue;
            }
            bool top = true, right = true, bottom = true, left = true;
            while (queue.Count > 0)
            {
                (int x, int y) = queue.Dequeue();
                top = isClosed(grid, queue, x - 1, y);
                bottom = isClosed(grid, queue, x + 1, y);
                left = isClosed(grid, queue, x, y - 1);
                right = isClosed(grid, queue, x, y + 1);
            }

            return top && bottom && right && left;
        }
        #endregion

        #region 1302. Deepest Leaves Sum
        public int DeepestLeavesSum(TreeNode root)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            Queue<(int, TreeNode)> q = new Queue<(int, TreeNode)>();
            q.Enqueue((0, root));
            while (q.Count > 0)
            {
                var p = q.Dequeue();

                int level = p.Item1;
                TreeNode tree = p.Item2;

                if (result.ContainsKey(level))
                {
                    result[level] += tree.val;
                }
                else
                {
                    result.Add(level, tree.val);
                }

                if (tree.left != null)
                {
                    q.Enqueue((level + 1, tree.left));
                }
                if (tree.right != null)
                {
                    q.Enqueue((level + 1, tree.right));
                }
            }

            return result.LastOrDefault().Value;
        }

        #endregion

        #region 1379. Find a Corresponding Node of a Binary Tree in a Clone of That Tree
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (cloned.val == target.val) return cloned;
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();

            treeNodes.Enqueue(cloned);

            while (treeNodes.Peek().val != target.val)
            {
                TreeNode q = treeNodes.Dequeue();

                if (q.left != null)
                {
                    treeNodes.Enqueue(q.left);
                }

                if (q.right != null)
                {
                    treeNodes.Enqueue(q.right);
                }
            }
            return treeNodes.Dequeue();
        }

        private TreeNode GetTargetCopy_Helper(TreeNode cloned, TreeNode target)
        {
            if (cloned == null) return cloned;
            if (cloned.val == target.val) return cloned;

            if (cloned.left != null)
            {
                return GetTargetCopy_Helper(cloned.left, target);
            }
            else
            {
                return GetTargetCopy_Helper(cloned.right, target);
            }
        }

        #endregion

        #region 1423 MaxScore
        /// <summary>
        /// LeetCode #1423
        /// </summary>
        /// <param name="cardPoints"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxScore(int[] cardPoints, int k)
        {
            int sum = cardPoints.Sum();
            int length = cardPoints.Length;

            if (length == k) return sum;

            int frame = 0;
            int res = 0;

            for (int i = 0; i < length - k - 1; i++)
            {
                frame += cardPoints[i];
            }

            for (int i = length - k - 1; i < length; i++)
            {
                frame += cardPoints[i];

                res = Math.Max(res, sum - frame);

                frame -= cardPoints[i - (length - k - 1)];
            }

            return res;
        }
        #endregion

        #region 1641. Count Sorted Vowel Strings
        public int CountVowelStrings(int n)
        {
            List<List<int>> vowelStrings = new List<List<int>>();

            CountVowelStrings_helper(vowelStrings, new LinkedList<int>(), n, 1);

            return vowelStrings.Count;
        }

        private void CountVowelStrings_helper(List<List<int>> vowelStrings, LinkedList<int> ll, int n, int curr)
        {
            if (curr > 5) return;

            if (n == 0)
            {
                vowelStrings.Add(ll.ToList());
                return;
            }

            ll.AddLast(curr);

            CountVowelStrings_helper(vowelStrings, ll, n - 1, curr);
            ll.RemoveLast();

            CountVowelStrings_helper(vowelStrings, ll, n, curr + 1);
        }
        #endregion

        #region 1679. Max Number of K-Sum Pairs

        public int MaxOperations(int[] nums, int k)
        {
            Array.Sort(nums);
            int result = 0;
            List<int> list = new List<int>();

            int startIndex = 0;
            int endIndex = nums.Length - 1;

            while (startIndex < endIndex && nums[startIndex] < k)
            {
                if (nums[startIndex] + nums[endIndex] == k)
                {
                    list.Add(startIndex);
                    list.Add(endIndex);
                    result++;
                    startIndex++;
                    endIndex--;
                }
                else
                {
                    if (nums[startIndex] + nums[endIndex] > k)
                    {
                        endIndex--;
                    }
                    else
                    {
                        startIndex++;
                    }
                }
            }

            return result;
        }

        #endregion

        #region 2269. Find the K-Beauty of a Number
        public int DivisorSubstrings(int num, int k)
        {
            string s = num.ToString();
            int result = 0;
            for (int i = 0; i <= s.Length - k; i++)
            {
                int divisor = int.Parse(s.Substring(i, k));

                if (num % divisor == 0) result++;
            }
            return result;
        }
        #endregion

        #region 2270. Number of Ways to Split Array
        public int WaysToSplitArray(int[] nums)
        {
            long[] leftSum = new long[nums.Length];
            long sum = 0;

            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                leftSum[i] += (i == 0 ? 0 : leftSum[i - 1]) + nums[i];
            }
            for (int i = 1; i < nums.Length; i++)
            {
                long rightSum = sum - leftSum[i - 1];
                if (leftSum[i - 1] >= rightSum) result++;
            }
            return result;
        }
        #endregion

        #region 2271. Maximum White Tiles Covered by a Carpet
        public int MaximumWhiteTiles(int[][] tiles, int carpetLen)
        {
            int result = 0;

            List<int[]> list = tiles.OrderBy(x => x[0]).ToList();
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < list.Count; i++)
            {
                int count = list[i][1] - list[i][0] + 1;
                if (count >= carpetLen) return carpetLen;
                map.Add(i, count);
            }
            //for (int i = 0; i < list.Count; i++)
            //{
            //    int low = i + 1;
            //    int end = list.Count - 1;

            //    if (MaximumWhiteTiles_Valid(list, i, end, carpetLen))
            //    {
            //        for (int j = i+1; j < length; j++)
            //        {

            //        }



            //        break;
            //    }
            //    else if()

            //    for (int j = i+1; j < list.Count; j++)
            //    {
            //        int tcountwithendIndex = list[j][1] - list[i][0] + 1;
            //        int tcountwitstartIndex =  list[j][0] - list[i][0] + 1;
            //        if (tcountwithendIndex <= carpetLen)
            //        {
            //            map[i] = map[i]+ list[j][1] - list[j][0] + 1;
            //        }
            //        else if (tcountwitstartIndex <= carpetLen)
            //        {
            //            while (tcountwitstartIndex <= carpetLen)
            //            {
            //                map[i]++;
            //                tcountwitstartIndex++;
            //            }
            //            break;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}

            return map.Values.Max();

        }

        private bool MaximumWhiteTiles_Valid(List<int[]> list, int i, int targetIndex, int carpetLen)
        {
            int startIndex = list[i][0];
            int endIndex = list[i][0];

            int total = endIndex - startIndex + 1;

            return carpetLen >= total;
        }
        #endregion

        #region Bipartite Graph
        /// <summary>
        /// Union find
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite_V3(int[][] graph)
        {
            UF uf = new UF(graph.Length);

            for (int i = 0; i < graph.Length; i++)
            {
                foreach (var item in graph[i])
                {
                    if (uf.Find(item) == uf.Find(i)) return false;

                    uf.Union(item, graph[i][0]);
                }
            }
            return true;
        }

        /// <summary>
        /// BFS, Graph Coloring By Queue
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite_V2(int[][] graph)
        {
            int[] color = Enumerable.Repeat(0, graph.Length).ToArray();

            for (int i = 0; i < graph.Length; i++)
            {
                if (color[i] == 0)
                {
                    color[i] = 1;
                    Queue<int> q = new Queue<int>();
                    q.Enqueue(i);

                    while (q.Count > 0)
                    {
                        int n = q.Dequeue();

                        foreach (var item in graph[n])
                        {
                            if (color[n] == color[item]) return false;
                            else if (color[item] == 0)
                            {
                                q.Enqueue(item);
                                color[item] = -color[n];
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// DFS, Graph Coloring
        /// 0 - No
        /// -1 - Red
        /// 1 - Blue
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite_V1(int[][] graph)
        {
            int[] color = Enumerable.Repeat(0, graph.Length).ToArray();
            for (int i = 0; i < graph.Length; i++)
            {
                if (color[i] == 0 && !validColor(graph, color, 1, i)) return false;
            }
            return true;
        }

        private bool validColor(int[][] graph, int[] color, int c, int node)
        {
            if (color[node] != 0)
            {
                return color[node] == c;
            }

            color[node] = c;

            foreach (var item in graph[node])
            {
                if (!validColor(graph, color, -c, item)) return false;
            }

            return true;
        }

        #endregion

        #region 292week
        //Largest 3-Same-Digit Number in String
        public string LargestGoodInteger(string num)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < num.Length - 3; i++)
            {

                if (!list.Contains(num[i]) && num[i] == num[i + 1] && num[i] == num[i + 2])
                {
                    list.Add(num[i]);
                    i = i + 2;
                }
            }
            if (list.Count == 0) return "";
            char c = list.Max();
            return new string(new char[] { c, c, c });
        }

        public int CountTexts(string pressedKeys)
        {
            Dictionary<char, char[]> dct = new Dictionary<char, char[]>();

            dct.Add('2', new char[] { 'a', 'b', 'c' });
            dct.Add('3', new char[] { 'd', 'e', 'f' });
            dct.Add('4', new char[] { 'g', 'h', 'i' });
            dct.Add('5', new char[] { 'j', 'k', 'l' });
            dct.Add('6', new char[] { 'm', 'n', 'o' });
            dct.Add('7', new char[] { 'p', 'q', 'r' });
            dct.Add('8', new char[] { 's', 't', 'u', 'v' });
            dct.Add('9', new char[] { 'w', 'x', 'y', 'z' });

            return 0;
        }

        public bool HasValidPath(char[][] grid)
        {

            int m = grid.Length;
            int n = grid[0].Length;

            if (m > 0 && n > 0)
            {
                if (grid[m - 1][n - 1] != ')') return false;
            }

            return false;
        }

        public int AverageOfSubtree(TreeNode root)
        {
            List<(TreeNode, int, int)> results = new List<(TreeNode, int, int)>();
            Stack<(int, TreeNode)> stack = new Stack<(int, TreeNode)>();

            stack.Push((0, root));

            while (stack.Count > 0)
            {
                var s = stack.Peek();


            }
            return 0;
        }

        private int AverageOfSubtree_Tr(List<(TreeNode, int, int)> results, TreeNode root)
        {
            if (root == null) return 0;

            int left = AverageOfSubtree_Tr(results, root.left);
            int right = AverageOfSubtree_Tr(results, root.right);

            return 0;
        }

        #endregion

        #region 293 Week
        #region Problem 1
        public IList<string> RemoveAnagrams(string[] words)
        {
            IList<string> list = new List<string>();
            string lastAnagram = string.Empty;
            foreach (string word in words)
            {
                char[] ch = word.ToCharArray();
                Array.Sort(ch);

                string s = new string(ch);

                if (lastAnagram != s)
                {
                    lastAnagram = s;
                    list.Add(s);
                }
            }
            return list;
        }
        #endregion

        #region Problem 2 Maximum Consecutive Floors Without Special Floors
        public int MaxConsecutive(int bottom, int top, int[] special)
        {
            int result = 0;
            Array.Sort(special);
            int low = 0;
            int end = special.Length - 1;
            while (bottom < top)
            {
                if (low <= end)
                {
                    result = Math.Max(result, special[low] - bottom);
                    result = Math.Max(result, top - special[end]);
                    bottom = special[low] + 1;
                    top = special[end] - 1;

                    low++;
                    end--;
                }
                else
                {
                    result = Math.Max(result, top - bottom + 1);
                    break;
                }
            }


            return result;
        }
        #endregion

        #region Problem 3
        #endregion

        #region Problem 4 Count Integers in Intervals
        #endregion
        #endregion

        #region 294 Week

        #region Problem 1
        public int PercentageLetter(string s, char letter)
        {
            if (s.Length == 0) return 0;
            int result;
            int letterCount = s.Count(x => x == letter);

            result = (letterCount * 100) / s.Length;

            return result;
        }
        #endregion

        #region Problem 2
        public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks)
        {
            int result = 0;
            List<(int, int)> list = new List<(int, int)>();
            for (int i = 0; i < capacity.Length; i++)
            {
                list.Add((capacity[i], rocks[i]));
            }

            list = list.OrderBy(x => x.Item1 - x.Item2).ToList();

            foreach (var item in list)
            {
                (int cap, int rock) = item;
                if (additionalRocks > 0)
                {
                    int diff = cap - rock;

                    if (additionalRocks >= diff)
                    {
                        additionalRocks -= diff;
                        rock = cap;
                    }
                    else
                    {
                        diff -= additionalRocks;
                        additionalRocks = 0;
                        rock += diff;
                    }
                }

                if (cap == rock) result++;
            }

            return result;
        }
        #endregion

        #region Problem 3

        enum pattern
        {
            increase = 0,
            decrease = 1,
            stable = 2
        }

        public int MinimumLines(int[][] stockPrices)
        {
            int result = 0;
            if (stockPrices.Length > 1)
            {
                pattern oldPatter = pattern.stable;
                List<(int, int)> list = new List<(int, int)>();

                foreach (var item in stockPrices)
                {
                    list.Add((item[0], item[1]));
                }

                list = list.OrderBy(x => x.Item1).ToList();
                if (list[0].Item2 == list[1].Item2)
                {
                    oldPatter = pattern.stable;
                }
                else if (list[0].Item2 > list[1].Item2)
                {
                    oldPatter = pattern.decrease;
                }
                else
                {
                    oldPatter = pattern.increase;
                }
                result = 1;
                int oldday = list[1].Item1;
                int oldprice = list[1].Item2;
                for (int i = 2; i < list.Count; i++)
                {
                    pattern p = pattern.stable;
                    (int day, int price) = list[i];

                    if (oldprice > price)
                    {
                        p = pattern.decrease;
                    }
                    else if (oldprice < price)
                    {
                        p = pattern.increase;
                    }
                    else
                    {
                        p = pattern.stable;
                    }
                    oldprice = price;
                    if (p != oldPatter)
                    {
                        result++;
                    }
                    oldPatter = p;
                }
            }
            return result;
        }
        #endregion

        #region Problem 4
        public int TotalStrength(int[] strength)
        {
            int n = strength.Length;
            long result = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= n - i; j++)
                {
                    var p = strength.Skip(j).Take(i);

                    if (p.Count() < i) break;

                    long min = p.Min();
                    long sum = p.Sum();

                    long mul = min * sum;
                    Console.WriteLine("mul " + mul);
                    result += mul;
                    Console.WriteLine("res " + result);
                    //if (result > int.MaxValue)
                    //{
                    //    result = int.MaxValue;
                    //    break;
                    //}
                }
            }

            return result > int.MaxValue ? (int)(result % 1000000007) : (int)result;
        }
        #endregion

        #endregion

        #region 14Days
        #region May 11,2022
        public int SearchV1(int[] nums, int target)
        {
            int mid = nums.Length / 2;
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                if (nums[low] == target)
                {
                    return low;
                }
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[high] == target)
                {
                    return high;
                }

                if (target < nums[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
                mid = (low + high) / 2;

            }
            return -1;
        }

        public int SearchInsertV1(int[] nums, int target)
        {
            int mid = nums.Length / 2;
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                if (nums[high] < target)
                {
                    return high + 1;
                }
                if (nums[low] > target)
                {
                    return low;
                }
                if (nums[low] == target)
                {
                    while (low > 0 && nums[low - 1] == nums[low])
                    {
                        low--;
                    }
                    return low;
                }
                if (nums[mid] == target)
                {
                    while (mid > low && nums[mid - 1] == nums[mid])
                    {
                        mid--;
                    }

                    return mid;
                }
                if (nums[high] == target)
                {
                    while (high > mid && nums[high - 1] == nums[high])
                    {
                        high--;
                    }
                    return high;
                }

                if (target < nums[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
                mid = (low + high) / 2;

            }

            int max = Math.Max(low, high);

            while (max > 0 && nums[max] > target && nums[max - 1] > target)
            {
                max--;
            }

            return max;
        }
        #endregion
        #endregion

        public IList<IList<int>> PermuteUnique1(int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();

            PermuteUnique1_BackTrack(results, nums, 0);
            return results;
        }
        private void PermuteUnique1_BackTrack(IList<IList<int>> results, int[] nums, int start)
        {
            if (start == nums.Length)
            {
                results.Add(new List<int>(nums));
                return;
            }
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    if (i != start && !canPermute1(i, start, nums)) continue;
                    swap(i, start, nums);
                    PermuteUnique1_BackTrack(results, nums, start + 1);
                    swap(i, start, nums);
                }
            }
        }

        private bool canPermute1(int i, int start, int[] nums)
        {
            for (int j = start; j < nums.Length; j++)
            {
                if (nums[j] == nums[i]) return false;
            }
            return true;
        }

        private void swap(int i, int start, int[] nums)
        {
            if (i == nums.Length) return;
            int temp = nums[i];
            nums[i] = nums[start];
            nums[start] = temp;
        }
    }
}
