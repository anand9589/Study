namespace HeapProblems
{
    internal class QueueNode : IComparable<QueueNode>
    {
        public int Index { get; set; }
        public int Value { get; set; }
        public int CompareTo(QueueNode? other)
        {
            if (other == null) return 1;
            if (other.Value < Value)
            {
                return 1;
            }
            if (other.Value > Value)
            {
                return -1;
            }
            return 0;
        }
    }
}
