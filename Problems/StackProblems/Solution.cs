namespace StackProblems
{
    internal class Solution
    {
        internal bool Ispar(string s)
        {
            //Your code here
            Stack<char> stack = new Stack<char>();
            char[] ch = s.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                switch (ch[i])
                {
                    case '{':
                        stack.Push(ch[i]);
                        break;
                    case '}':

                        if (stack.Count == 0 || stack.Pop() != '{') return false;
                        break;
                    case '(':
                        stack.Push(ch[i]);
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(') return false;
                        break;
                    case '[':
                        stack.Push(ch[i]);
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[') return false;
                        break;
                    default:
                        break;
                }
            }
            return stack.Count == 0;
        }

        internal long[] NextLargerElement(long[] arr, int n)
        {
            //Your code here
            Stack<long> stack = new Stack<long>();

            long[] larger = Enumerable.Repeat((long)-1, n).ToArray();



            for (int i = 0; i < n; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(i);
                }
                else
                {
                    while (stack.Count != 0)
                    {
                        if (arr[stack.Peek()] < arr[i])
                        {
                            larger[stack.Pop()] = arr[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                    stack.Push(i);
                }
            }

            return larger;

        }

        public int[] CalculateSpan(int[] price, int n)
        {
            //Your code here
            int[] span = new int[n];
            int lastSpanIndex = 0;
            int topElement = price[lastSpanIndex];

            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            span[0] = 1;

            for (int i = 1; i < n; i++)
            {
                while (topElement <= price[i])
                {
                    stack.Pop();

                    if (stack.Count == 0)
                    {
                        lastSpanIndex = -1;
                        break;
                    }
                    lastSpanIndex = stack.Peek();
                    topElement = price[lastSpanIndex];
                }
                span[i] = i - lastSpanIndex;
                stack.Push(i);
                lastSpanIndex = stack.Peek();
                topElement = price[lastSpanIndex];

            }

            return span;
        }

        internal int[] NextLargeElement(int[] input)
        {
            int[] result = new int[input.Length];
            Stack<int> stack = new Stack<int>();
            result[input.Length - 1] = -1;
            stack.Push(input.Length - 1);

            for (int i = input.Length - 2; i >= 0; i--)
            {
                while (input[stack.Peek()] <= input[i])
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        break;
                    }
                }

                result[i] = stack.Count == 0 ? -1 : input[stack.Peek()];
                stack.Push(i);
            }
            return result;
        }

        internal int[] PreviousLargeElement(int[] input)
        {
            int[] result = new int[input.Length];

            Stack<int> stack = new Stack<int>();
            result[0] = -1;
            stack.Push(0);

            for (int i = 1; i < input.Length; i++)
            {
                while (input[stack.Peek()] <= input[i])
                {
                    stack.Pop();

                    if (stack.Count == 0) break;
                }

                result[i] = stack.Count == 0 ? -1 : input[stack.Peek()];
                stack.Push(i);
            }

            return result;
        }

        public int[] NextSmallElement(int[] n)
        {
            int[] result = new int[n.Length];
            result[n.Length - 1] = -1;
            Stack<int> stack = new Stack<int>();
            stack.Push(n.Length - 1);

            for (int i = n.Length - 2; i >= 0; i--)
            {
                while (n[stack.Peek()] >= n[i])
                {
                    stack.Pop();

                    if (stack.Count == 0) break;
                }

                result[i] = stack.Count == 0 ? -1 : n[stack.Peek()];
                stack.Push(i);
            }

            return result;
        }

        public int[] PreviousSmallElement(int[] n)
        {

            int[] result = new int[n.Length];
            result[0] = -1;
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            for (int i = 1; i < n.Length; i++)
            {
                while (n[stack.Peek()] >= n[i])
                {
                    stack.Pop();
                    if (stack.Count == 0) break;
                }
                result[i] = stack.Count == 0 ? -1 : n[stack.Peek()];
                stack.Push(i);
            }
            return result;
        }
    }
}
