namespace Common
{
    public class NodeGeneric<T> 
    {
        public T Data { get; set; }

        public NodeGeneric<T> Next { get; set; }

        public NodeGeneric(T data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
}