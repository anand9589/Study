namespace StackProblems.TwoStacksProblem
{
    internal class Stacks
    {

        //Complete this function
        public void push1(int x, TwoStack sq)
        {
            if (sq.top1 >= sq.top2) return;
            sq.top1++;
            sq.arr[sq.top1] = x;
        }

        //Function to push an integer into the stack2.
        public void push2(int x, TwoStack sq)
        {
            if (sq.top1 >= sq.top2) return;
            sq.top2--;
            sq.arr[sq.top2] = x;
        }

        //Function to remove an element from top of the stack1.
        public int pop1(TwoStack sq)
        {
            if (sq.top1 == -1) return -1;
            int data = sq.arr[sq.top1];
            sq.top1--;
            return data;
        }

        //Function to remove an element from top of the stack2.
        public int pop2(TwoStack sq)
        {
            if (sq.top2 == 100) return -1;
            int data = sq.arr[sq.top2];
            sq.top2++;
            return data;
        }
    }
}
