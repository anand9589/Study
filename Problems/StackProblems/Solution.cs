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

        internal Stack<int> DeleteMiddleElementOfStack(Stack<int> stack)
        {
            int mid = (stack.Count / 2);

            int[] arr = new int[mid];

            for (int i = 0; i < mid; i++)
            {
                arr[i] = stack.Pop();
            }

            stack.Pop();
            for (int i = mid - 1; i >= 0; i--)
            {
                stack.Push(arr[i]);
            }
            return stack;
        }

        internal string ReducedString(string s)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];
                if (stack.Count == 0)
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Peek() == c)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }
            }
            return new string(stack.ToArray());
        }

        internal string InfixToPostfix(string s)
        {
            List<char> result = new List<char>();
            Stack<char> stack = new Stack<char>();
            Dictionary<char, int> operatorPriority = new Dictionary<char, int>()
            {
                {'+',1},
                {'-',1},
                {'*',2},
                {'/',2},
                {'^',3}
            };

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                switch (c)
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '^':
                        while (stack.Count > 0 && stack.Peek() != '(' &&  operatorPriority[stack.Peek()] >= operatorPriority[c])
                        {
                            result.Add(stack.Pop());
                            if (stack.Count == 0) break;
                        }
                        stack.Push(c);
                        break;
                    case '(':
                        stack.Push(c);
                        break;
                    case ')':
                        while (stack.Peek() != '(')
                        {
                            result.Add(stack.Pop());
                        }
                        stack.Pop();
                        break;
                    default:
                        result.Add(c);
                        break;
                }
            }
            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }
            return new string(result.ToArray());

        }

        internal long EvaluatePostfixExpression(string s)
        {
            char[] chs = s.ToCharArray();
            Stack<int> stack = new Stack<int>();
            int parseVal = 0;
            int num1, num2 = 0;
            try
            {

                for (int i = 0; i < chs.Length; i++)
                {
                    if (int.TryParse(chs[i].ToString(), out parseVal))
                    {
                        stack.Push(parseVal);
                    }
                    else
                    {
                        switch (chs[i])
                        {
                            case '-':
                                num1 = stack.Pop();
                                num2 = stack.Pop();

                                stack.Push(num2 - num1);
                                break;
                            case '+':
                                num1 = stack.Pop();
                                num2 = stack.Pop();

                                stack.Push(num1 + num2);
                                break;
                            case '*':
                                num1 = stack.Pop();
                                num2 = stack.Pop();

                                stack.Push(num1 * num2);
                                break;
                            case '/':
                                num1 = stack.Pop();
                                num2 = stack.Pop();

                                stack.Push(num2 / num1);
                                break;
                            default:
                                break;
                        }
                    }
                }

                return stack.Pop();
            }
            catch (Exception ex)
            {
                return 0;
            }
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

        public int[] PreviousSmallElement_long_index(long[] arr, int n)
        {
            int[] result = new int[n];
            result[0] = -1;
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            for (int i = 1; i < n; i++)
            {
                while (arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();
                    if (stack.Count == 0) break;
                }
                result[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(i);
            }
            return result;
        }

        public int[] NextSmallElement_long_index(long[] arr, int n)
        {
            int[] result = new int[n];
            result[n - 1] = n;
            Stack<int> stack = new Stack<int>();
            stack.Push(n - 1);

            for (int i = n - 2; i >= 0; i--)
            {
                while (arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();

                    if (stack.Count == 0) break;
                }

                result[i] = stack.Count == 0 ? n : stack.Peek();
                stack.Push(i);
            }

            return result;
        }

        //Complete this function
        public long GetMaxArea(long[] arr, int n)
        {
            int[] psi = PreviousSmallElement_long_index(arr, n);
            int[] nsi = NextSmallElement_long_index(arr, n);
            //Your code here
            long result = 0;
            for (int i = 0; i < n; i++)
            {
                long area = (nsi[i] - psi[i] - 1) * arr[i];
                if (result < area)
                {
                    result = area;
                }
            }
            return result;
        }

        public long GetMaxAreaRectangle(long[,] arr, int rowCount, int colCount)
        {
            long result = 0;
            long[] rowArray = new long[colCount];
            for (int i = 0; i < colCount; i++)
            {
                rowArray[i] = arr[0, i];
            }

            result = GetMaxArea(rowArray, colCount);

            for (int i = 1; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    long cellVal = arr[i, j];
                    rowArray[j] = cellVal == 0 ? cellVal : rowArray[j] + cellVal;
                }

                var res = GetMaxArea(rowArray, colCount);

                if (res > result)
                {
                    result = res;
                }
            }
            return result;
        }

        public long GetMaxAreaSquare(long[,] arr, int rowCount, int colCount)
        {
            long result = 0;
            long[,] resultArray = new long[rowCount, colCount];

            for (int i = 0; i < colCount; i++)
            {
                resultArray[0, i] = arr[0, i];
            }

            for (int i = 1; i < rowCount; i++)
            {
                resultArray[i, 0] = arr[i, 0];
            }

            for (int i = 1; i < rowCount; i++)
            {
                for (int j = 1; j < colCount; j++)
                {
                    if (arr[i, j] != 0)
                    {
                        long val = (new long[] { resultArray[i - 1, j - 1], resultArray[i - 1, j], resultArray[i, j - 1] }).Min() + 1;

                        if (val > result)
                        {
                            result = val;
                        }

                        resultArray[i, j] = val;
                    }
                }
            }
            return result * result;
        }
    }
}
