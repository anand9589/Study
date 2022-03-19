namespace SinglyLinkedList
{
    internal class Node<T>
    {
        public T Data { get; set; }

        public Node<T> Next { get; set; }

        public Node(T data)
        {
            this.Data = data;
        }
    }
}
