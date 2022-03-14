using DataStructure.Graph;
using System.Collections.Generic;
using System.Linq;

namespace GraphApplications
{
	public class DfsSpanningTree<t>
	{
		public static Graph<t> GenerateDfsSpanningTree(Graph<t> graph)
		{
			//graph needs to contain atleast to verticies to create a tree
			if (graph.Verticies.Count < 2)
			{
				return graph;
			}

			return GenerateDfsSpanningTree(graph, graph.Verticies[0]);
		}
		public static Graph<t> GenerateDfsSpanningTree(Graph<t> graph, t beginningVertex)
		{
			//graph needs to contain atleast to verticies to create a tree
			if(graph.Verticies.Count < 2)
			{
				return graph;
			}

			//traverse the graph using a DFS return the resulting graph.
			Graph<t> g = new Graph<t>();

			var visitedVertex = new List<t>();
			var stack = new Stack<t>();
			t currVertex = beginningVertex;

			stack.Push(currVertex);
			visitedVertex.Add(currVertex);

			while(visitedVertex.Count < graph.Verticies.Count)
			{
				var adjacentVerticies = graph.GetAdjacencyListFor(currVertex);
				bool allAdjacentVisited = true;
				foreach(var vertex in adjacentVerticies.Keys)
				{
					if (!visitedVertex.Contains(vertex))
					{
						g.AddEdge(currVertex, vertex, 1);

						visitedVertex.Add(vertex);
						stack.Push(vertex);
						allAdjacentVisited = false;
						currVertex = vertex;
												
						break;
					}
				}
				if (allAdjacentVisited)
				{
					stack.Pop();
					if(stack.Count > 0)
					{
						currVertex = stack.Peek();
					}
				}
			}

			return g;
		}
	}
}
