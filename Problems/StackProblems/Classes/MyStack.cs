namespace StackProblems.Classes
{
    public class MyStack
    {
        private int top = -1;
        private readonly int size = 100;
        private int[] arr;
        public MyStack()
        {
            arr = new int[size];
        }
        public void push(int x)
        {
            if (top == size - 1) return;
            top++;
            arr[top] = x;
        }
        public int pop()
        {
            if (top == -1) return -1;
            int data = arr[top];
            top--;
            return data;
        }

    }
}
