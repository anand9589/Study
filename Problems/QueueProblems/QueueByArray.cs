namespace QueueProblems
{
    internal class QueueByArray
    {
		public int front;
		public int rear;
		public int[] arr = new int[100005];

		public QueueByArray()
		{
			this.front = 0;
			this.rear = 0;
		}

		//Function to push an element x in a queue.
		public void push(int x)
		{
			// Your code here
		if (this.rear >= 100005) return;
			arr[this.rear++] = x;
		}

		//Function to pop an element from queue and return that element.
		public int pop()
		{
			// Your code here
			if(this.front >= this.rear) return -1;

			return arr[this.front++];
		}
	}
}
