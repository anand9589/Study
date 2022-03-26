// See https://aka.ms/new-console-template for more information
using StackProblems;
using StackProblems.Classes;
using StackProblems.TwoStacksProblem;

//Console.WriteLine("Hello, World!");

string[] lines = File.ReadAllLines(@"C:\Workspace\Study\Problems\StackProblem1.txt");

#region Problem4
int[] arr = Array.ConvertAll(lines[1].Trim().Split(' '), int.Parse);
Stacks stacks = new Stacks();
TwoStack twoStack = new TwoStack();
for (int i = 0; i < arr.Length; i++)
{
    switch (arr[i])
    {
        case 1:
            //Stack1 operation
            i++;
            switch (arr[i])
            {
                case 1:
                    i++;
                    stacks.Push1(arr[i], twoStack);
                    //stack1 push
                    break;
                case 2:
                    //stack2 pop
                    Console.WriteLine(stacks.Pop1(twoStack));
                    break;
                default:
                    break;
            }
            break;
        case 2:
            //Stack2 operation
            i++;
            switch (arr[i])
            {
                case 1:
                    //stack2 push
                    i++;
                    stacks.Push2(arr[i], twoStack);
                    break;
                case 2:
                    //stack2 pop
                    Console.WriteLine(stacks.Pop2(twoStack));
                    break;
                default:
                    break;
            }
            break;
        default:
            break;
    }
}

//Solution o = new Solution();
//long[] arr = new long[]
//{
//    55, 67, 34, 5, 25, 10,29, 33
//};
//var res = o.NextLargerElement(arr, 8);
#endregion

#region SortedStack

Stack<int> stacks2 = new Stack<int>();
stacks2.Push(44);
stacks2.Push(48);
stacks2.Push(23);
stacks2.Push(41);
stacks2.Push(49);
stacks2.Push(44);
stacks2.Push(55);
stacks2.Push(67);
stacks2.Push(13);

SortedStack sortedStack = new SortedStack(stacks2);
var result = sortedStack.GetSortedStack();
#endregion
