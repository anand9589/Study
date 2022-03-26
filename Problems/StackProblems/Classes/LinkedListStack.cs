using Common;

namespace StackProblems.Classes
{
    public class LinkedListStack
    {
        Node head = null;
        public void push(int x)
        {
            if (head == null)
            {
                head = new Node(x);
            }
            else
            {
                Node temp = head;
                Node newNode = new Node(x);
                newNode.Next = temp;
                head = newNode;
            }
        }

        public int pop()
        {
            if (head == null) return -1;
            int data  = head.Data;
            if(head.Next != null)
            {
                Node temp = head.Next;
                head = temp;
            }
            else
            {
                head = null;
            }
            return data;
        }
    }
}
