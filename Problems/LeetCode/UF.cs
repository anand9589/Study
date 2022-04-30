namespace LeetCode
{
    public class UF
    {
        private int[] parent;

        public UF(int size)
        {
            parent = Enumerable.Range(0, size).ToArray();
        }

        public void Union(int x, int y)
        {
            int px = Find(x);
            int py = Find(y);


            if (px != py)
            {
                parent[px] = y;
            }
        }

        public int Find(int x)
        {
            return parent[x] == x ? x : Find(parent[x]);
        }
    }
}
