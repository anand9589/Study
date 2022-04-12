namespace GraphProject
{
    internal class Graph_V1
    {
        LinkedList<int>[] nodearr;
        public Graph_V1(int nodeCount)
        {
            nodearr = new LinkedList<int>[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                nodearr[i] = new LinkedList<int>();
            }            
        }

        public void AddEdge(int sourceIndex, int destinationIndex)
        {
            nodearr[sourceIndex].AddLast(destinationIndex);
            nodearr[destinationIndex].AddLast(sourceIndex);
        }

        public void Print()
        {
            for (int i = 0; i < nodearr.Length; i++)
            {
                Console.WriteLine("\nEdges of node "+i);
                Console.Write("head");

                foreach (var item in nodearr[i])
                {
                    Console.Write(" --> " + item);
                }
            }
        }
    }
}
