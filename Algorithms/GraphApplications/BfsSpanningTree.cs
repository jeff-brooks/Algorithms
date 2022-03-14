using DataStructure.Graph;
using System.Collections.Generic;

namespace GraphApplications
{
	public static class BfsSpanningTree<t>
	{
		/// <summary>
		/// generates a spanning tree for a connected undirected graph beginning
		/// </summary>
		/// <param name="graph"></param>
		/// <returns></returns>
		public static Graph<t> GenerateBfsSpanningTree(Graph<t> graph, t beginningVertex)
		{
			//graph needs to contain atleast to verticies to create a tree
			if (graph.Verticies.Count < 2)
			{
				return graph;
			}

			//traverse the graph using a DFS return the resulting graph.
			Graph<t> g = new Graph<t>();

			Queue<t> queue = new Queue<t>();
			queue.Enqueue(beginningVertex);

			List<t> visited = new List<t>();

			while (queue.Count > 0)
			{
				t currentVertex = queue.Dequeue();
				visited.Add(currentVertex);

				var adjacent = graph.GetAdjacencyListFor(currentVertex);
				foreach(var vertex in adjacent.Keys)
				{
					if (!visited.Contains(vertex))
					{
						g.AddEdge(currentVertex, vertex, 1);
						visited.Add(vertex);
						queue.Enqueue(vertex);
					}
				}
			}

			return g;
		}

		public static Graph<t> GenerateBfsSpanningTree(Graph<t> graph)
		{
			//graph needs to contain atleast to verticies to create a tree
			if (graph.Verticies.Count < 2)
			{
				return graph;
			}

			return GenerateBfsSpanningTree(graph, graph.Verticies[0]);
		}
	}
}
