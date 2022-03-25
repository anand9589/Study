// See https://aka.ms/new-console-template for more information
using Common;
using LinkedListProblems;

string[] lines = File.ReadAllLines(@"C:\Workspace\Study\Problems\Problem3.txt");
#region Problem1

//using LinkedListProblems;

//Console.WriteLine("Hello, World!");

//string[] lines = File.ReadAllLines(@"C:\Workspace\Study\Problems\Problem1.txt");
//int n = int.Parse(lines[0]);

//int[] arr = Array.ConvertAll(lines[1].Split(' '), int.Parse);

//Node<int> head = new Node<int>(arr[0]);
//Node<int> tail = head;


//for (int i = 1; i < n; i++)
//{
//    tail.Next = new Node<int>(arr[i]);
//    tail = tail.Next;
//}

//int x = Convert.ToInt32(lines[2]);
//loopHere(head, tail, x);
//Solution<int> obj = new Solution<int>();
//obj.RemoveLoop(head);
//if (isLoop(head) || length(head) != n)
//{
//    Console.Write("0\n");
//}
//else
//{
//    Console.Write("1\n");
//}

//static void printList(Node<int> head)
//{
//    while (head != null)
//    {
//        Console.Write(head.Data + " ");
//        head = head.Next;
//    }
//    Console.Write("\n");
//}

//static void loopHere(Node<int> head, Node<int> tail, int x)
//{
//    if (x == 0)
//    {
//        return;
//    }
//    Node<int> walk = head;

//    for (int i = 1; i < x; i++)
//    {
//        walk = walk.Next;
//    }
//    tail.Next = walk;
//}
//static bool isLoop(Node<int> head)
//{
//    Node<int> hare = head.Next;
//    Node<int> tortoise = head;
//    while (hare != tortoise)
//    {
//        if (hare == null || hare.Next == null) return false;
//        hare = hare.Next.Next;
//        tortoise = tortoise.Next;
//    }
//    return true;
//}
//static int length(Node<int> head)
//{
//    int ret = 0;
//    while (head != null)
//    {
//        ret += 1;
//        head = head.Next;
//    }
//    return ret;
//}

#endregion

#region Problem2

//int len1 = Convert.ToInt32(lines[0]);
//int len2 = Convert.ToInt32(lines[2]);

//int[] arr1 = Array.ConvertAll(lines[1].Split(' '), int.Parse);
//int[] arr2 = Array.ConvertAll(lines[3].Split(' '), int.Parse);

//Node firstHead = new Node(arr1[0]);
//Node secondHead = new Node(arr2[0]);
//Node temp = firstHead;
//for (int i = 1; i < len1; i++)
//{
//    temp.Next = new Node(arr1[i]);
//    temp = temp.Next;
//}

//temp = secondHead;
//for (int i = 1; i < len2; i++)
//{
//    temp.Next = new Node(arr2[i]);
//    temp = temp.Next;
//}

//Sol1 o = new Sol1();
//Node res = o.AddTwoLists(firstHead, secondHead);
#endregion

#region Problem 3

int[] arr1 = Array.ConvertAll(lines[1].Trim().Split(' '), int.Parse);
int[] arr2 = Array.ConvertAll(lines[2].Trim().Split(' '), int.Parse);

Node firstHead = new Node(arr1[0]);
Node secondHead = new Node(arr2[0]);
Node temp = firstHead;
for (int i = 1; i < arr1.Length; i++)
{
    temp.Next = new Node(arr1[i]);
    temp = temp.Next;
}

temp = secondHead;
for (int i = 1; i < arr2.Length; i++)
{
    temp.Next = new Node(arr2[i]);
    temp = temp.Next;
}

Sol1 o = new Sol1();
Node res = o.SortedMerge(firstHead, secondHead);
#endregion