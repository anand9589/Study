namespace LeetCode
{
    public class ListNode
    {
        public int val { get; set; }
        public ListNode Next { get; set; }

        public ListNode(int val, ListNode next = null)
        {
            this.val = val;
            this.Next = next;
        }
    }
}