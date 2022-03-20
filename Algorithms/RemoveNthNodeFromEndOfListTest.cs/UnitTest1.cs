using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReverseLinkedList;
using RemoveNthNodeFromEndOfList;

namespace RemoveNthNodeFromEndOfListTest.cs
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Test1()
		{
			ListNode e5 = new ListNode(5, null);
			ListNode e4 = new ListNode(4, e5);
			ListNode e3 = new ListNode(3, e4);
			ListNode e2 = new ListNode(2, e3);
			ListNode e1 = new ListNode(1, e2);

			var result = Soln.RemoveNthFromEnd(e1, 2);

			Assert.AreEqual(e1.val, result.val);
			Assert.AreEqual(e1.next, result.next);
			result = result.next;

			Assert.AreEqual(e2.val, result.val);
			Assert.AreEqual(e2.next, result.next);
			result = result.next;

			Assert.AreEqual(e3.val, result.val);
			Assert.AreEqual(e3.next, result.next);
			result = result.next;

			Assert.AreEqual(e5.val, result.val);
			Assert.AreEqual(e5.next, result.next);
			result = result.next;

			Assert.AreEqual(null, result);
		}

		[TestMethod]
		public void Test2()
		{
			ListNode t2e1 = new ListNode(1, null);
			var result = Soln.RemoveNthFromEnd(t2e1, 1);

			Assert.AreEqual(null, result);
		}

		[TestMethod]
		public void Test3()
		{
			ListNode e2 = new ListNode(2, null);
			ListNode e1 = new ListNode(1, e2);

			var result = Soln.RemoveNthFromEnd(e1, 2);

			Assert.AreEqual(e2, result);
		}
	}
}
