using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberOfIslands;

namespace NumberOfIslandsTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			char[][] grid = new char[][] {   new char[] { '1', '1', '1', '1', '0' },
											 new char[] { '1', '1', '0', '1', '0' },
											 new char[] { '1', '1', '0', '0', '0' },
											 new char[] { '0', '0', '0', '0', '0' } };
			Assert.AreEqual(1, Soln0.NumIslands(grid));

			grid = new char[][] {   new char[] { '1', '1', '0', '0', '0' },
									new char[] { '1', '1', '0', '0', '0' },
									new char[] { '0', '0', '1', '0', '0' },
									new char[] { '0', '0', '0', '1', '1' } };

			Assert.AreEqual(3, Soln0.NumIslands(grid));
		}
	}
}
