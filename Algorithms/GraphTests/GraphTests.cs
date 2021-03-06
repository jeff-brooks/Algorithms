using DataStructure.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using GraphApplications;

namespace GraphTests
{
	[TestClass]
	public class GraphTests
	{
		[TestMethod]
		public void TopologicalSortTest()
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

			var result = TopologicalSort<char>.Sort(g);

			using (var enumerator = result.GetEnumerator())
			{
				enumerator.MoveNext();
				Assert.AreEqual('a', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('g', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('b', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('d', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('e', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('c', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('f', enumerator.Current);
			}
		}

		[TestMethod]
		public void DfsSpanningTreeTest()
		{
			//A spanning tree should have N verticies and (N - 1) Edges.
			//Every vertex in the graph should also be in the spanning tree.

			Graph<char> g = new Graph<char>();
			g.AddEdge('a', 'i', 1);
			g.AddEdge('a', 'b', 1);
			g.AddEdge('b', 'e', 1);
			g.AddEdge('b', 'c', 1);
			g.AddEdge('c', 'd', 1);
			g.AddEdge('c', 'e', 1);
			g.AddEdge('d', 'h', 1);
			g.AddEdge('e', 'g', 1);
			g.AddEdge('g', 'd', 1);
			g.AddEdge('f', 'a', 1);
			g.AddEdge('f', 'g', 1);

			var result = DfsSpanningTree<char>.GenerateDfsSpanningTree(g);

			Assert.AreEqual(g.Verticies.Count, result.Verticies.Count);
			Assert.AreEqual(g.Verticies.Count - 1, result.Edges.Count);

			using (var verticiesEnumerator = result.Verticies.GetEnumerator())
			{
				verticiesEnumerator.MoveNext();
				Assert.AreEqual('a', verticiesEnumerator.Current);
				verticiesEnumerator.MoveNext();
				Assert.AreEqual('b', verticiesEnumerator.Current);
				verticiesEnumerator.MoveNext();
				Assert.AreEqual('c', verticiesEnumerator.Current);
				verticiesEnumerator.MoveNext();
				Assert.AreEqual('d', verticiesEnumerator.Current);
				verticiesEnumerator.MoveNext();
				Assert.AreEqual('g', verticiesEnumerator.Current);
				verticiesEnumerator.MoveNext();
				Assert.AreEqual('e', verticiesEnumerator.Current);
				verticiesEnumerator.MoveNext();
				Assert.AreEqual('f', verticiesEnumerator.Current);
				verticiesEnumerator.MoveNext();
				Assert.AreEqual('h', verticiesEnumerator.Current);
				verticiesEnumerator.MoveNext();
				Assert.AreEqual('i', verticiesEnumerator.Current);
			}
		}

		[TestMethod]
		public void BfsSpanningTreeTest()
		{
			Graph<char> g = new Graph<char>();
			g.AddEdge('a', 'i', 1);
			g.AddEdge('a', 'b', 1);
			g.AddEdge('b', 'e', 1);
			g.AddEdge('b', 'c', 1);
			g.AddEdge('c', 'd', 1);
			g.AddEdge('c', 'e', 1);
			g.AddEdge('d', 'h', 1);
			g.AddEdge('e', 'g', 1);
			g.AddEdge('g', 'd', 1);
			g.AddEdge('f', 'a', 1);
			g.AddEdge('f', 'g', 1);

			var result = BfsSpanningTree<char>.GenerateBfsSpanningTree(g);

			Assert.AreEqual(g.Verticies.Count, result.Verticies.Count);
			Assert.AreEqual(g.Verticies.Count - 1, result.Edges.Count);

			using (var enumerator = result.Verticies.GetEnumerator())
			{
				enumerator.MoveNext();
				Assert.AreEqual('a', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('b', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('f', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('i', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('c', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('e', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('g', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('d', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('h', enumerator.Current);
			}
		}

		[TestMethod]
		public void MstTest()
		{
			Graph<char> g = new Graph<char>();
			g.AddEdge('a', 'i', 2);
			g.AddEdge('a', 'b', 6);
			g.AddEdge('b', 'e', 9);
			g.AddEdge('b', 'c', 7);
			g.AddEdge('c', 'd', 4);
			g.AddEdge('c', 'e', 3);
			g.AddEdge('d', 'h', 1);
			g.AddEdge('e', 'g', 8);
			g.AddEdge('g', 'd', 5);
			g.AddEdge('f', 'a', 4);
			g.AddEdge('f', 'g', 2);

			var result = MinimumSpanningTree<char>.GetMstByPrims(g);
			
			Assert.AreEqual(g.Verticies.Count, result.Verticies.Count);
			Assert.AreEqual(g.Verticies.Count - 1, result.Edges.Count);

			using (var enumerator = result.Verticies.GetEnumerator())
			{
				enumerator.MoveNext();
				Assert.AreEqual('a', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('i', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('f', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('g', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('d', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('h', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('c', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('e', enumerator.Current);
				enumerator.MoveNext();
				Assert.AreEqual('b', enumerator.Current);
			}
		}

		[TestMethod]
		public void Dijkstra()
		{
			IGraph<char> g = new BiDirectionalWeightedGraph<char>();
			g.AddEdge('a', 'b', 8);
			g.AddEdge('a', 'e', 4);
			g.AddEdge('a', 'd', 9);
			g.AddEdge('b', 'c', 1);
			g.AddEdge('c', 'b', 2);
			g.AddEdge('c', 'd', 3);
			g.AddEdge('d', 'e', 7);
			g.AddEdge('d', 'c', 2);
			g.AddEdge('e', 'c', 1);

			var results = new Dijkstra<char>(g);

			Assert.AreEqual(7, results.GetSmallestDistanceBetween('a', 'b'));	//a -> d -> c -> d
			Assert.AreEqual(5, results.GetSmallestDistanceBetween('a', 'c'));	//a -> d -> c
			Assert.AreEqual(8, results.GetSmallestDistanceBetween('a', 'd'));	//a -> d
			Assert.AreEqual(4, results.GetSmallestDistanceBetween('a', 'e'));	//a -> e
			
			Assert.AreEqual(int.MaxValue, results.GetSmallestDistanceBetween('b', 'a')); //impossible path
			Assert.AreEqual(1, results.GetSmallestDistanceBetween('b', 'c'));	// b -> c
			Assert.AreEqual(4, results.GetSmallestDistanceBetween('b', 'd'));	// b -> c -> d
			Assert.AreEqual(11, results.GetSmallestDistanceBetween('b', 'e'));// b -> c -> d -> e

			Assert.AreEqual(int.MaxValue, results.GetSmallestDistanceBetween('c', 'a')); //impossible path
			Assert.AreEqual(2, results.GetSmallestDistanceBetween('c', 'b'));	// c -> b
			Assert.AreEqual(3, results.GetSmallestDistanceBetween('c', 'd'));	// c -> d
			Assert.AreEqual(10, results.GetSmallestDistanceBetween('c', 'e'));// c -> d -> e

			Assert.AreEqual(int.MaxValue, results.GetSmallestDistanceBetween('d', 'a')); //impossible path
			Assert.AreEqual(4, results.GetSmallestDistanceBetween('d', 'b'));	// d -> c -> b
			Assert.AreEqual(2, results.GetSmallestDistanceBetween('d', 'c'));	// d -> c
			Assert.AreEqual(7, results.GetSmallestDistanceBetween('d', 'e'));	// d -> e

			Assert.AreEqual(int.MaxValue, results.GetSmallestDistanceBetween('e', 'a')); //impossible path
			Assert.AreEqual(3, results.GetSmallestDistanceBetween('e', 'b'));	// e -> c -> b
			Assert.AreEqual(1, results.GetSmallestDistanceBetween('e', 'c'));	// e -> c
			Assert.AreEqual(4, results.GetSmallestDistanceBetween('e', 'd'));	// e -> c -> d
		}
	}
}
