using DataStructure.Graph;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSort
{
	public static class TopologicalSort<t>
	{
		public static IEnumerable<t> Sort(Graph<t> graph)
		{
			LinkedList<t> result = new LinkedList<t>();

			while(graph.Verticies.Count > 0)
			{
				IList<t> verticesWithNoSuccessors = new List<t>();

				var availableVerticies = graph.Verticies.ToList();
				var targetedVerticies = graph.Edges.Select(x => x.Second).Distinct().ToList();
				verticesWithNoSuccessors = availableVerticies.Except(targetedVerticies).ToList();
				foreach (t vertex in verticesWithNoSuccessors)
				{
					result.AddLast(vertex);

					//remove edges that originate from vertex from graph
					//var edgesToRemove = graph.Edges.Where(x => x.First.Equals(vertex)).ToList();
					//foreach (var edge in edgesToRemove)
					//{
					//	graph.RemoveEdge(edge);
					//}

					graph.RemoveVertex(vertex);
				}
			}

			return result;
		}

	}
}
