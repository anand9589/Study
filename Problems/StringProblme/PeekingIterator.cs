namespace StringProblems
{
    internal class PeekingIterator
    {
        IEnumerator<int> iterator;
        bool hasNext;
        public PeekingIterator(IEnumerator<int> iterator)
        {
            this.iterator = iterator;
            hasNext = true;
        }

        // Returns the next element in the iteration without advancing the iterator.
        public int Peek()
        {
            return iterator.Current;
        }

        // Returns the next element in the iteration and advances the iterator.
        public int Next()
        {
            int val = iterator.Current;
            hasNext = iterator.MoveNext();
            return val;
        }

        // Returns false if the iterator is refering to the end of the array of true otherwise.
        public bool HasNext()
        {
            return hasNext;
        }
    }
}
