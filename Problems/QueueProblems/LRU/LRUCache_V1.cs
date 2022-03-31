namespace QueueProblems.LRU
{
    internal class LRUCache_V1
    {
        readonly int capacity;
        readonly LinkedList<int> ll;
        readonly Dictionary<int,int> dct;
        public LRUCache_V1(int cap)
        { 
            this.capacity = cap;
            ll = new LinkedList<int>();
            dct = new Dictionary<int,int>();
        }
        public int get(int key)
        {
            if (dct.ContainsKey(key))
            {
                ll.Remove(key);
                ll.AddFirst(key);

                return dct[key];    
            }
            return 0;
        }
        public void set(int key, int value)
        {
            if (dct.ContainsKey(key))
            {
                dct[key] = value;
                ll.Remove(key);
                ll.AddFirst(key);
            }
            else
            {
                if(dct.Count == capacity)
                {
                    int k = ll.Last();
                   ll.RemoveLast();
                    dct.Remove(k);
                }

                ll.AddFirst(key);
                dct.Add(key, value);
            }
        }
    }
}
