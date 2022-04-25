﻿namespace StringProblems
{
    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            List<int> result = new List<int>();

            int left = 0;

            int right = nums.Length - 1;

            serchRangeHelp(result, nums, left, right, target);

            return result.Count > 0 ? new int[] { result.Min(), result.Max() } : new int[] { -1, -1 };
        }

        private void serchRangeHelp(List<int> result, int[] nums, int left, int right, int target)
        {
            if (left > right) return;

            if (left == right)
            {
                if (nums[left] == target)
                {
                    result.Add(left);
                }
                return;
            }

            if (right - left == 1)
            {
                if (nums[left] == target)
                {
                    result.Add(left);
                }

                if (nums[right] == target)
                {
                    result.Add(right);
                }
                return;
            }

            if (nums[left] == target)
            {
                while (left < nums.Length && nums[left] == target)
                {
                    result.Add(left++);
                }
                return;
            }

            if (nums[right] == target)
            {
                while (right >= 0 && nums[right] == target)
                {
                    result.Add(right--);
                }
                return;
            }

            int mid = (left + right) / 2;
            if (nums[mid] == target)
            {
                result.Add(mid);

                int l = mid - 1;
                int r = mid + 1;

                while (l >= 0 && nums[l] == target)
                {
                    result.Add(l--);
                }
                while (r < nums.Length && nums[r] == target)
                {
                    result.Add(r++);
                }
                return;
            }

            if (nums[mid] > target)
            {
                serchRangeHelp(result, nums, left + 1, mid - 1, target);
            }
            else
            {
                serchRangeHelp(result, nums, mid + 1, right - 1, target);
            }
        }

        public int Search(int[] nums, int target)
        {
            return searchHelp(nums, 0, nums.Length - 1, target);
        }

        private int searchHelp(int[] nums, int left, int right, int target)
        {
            if (left > right) return -1;
            if (left == right && nums[left] != target) return -1;
            int mid = (left + right) / 2;
            if (nums[left] == target)
            {
                return left;
            }
            if (nums[right] == target)
            {
                return right;
            }
            if (nums[mid] == target)
            {
                return mid;
            }

            if (nums[left] < nums[mid] && target > nums[left] && target < nums[mid])
            {
                return searchHelp(nums, left + 1, mid - 1, target);
            }
            else if (nums[mid] < nums[right] && target > nums[mid] && target < nums[right])
            {
                return searchHelp(nums, mid + 1, right - 1, target);
            }
            else if (nums[mid] < nums[left])
            {
                return searchHelp(nums, left + 1, mid - 1, target);
            }
            else
            {
                return searchHelp(nums, mid + 1, right - 1, target);
            }
        }

        public int LongestValidParentheses(string s)
        {
            int result = 0;

            Stack<int> stack = new Stack<int>();

            stack.Push(-1);

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (c == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();

                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        int len = i - stack.Peek();
                        result = Math.Max(result, len);
                    }
                }
            }

            return result;
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> result = new List<int>();

            if (string.IsNullOrEmpty(s) || words.Length == 0) return result;

            int wordLen = words[0].Length;
            int wordsCount = words.Length;

            if (s.Length < (wordLen * wordsCount)) return result;

            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (map.ContainsKey(word))
                {
                    map[word]++;
                }
                else
                {
                    map.Add(word, 1);
                }
            }

            int startIndex = 0;

            Dictionary<string, int> visitedmap = new Dictionary<string, int>();
            while (startIndex <= s.Length - (wordLen * wordsCount))
            {
                var sp = s.Substring(startIndex, wordLen);

                if (map.ContainsKey(sp))
                {
                    var s1 = s.Substring(startIndex, (wordLen * wordsCount));

                    if (VerifyString(map, s1, wordLen))
                    {
                        result.Add(startIndex);
                    }
                }
                startIndex++;
            }

            return result;
        }

        private bool VerifyString(Dictionary<string, int> dct, string s1, int wordLen)
        {
            Dictionary<string, int> map = new Dictionary<string, int>(dct);

            for (int i = 0; i < s1.Length; i = i + wordLen)
            {
                string sub = s1.Substring(i, wordLen);
                if (map.ContainsKey(sub) && map[sub] > 0)
                {
                    map[sub]--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public int IsContains(string s, string x)
        {
            for (int i = 0; i <= s.Length - x.Length; i++)
            {
                if (s[i] == x[0])
                {
                    bool isMatch = true;
                    for (int j = 1; j < x.Length; j++)
                    {
                        if (x[j] != s[i + j])
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    if (isMatch) return i;
                }
            }
            return -1;
        }
    }
}
