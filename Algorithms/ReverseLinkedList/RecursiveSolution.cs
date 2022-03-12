namespace ReverseLinkedList
{
	public static class RecursiveSolution
	{
		public static ListNode ReverseList(ListNode head)
		{
			if (head == null || head.next == null)
			{
				return head;
			}

			var curr = head;
			var next = head.next;

			var reversedList = ReverseList(head.next);

			curr.next = null;
			next.next = curr;

			return reversedList;
		}
	}
}
