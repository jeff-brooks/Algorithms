using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;
using System.Collections;

namespace SortTests
{
	[TestClass]
	public class UnitTest1
	{
		private int[] collection;
		[TestInitialize]
		public void Initialize()
		{
			collection = new int[] { 29, 10, 14, 37, 13 };
		}

		[TestMethod]
		public void TestSelection()
		{
			SortAlgorithms<int>.SelectionSort(collection);

			var enumerator = collection.GetEnumerator();
			enumerator.MoveNext();

			Assert.AreEqual(10, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(13, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(14, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(29, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(37, enumerator.Current);
		}

		[TestMethod]
		public void TestBubble()
		{
			SortAlgorithms<int>.BubbleSort(collection);

			var enumerator = collection.GetEnumerator();
			enumerator.MoveNext();

			Assert.AreEqual(10, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(13, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(14, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(29, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(37, enumerator.Current);
		}

		[TestMethod]
		public void TestInsertion()
		{
			SortAlgorithms<int>.InsertionSort(collection);

			var enumerator = collection.GetEnumerator();
			enumerator.MoveNext();

			Assert.AreEqual(10, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(13, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(14, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(29, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(37, enumerator.Current);
		}

		[TestMethod]
		public void TestMerge()
		{
			SortAlgorithms<int>.MergeSort(collection);

			var enumerator = collection.GetEnumerator();
			enumerator.MoveNext();

			Assert.AreEqual(10, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(13, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(14, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(29, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(37, enumerator.Current);
		}

		[TestMethod]
		public void TestQuickSort()
		{
			SortAlgorithms<int>.QuickSort(collection);

			var enumerator = collection.GetEnumerator();
			enumerator.MoveNext();

			Assert.AreEqual(10, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(13, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(14, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(29, enumerator.Current);
			enumerator.MoveNext();

			Assert.AreEqual(37, enumerator.Current);
		}
	}
}
