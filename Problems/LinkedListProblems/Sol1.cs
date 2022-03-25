using Common;

namespace LinkedListProblems
{
    internal class Sol1
    {

        internal Node AddTwoLists(Node first, Node second)
        {
            //Code here
            List<int> lst1 = new List<int>();
            List<int> lst2 = new List<int>();

            while (first != null)
            {
                lst1.Insert(0, first.Data);
                first = first.Next;
            }

            while (second != null)
            {
                lst2.Insert(0, second.Data);
                second = second.Next;
            }

            int maxlen = lst1.Count > lst2.Count ? lst1.Count : lst2.Count;

            int[] res = new int[maxlen];
            int carryOn = 0, num1 = 0,num2 = 0, x = 0;

            for (int i = 0; i < maxlen; i++)
            {
                num1 = i < lst1.Count ? lst1[i] : 0;
                num2 = i < lst2.Count ? lst2[i] : 0;

                x = num1 + num2 + carryOn;

                if (x > 9)
                {
                    carryOn = x / 10;
                    x = x % 10;
                }
                else
                {
                    carryOn = 0;
                }

                res[i] = x;
            }

            int cntr = maxlen - 1;

            Node resultNode = new Node(res[cntr]);
            cntr--;
            Node temp = resultNode;

            while (cntr>=0)
            {
                temp.Next = new Node(res[cntr]);
                temp = temp.Next;
                cntr--;
            }

            if(carryOn > 0)
            {
                temp = resultNode;
                resultNode = new Node(carryOn);
                resultNode.Next = temp;
            }

            return resultNode;
        }

        internal Node SortedMerge(Node head1, Node head2)
        {
            if (head1 == null) return head2;
            if (head2 == null) return head1;
            List<Node> list = new List<Node>();
            while (head1 != null || head1 != null)
            {
                if (head1 == null)
                {
                    list.Add(new Node(head2.Data));
                    head2 = head2.Next;
                }
                else if (head2 == null)
                {
                    list.Add(new Node(head1.Data));
                    head1 = head1.Next;
                }
                else
                {

                    int data = -1;
                    if (head1.Data < head2.Data)
                    {
                        data = head1.Data;
                        head1 = head1.Next;
                    }
                    else
                    {
                        data = head2.Data;
                        head2 = head2.Next;
                    }

                    list.Add(new Node(data));
                }
            }


            for (int i = 0; i < list.Count-1; i++)
            {
               list[i].Next = list[i+1];
            }

            return list.Count>0 ? list[0] : null;
        }
    }
}
