// See https://aka.ms/new-console-template for more information
using StackProblems;
using StackProblems.Classes;
using StackProblems.TwoStacksProblem;

//Console.WriteLine("Hello, World!");

string[] lines = File.ReadAllLines(@"C:\Workspace\Study\Problems\MaxRectangleMatrix.txt");
Solution solution = new Solution();
#region Problem4
//int[] arr = Array.ConvertAll(lines[1].Trim().Split(' '), int.Parse);
//Stacks stacks = new Stacks();
//TwoStack twoStack = new TwoStack();
//for (int i = 0; i < arr.Length; i++)
//{
//    switch (arr[i])
//    {
//        case 1:
//            //Stack1 operation
//            i++;
//            switch (arr[i])
//            {
//                case 1:
//                    i++;
//                    stacks.Push1(arr[i], twoStack);
//                    //stack1 push
//                    break;
//                case 2:
//                    //stack2 pop
//                    Console.WriteLine(stacks.Pop1(twoStack));
//                    break;
//                default:
//                    break;
//            }
//            break;
//        case 2:
//            //Stack2 operation
//            i++;
//            switch (arr[i])
//            {
//                case 1:
//                    //stack2 push
//                    i++;
//                    stacks.Push2(arr[i], twoStack);
//                    break;
//                case 2:
//                    //stack2 pop
//                    Console.WriteLine(stacks.Pop2(twoStack));
//                    break;
//                default:
//                    break;
//            }
//            break;
//        default:
//            break;
//    }
//}

//long[] arr = new long[]
//{
//    55, 67, 34, 5, 25, 10,29, 33
//};
//var res = solution.NextLargerElement(arr, 8);
#endregion

#region SortedStack

//Stack<int> stacks2 = new Stack<int>();
//stacks2.Push(44);
//stacks2.Push(48);
//stacks2.Push(23);
//stacks2.Push(41);
//stacks2.Push(49);
//stacks2.Push(44);
//stacks2.Push(55);
//stacks2.Push(67);
//stacks2.Push(13);

//SortedStack sortedStack = new SortedStack(stacks2);
//var result = sortedStack.GetSortedStack();
#endregion


#region SpanStack
//int n = int.Parse(lines[0]);
//int[] price = Array.ConvertAll(lines[1].Trim().Split(' '), int.Parse);
//var res = solution.CalculateSpan(price, n);
#endregion

#region NextSmallElement
//int[] input = Array.ConvertAll(lines[1].Trim().Split(' '), int.Parse);
//Console.WriteLine(String.Join(' ', input));

//int[] output = solution.NextSmallElement(input);
//Console.WriteLine("-->Next Small Element : ");
//Console.WriteLine(String.Join(' ', output));
//output = solution.PreviousSmallElement(input);
//Console.WriteLine("-->Previous Small Element : ");
//Console.WriteLine(String.Join(' ', output));
//output = solution.PreviousLargeElement(input);
//Console.WriteLine("-->Previous Large Element : ");
//Console.WriteLine(String.Join(' ', output));
//output = solution.NextLargeElement(input);
//Console.WriteLine("-->Next Large Element : ");
//Console.WriteLine(String.Join(' ', output));
#endregion

#region GetMaxHistogramArea
//long[] input =  new long[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
////var result = solution.getMaxArea(input, n);
//var result = solution.GetMaxArea(new long[] { 1 }, 1);
//Console.WriteLine(result);
#endregion

#region GetMaxAreaRectangle

//var rowColArray = Array.ConvertAll(lines[0].Trim().Split(' '), int.Parse);
//int row = rowColArray[0];
//int col = rowColArray[1];
//long[,] arr = new long[row, col];
//for (int i = 0; i < row; i++)
//{
//    var l = lines[i + 1].Trim().Split(' ');
//    for (int j = 0; j < col; j++)
//    {
//        arr[i, j] = int.Parse(l[j]);
//    }
//}

//var res = solution.GetMaxAreaRectangle(arr, row, col);
//Console.WriteLine(res);
#endregion

#region GetMaxAreaSquare
//var rowColArray = Array.ConvertAll(lines[0].Trim().Split(' '), int.Parse);
//int row = rowColArray[0];
//int col = rowColArray[1];
//long[,] arr = new long[row, col];
//for (int i = 0; i < row; i++)
//{
//    var l = lines[i + 1].Trim().Split(' ');
//    for (int j = 0; j < col; j++)
//    {
//        arr[i, j] = int.Parse(l[j]);
//    }
//}

//long result = solution.GetMaxAreaSquare(arr, row, col);
//Console.WriteLine(result);
#endregion

#region DeleteMidOfStack
//Stack<int> stack = new Stack<int>();
//stack.Push(1);
//stack.Push(2);
//stack.Push(3);
////stack.Push(4);
////stack.Push(5);
//stack = solution.DeleteMiddleElementOfStack(stack);
#endregion

#region EvaluatePostfixExpression
//string s = "42/";

//long result = solution.EvaluatePostfixExpression(s);
//Console.WriteLine(result);

#endregion

#region ReducedString
//string s = "geegsforgeeeks";
//string result = solution.ReducedString(s);
//Console.WriteLine(result);
#endregion

#region InfixToPostfix
//string s = "a+b*(c^d-e)^(f+g*h)-i";
//string result = solution.InfixToPostfix(s);
//Console.WriteLine(result);
#endregion

var res = solution.GenerateParenthesis(3);
