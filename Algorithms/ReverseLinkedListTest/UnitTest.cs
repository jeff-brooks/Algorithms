using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReverseLinkedList;

namespace ReverseLinkedListTest
{
	[TestClass]
	public class UnitTest
	{
		private ListNode ln1;
		private ListNode ln2;
		private ListNode ln3;
		private ListNode ln4;
		private ListNode ln5;

		[TestInitialize]
		public void Initialize()
		{
			ln5 = new ListNode(5);
			ln4 = new ListNode(4, ln5);
			ln3 = new ListNode(3, ln4);
			ln2 = new ListNode(2, ln3);
			ln1 = new ListNode(1, ln2);
		}

		[TestMethod]
		public void TestIterative()
		{
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

		[TestMethod]
		public void TestRecursive()
		{
			ListNode resultRecursive = RecursiveSolution.ReverseList(ln1);

			Assert.AreEqual(ln5.val, resultRecursive.val);
			Assert.AreEqual(ln5.next, resultRecursive.next);
			resultRecursive = resultRecursive.next;

			Assert.AreEqual(ln4.val, resultRecursive.val);
			Assert.AreEqual(ln4.next, resultRecursive.next);
			resultRecursive = resultRecursive.next;

			Assert.AreEqual(ln3.val, resultRecursive.val);
			Assert.AreEqual(ln3.next, resultRecursive.next);
			resultRecursive = resultRecursive.next;

			Assert.AreEqual(ln2.val, resultRecursive.val);
			Assert.AreEqual(ln2.next, resultRecursive.next);
			resultRecursive = resultRecursive.next;

			Assert.AreEqual(ln1.val, resultRecursive.val);
			Assert.AreEqual(ln1.next, resultRecursive.next);
			resultRecursive = resultRecursive.next;

			Assert.AreEqual(null, resultRecursive);
		}
	}
}
