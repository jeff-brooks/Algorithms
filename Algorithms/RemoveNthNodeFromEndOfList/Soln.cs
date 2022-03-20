using ReverseLinkedList;

namespace RemoveNthNodeFromEndOfList
{

	public static class Soln
	{
		public static ListNode RemoveNthFromEnd(ListNode head, int n)
		{
			if (head == null)
			{
				return head;
			}

			if (head.next == null)
			{
				if (n > 0)
				{
					return null;
				}
				return head;
			}

			ListNode startingPointer = head;

			ListNode fast = head;

			for (int i = 0; i < n; i++)
			{
				fast = fast.next;
			}

			if (fast == null)
			{
				return head.next;
			}

			while (head.next != null)
			{

				if (fast.next != null)
				{
					head = head.next;
					fast = fast.next;
				}
				else
				{
					ListNode skip = head.next;
					head.next = skip.next;
					break;
				}
			}

			return startingPointer;
		}
	}
}
