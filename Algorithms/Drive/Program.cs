using System;
using DataStructure.Graph;

namespace Drive
{
	class Program
	{
		static void Main(string[] args)
		{
			
		}

		private static void WatchSearch0()
		{
			Graph<char> g = new Graph<char>();
			g.AddEdge('i', 'a', 1);
			g.AddEdge('a', 'f', 1);
			g.AddEdge('a', 'b', 1);
			g.AddEdge('b', 'e', 1);
			g.AddEdge('b', 'c', 1);
			g.AddEdge('e', 'g', 1);
			g.AddEdge('c', 'd', 1);
			g.AddEdge('g', 'd', 1);
			g.AddEdge('d', 'h', 1);
			g.AddEdge('e', 'c', 1);
			g.AddEdge('f', 'g', 1);

			DFS<char>.Search('a', g);
			BFS<char>.Search('a', g);
		}

		private static void WatchSearch1()
		{
			Graph<char> g = new Graph<char>();
			g.AddEdge('v', 'u', 1);
			g.AddEdge('v', 'w', 1);
			g.AddEdge('v', 'x', 1);
			g.AddEdge('u', 'q', 1);
			g.AddEdge('u', 't', 1);
			g.AddEdge('q', 'r', 1);
			g.AddEdge('q', 's', 1);

			DFS<char>.Search('v', g);
			BFS<char>.Search('v', g);
		}
	}
}
