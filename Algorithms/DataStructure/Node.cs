namespace DataStructure
{
	public class Node<t>
	{
		public readonly Node<t> Next;
		public readonly t Value;

		public Node(Node<t> nextNode, t value)
		{
			Next = nextNode;
			Value = value;
		}

	}
}
