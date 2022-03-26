namespace StackProblems.TwoStacksProblem
{
    internal class TwoStack
    {

		public int size;
		public int top1, top2;
		public int[] arr = new int[100];

		public TwoStack()
		{
			size = 100;
			top1 = -1;
			top2 = size;
		}
	}
}
