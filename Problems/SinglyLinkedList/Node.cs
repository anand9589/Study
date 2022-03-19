namespace SinglyLinkedList
{
    internal class Node
    {
        public int Data { get; set; }

        public Node Next { get; set; }

        public Node(int data)
        {
            this.Data = data;
        }
    }
}
