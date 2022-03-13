using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructure.Graph;
using DfsTopSort;
using System.Collections.Generic;
using System.Linq;

namespace DfsTopSort
{
	[TestClass]
	public class TolologicalSortTest
	{
		[TestMethod]
		public void Test1()
		{
			Graph<char> g = new Graph<char>();
			g.AddEdge('a', 'b', 1);
			g.AddEdge('b', 'c', 1);
			g.AddEdge('a', 'd', 1);
			g.AddEdge('d', 'e', 1);
			g.AddEdge('e', 'c', 1);
			g.AddEdge('b', 'e', 1);
			g.AddEdge('e', 'f', 1);
			g.AddEdge('g', 'd', 1);

			var result = TopologicalSort.TopologicalSort<char>.Sort(g);
			Assert.IsTrue(Enumerable.SequenceEqual(new char[] {'a', 'g', 'b', 'd', 'e', 'c', 'f', }, result));
		}
	}
}
