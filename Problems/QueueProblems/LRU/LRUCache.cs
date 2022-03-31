namespace QueueProblems.LRU
{
    internal class LRUCache
    {
        private readonly int capacity;
        private readonly HashSet<LRUNode> nodes;
        private readonly LRUDoublyLinkedList doublyLinkedList;
        public LRUCache(int cap)
        {
            this.capacity = cap;
            nodes = new HashSet<LRUNode>();
            doublyLinkedList = new LRUDoublyLinkedList();
        }



        //Function to return value corresponding to the key.
        public int Get(int key)
        {
            var node = nodes.FirstOrDefault(x => x.Key == key);

            if (node == null)
            {
                return 0;
            }

            UpdateNodePositionToFront(node);

            return node.Data;
        }

        //Function for storing key-value pair.
        public void Set(int key, int value)
        {
            // your code here
            var node = nodes.FirstOrDefault(x => x.Key == key);

            if (node == null)
            {
                if(doublyLinkedList.Length == capacity)
                {
                    RemoveLastNode(true);
                }

                node = new LRUNode(key, value);
                AddNodeToFront(node,true);
            }
            else
            {
                node.Data = value;
                UpdateNodePositionToFront(node);
            }
        }

        private void RemoveLastNode(bool isRemoveFromHashset)
        {
            var temp = doublyLinkedList.Tail.Previous;

            doublyLinkedList.Tail.Previous = temp.Previous;
            temp.Previous.Next  = doublyLinkedList.Tail;

            if(isRemoveFromHashset)
            {
                nodes.Remove(temp);
            }
        }

        private void UpdateNodePositionToFront(LRUNode node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;

            AddNodeToFront(node, false);
        }

        private void AddNodeToFront(LRUNode node, bool isAddToHashset)
        {
            LRUNode temp = doublyLinkedList.Head.Next;
            doublyLinkedList.Head.Next = node;
            node.Next = temp;
            node.Previous = doublyLinkedList.Head;
            temp.Previous = node;

            if (isAddToHashset)
            {
                nodes.Add(node);
            }
        }
    }
}
