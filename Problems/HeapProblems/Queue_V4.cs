namespace HeapProblems
{
    public class Queue_V4
    {
        private Node[] nodes;
        private int capacity;
        private int pointer;

        public int Count { get { return pointer; } }
        public Queue_V4(int cap)
        {
            capacity = cap;
            nodes = new Node[capacity];
            pointer = 0;
        }

        public void Enqueue(Node node)
        {
            if (node==null || pointer >= capacity) return;

            nodes[pointer++] = node;
            decreaseKey(pointer-1);
        }

        public Node Dequeue()
        {
            Node node = nodes[0];

            nodes[0] = nodes[--pointer];
            increaseKey(0);
            return node;
        }

        public Node Peek()
        {
            return nodes[0];
        }

        private void increaseKey(int k)
        {
            int leftIndex = left(k);
            int rightIndex = right(k);

            if(leftIndex<pointer && rightIndex<pointer)
            {
                int minChildIndex = nodes[leftIndex].data < nodes[rightIndex].data ? leftIndex : rightIndex;

                if (nodes[k].data > nodes[minChildIndex].data)
                {
                    swap(minChildIndex, k);
                    increaseKey(minChildIndex);
                }
            }
            else if (leftIndex < pointer)
            {
                if(nodes[k].data > nodes[leftIndex].data)
                {
                    swap(k,leftIndex);
                }
            }
        }

        private void swap(int minChildIndex, int k)
        {
            Node n = nodes[minChildIndex];
            nodes[minChildIndex] = nodes[k];
            nodes[k] = n;
        }

        private void decreaseKey(int k)
        {
            if (k == 0) return;
            int parentIndex = parent(k);

            if(nodes[parentIndex].data > nodes[k].data)
            {
                swap(parentIndex, k);
                decreaseKey(parentIndex);
            }
        }

        private int left(int k)
        {
            return 2 * k + 1;
        }

        private int right(int k)
        {
            return 2 * k + 2;
        }

        private int parent(int k)
        {
            return (k - 1) / 2;
        }
    }
}
