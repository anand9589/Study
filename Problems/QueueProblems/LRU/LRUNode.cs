namespace QueueProblems.LRU
{
    internal class LRUNode
    {
        public int Data { get; set; }
        public int Key { get; private set; }
        public LRUNode Next { get; set; }
        public LRUNode Previous { get; set; }

        public LRUNode()
        {

        }

        public LRUNode(int key, int data)
        {
            this.Key = key;
            this.Data = data;
        }
    }
}
