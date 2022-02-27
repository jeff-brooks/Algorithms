using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinStackTest
{
	[TestClass]
	public class UnitTest
	{
		[TestMethod]
		public void TestMethod()
		{
			MinStack.MinStackWithHeap minStack = new MinStack.MinStackWithHeap();
			minStack.Push(-2);
			minStack.Push(0);
			minStack.Push(-3);
			Assert.AreEqual(-3, minStack.GetMin());
			minStack.Pop();
			Assert.AreEqual(0, minStack.Top());
			Assert.AreEqual(-2, minStack.GetMin());

			minStack = new MinStack.MinStackWithHeap();
			minStack.Push(0);
			minStack.Push(1);
			minStack.Push(0);
			Assert.AreEqual(0, minStack.GetMin());
			minStack.Pop();
			Assert.AreEqual(1, minStack.Top());
			Assert.AreEqual(0, minStack.GetMin());

			minStack = new MinStack.MinStackWithHeap();
			minStack.Push(2);
			minStack.Push(0);
			minStack.Push(3);
			minStack.Push(0);
			Assert.AreEqual(0, minStack.GetMin());
			minStack.Pop();
			Assert.AreEqual(0, minStack.GetMin());
			minStack.Pop();
			Assert.AreEqual(0, minStack.GetMin());
			minStack.Pop();
			Assert.AreEqual(2, minStack.GetMin());


			minStack = new MinStack.MinStackWithHeap();
			minStack.Push(-10);
			minStack.Push(14);
			Assert.AreEqual(-10, minStack.GetMin());
			Assert.AreEqual(-10, minStack.GetMin());
			minStack.Push(-20);
			Assert.AreEqual(-20, minStack.GetMin());
			Assert.AreEqual(-20, minStack.GetMin());
			Assert.AreEqual(-20, minStack.Top());
			Assert.AreEqual(-20, minStack.GetMin());
			minStack.Pop();
			minStack.Push(10);
			minStack.Push(-7);
			Assert.AreEqual(-10, minStack.GetMin());
			minStack.Push(-7);
			minStack.Pop();
			Assert.AreEqual(-7, minStack.Top());
			Assert.AreEqual(-10, minStack.GetMin());
			minStack.Pop();

			minStack = new MinStack.MinStackWithHeap();
			minStack.Push(85);
			minStack.Push(-99);
			Assert.AreEqual(-99, minStack.GetMin());
			minStack.Push(-27);
			minStack.Push(61);
			minStack.Push(-97);
			minStack.Push(-27);
			minStack.Push(35);
			Assert.AreEqual(35, minStack.Top());
			minStack.Push(99);
			minStack.Push(-66);
			Assert.AreEqual(-99, minStack.GetMin());
			minStack.Push(-89);
			Assert.AreEqual(-99, minStack.GetMin());

			minStack = new MinStack.MinStackWithHeap();
			minStack.Push(395);
			Assert.AreEqual(395, minStack.GetMin());
			Assert.AreEqual(395, minStack.Top());
			Assert.AreEqual(395, minStack.GetMin());
			minStack.Push(276);
			minStack.Push(29);
			Assert.AreEqual(29, minStack.GetMin());
			minStack.Push(-482);
			Assert.AreEqual(-482, minStack.GetMin());
			minStack.Pop();
			minStack.Push(-108);
			minStack.Push(-251);
			Assert.AreEqual(-251, minStack.GetMin());
			minStack.Push(-439);
			Assert.AreEqual(-439, minStack.Top());
			minStack.Push(370);
			minStack.Pop();
			minStack.Pop();
			Assert.AreEqual(-251, minStack.GetMin());
		}
	}
}
