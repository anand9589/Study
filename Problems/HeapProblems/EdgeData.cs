namespace HeapProblems
{
    internal class EdgeData
    {
        private int[] parent;
        private int[] rank;
        public EdgeData(int size)
        {
            parent = Enumerable.Range(0, size).ToArray();
            rank = Enumerable.Repeat(1, size).ToArray();
        }

        public bool Union(int x, int y)
        {
            int px = Find(x);
            int py = Find(y);

            if (px == py)
            {
                return false;
            }

            if (rank[px] > rank[py])
            {
                parent[px] = py;
            }
            else if (rank[px] < rank[py])
            {
                parent[py] = px;
            }
            else
            {
                rank[px]++;
                parent[px] = py;
            }

            return true;
        }

        private int Find(int x)
        {
            if (parent[x] == x) return x;

            return Find(parent[x]);
        }
    }
}
