using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
