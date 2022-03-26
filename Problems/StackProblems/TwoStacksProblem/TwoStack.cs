namespace StackProblems.TwoStacksProblem
{
    internal class TwoStack
    {

        public int Size { get; set; }
        public int Top1 { get; set; }
        public int Top2 { get; set; }

        public int[] Arr { get; set; }

        public TwoStack()
        {
            Size = 100;
            Top1 = -1;
            Top2 = Size;
            Arr = new int[Size];
        }
    }
}
