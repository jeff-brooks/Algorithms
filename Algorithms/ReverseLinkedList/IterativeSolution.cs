namespace ReverseLinkedList
{
	public static class IterativeSolution
	{
		/// <summary>
		/// Iterate through the list once, reversing the direction of the connection between each node
		/// </summary>
		/// <param name="head"></param>
		/// <returns></returns>
		public static ListNode ReverseList(ListNode head)
		{
			ListNode prev = null;

			while( head != null)
			{
				ListNode nextNode = head.next;

				head.next = prev;
				prev = head;
				
				head = nextNode;
			}

			return prev;
		}
	}
}
