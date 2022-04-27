namespace StringProblems
{
    public class StringUnion
    {
        private int[] parent;
        private int[] rank;

        public StringUnion(int size)
        {
            parent = Enumerable.Range(0, size).ToArray();
            rank = Enumerable.Repeat(1, size).ToArray();
        }

        public int Find(int x)
        {
            if(parent[x] == x) return x;

            return Find(parent[x]);
        }


        public bool Union(int x, int y)
        {
            int px = Find(x);
            int py = Find(y);

            if (px == py) return false;

            if (rank[px] > rank[py])
            {
                parent[py] = px;
                rank[px] += rank[py];
            }
            else
            {
                parent[px] = py;
                rank[py] += rank[px];
            }


            return true;
        }
    }
}
