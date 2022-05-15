namespace LeetCode
{


    public class CountIntervals
    {
        SortedList<int, int> list;
        public CountIntervals()
        {
            list = new SortedList<int, int>();
        }

        public void Add(int left, int right)
        {

            list.Add(left, right);
        }

        public int Count()
        {
            return list.Count;
        }

    }
}