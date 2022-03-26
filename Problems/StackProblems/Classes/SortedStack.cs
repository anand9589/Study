namespace StackProblems.Classes
{
    internal class SortedStack
    {
        public Stack<int> Stack { get; set; }
        private int[] arr;
        public SortedStack(Stack<int> stack)
        {
            arr = stack.ToArray();
            Stack = new Stack<int>();
        }

        public Stack<int> GetSortedStack()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Stack = Sort(Stack, arr[i]);
            }
            return Stack;
        }

        private Stack<int> Sort(Stack<int> stack, int data)
        {
            if (stack.Count == 0)
            {
                stack.Push(data);
            }
            else
            {
                int topElement = stack.Pop();

                if (topElement <= data)
                {
                    stack.Push(topElement);
                    stack.Push(data);
                }
                else
                {
                    stack = Sort(stack, data);
                    stack.Push(topElement);
                }
            }
            return stack;
            
        }
    }
}
