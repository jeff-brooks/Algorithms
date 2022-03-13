namespace DataStructure
{
	public class Node<t>
	{
		public readonly Node<t> Next;
		public readonly int Value;

		public Node(Node<t> nextNode, int value)
		{
			Next = nextNode;
			Value = value;
		}

	}
}
