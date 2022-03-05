using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReverseLinkedList;

namespace ReverseLinkedListTest
{
	[TestClass]
	public class UnitTest
	{
		[TestMethod]
		public void TestMethod()
		{
			ListNode ln5 = new ListNode(5);
			ListNode ln4 = new ListNode(4, ln5);
			ListNode ln3 = new ListNode(3, ln4);
			ListNode ln2 = new ListNode(2, ln3);
			ListNode ln1 = new ListNode(1, ln2);

			ListNode resultIterative = IterativeSolution.ReverseList(ln1);

			Assert.AreEqual(ln5.val, resultIterative.val);
			Assert.AreEqual(ln5.next, resultIterative.next);
			resultIterative = resultIterative.next;

			Assert.AreEqual(ln4.val, resultIterative.val);
			Assert.AreEqual(ln4.next, resultIterative.next);
			resultIterative = resultIterative.next;

			Assert.AreEqual(ln3.val, resultIterative.val);
			Assert.AreEqual(ln3.next, resultIterative.next);
			resultIterative = resultIterative.next;

			Assert.AreEqual(ln2.val, resultIterative.val);
			Assert.AreEqual(ln2.next, resultIterative.next);
			resultIterative = resultIterative.next;

			Assert.AreEqual(ln1.val, resultIterative.val);
			Assert.AreEqual(ln1.next, resultIterative.next);
			resultIterative = resultIterative.next;

			Assert.AreEqual(null, resultIterative);
		}
	}
}
