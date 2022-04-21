namespace ArrayProblems
{
    internal class MyHashSet
    {
        private List<int> list;
        public MyHashSet()
        {
            list = new List<int>();
        }

        public void Add(int key)
        {
            if (!Contains(key))
            {
                list.Add(key);
            }
        }

        public void Remove(int key)
        {
            list.Remove(key);
        }

        public bool Contains(int key)
        {
            return list.Contains(key);
        }
    }
}
