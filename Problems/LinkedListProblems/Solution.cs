using Common;

namespace LinkedListProblems
{
    internal class Solution<T>
    {
        internal void RemoveLoop(NodeGeneric<T> head)
        {

            if (head == null) return;
            NodeGeneric<T> temp = head;
            HashSet<NodeGeneric<T>> visited = new HashSet<NodeGeneric<T>>();
            while (temp.Next !=null && !visited.Contains(temp.Next))
            {
                visited.Add(temp);
                temp = temp.Next;
            }

            temp.Next = null;
        }

        internal T IntersectPoint(NodeGeneric<T> head1, NodeGeneric<T> head2)
        {
            if(head1 == null || head2 == null) return default;
            //Your code here
            HashSet<NodeGeneric<T>> visited = new HashSet<NodeGeneric<T>>();
            while (head1 != null || head2 != null)
            {
                if (!visited.Contains(head1))
                {
                    visited.Add(head1);
                }
                else
                {
                    return head1.Data;
                }
                if (!visited.Contains(head2))
                {
                    visited.Add(head2);
                }
                else
                {
                    return head2.Data;
                }
            }
            return default;
        }

        internal NodeGeneric<T> AddTwoLists(NodeGeneric<T> first, NodeGeneric<T> second)
        {
            //Code here
            List<string> lst1 = new List<string>();
            List<string> lst2 = new List<string>();

            while (first!=null)
            {
                lst1.Add(first.Data.ToString());
                first = first.Next;
            }

            while (second != null)
            {
                lst2.Add(second.Data.ToString());
                second = second.Next;
            }

            int num1 = Convert.ToInt32(string.Concat(lst1));
            int num2 = Convert.ToInt32(string.Concat(lst2));

            int result = num1 + num2;
            int[] finarra = new int[result.ToString().Length];

            for (int i = 0; i < finarra.Length; i++)
            {
                finarra[i] = result % 10;
                result = result / 10;
            }

            

            return default;
        }

        internal bool DetectLoop(NodeGeneric<T> head)
        {
            if (head == null) return false;
            NodeGeneric<T> temp = head;
            HashSet<NodeGeneric<T>> visited = new HashSet<NodeGeneric<T>>();
            while (temp.Next != null)
            {
                if (visited.Contains(temp))
                {
                    return true;
                }
                visited.Add(temp);
                temp = temp.Next;
            }
            return false;
        }
    }
}
