namespace StackProblems.TwoStacksProblem
{
    internal class Stacks
    {

        //Complete this function
        public void Push1(int x, TwoStack sq)
        {
            if (sq.Top1 >= sq.Top2) return;
            sq.Top1++;
            sq.Arr[sq.Top1] = x;
        }

        //Function to push an integer into the stack2.
        public void Push2(int x, TwoStack sq)
        {
            if (sq.Top1 >= sq.Top2) return;
            sq.Top2--;
            sq.Arr[sq.Top2] = x;
        }

        //Function to remove an element from top of the stack1.
        public int Pop1(TwoStack sq)
        {
            if (sq.Top1 == -1) return -1;
            int data = sq.Arr[sq.Top1];
            sq.Top1--;
            return data;
        }

        //Function to remove an element from top of the stack2.
        public int Pop2(TwoStack sq)
        {
            if (sq.Top2 == 100) return -1;
            int data = sq.Arr[sq.Top2];
            sq.Top2++;
            return data;
        }
    }
}
