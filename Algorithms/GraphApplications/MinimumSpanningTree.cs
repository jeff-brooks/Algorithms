using DataStructure.Graph;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GraphApplications
{
	public static class MinimumSpanningTree<t>
	{
		/// <summary>
		/// Generate the minimum spanning tree for a weighted, connected, undirected graph
		/// whose weights are nonnegative. Beginning with the first vertex in the graph.
		/// </summary>
		/// <param name="graph"></param>
		/// <returns></returns>
		public static Graph<t> GetMstByPrims(Graph<t> graph)
		{
			if(graph.Verticies.Count < 2 || graph.Edges.Count < 1)
			{
				return graph;
			}

			return GetMstByPrims(graph, graph.Verticies[0]);
		}

		/// <summary>
		/// Generate the minimum spanning tree for a weighted, connected, undirected graph
		/// whose weights are nonnegative. Beginning with the specified vertex in the graph.
		/// </summary>
		/// <param name="graph"></param>
		/// <param name="startingVertex"></param>
		/// <returns></returns>
		public static Graph<t> GetMstByPrims(Graph<t> graph, t startingVertex)
		{
			if (graph.Verticies.Count < 2 || graph.Edges.Count < 1)
			{
				return graph;
			}

			Graph<t> g = new Graph<t>();

			var currentVertex = startingVertex;
			var availableEdges = new SortedDictionary<int, List<Edge<t>>>();
			var visitedVerticies = new List<t>() { startingVertex };

			while(g.Verticies.Count < graph.Verticies.Count)
			{
				var adjacent = graph.GetAdjacencyListFor(currentVertex);
				
				foreach(var vertex in adjacent.Keys)
				{
					if (!visitedVerticies.Contains(vertex))
					{
						var weight = adjacent[vertex];
						var edge = new Edge<t>(currentVertex, vertex, weight);
						if (!availableEdges.ContainsKey(weight))
						{
							availableEdges.Add(weight, new List<Edge<t>>());
						}
						availableEdges[weight].Add(edge);
					}
				}

				//get the edge with the smallest cost
				Edge<t> bestEdge = availableEdges[availableEdges.Keys.First()].First();
				g.AddEdge(bestEdge);
				visitedVerticies.Add(bestEdge.Second);
				currentVertex = bestEdge.Second;
				availableEdges[bestEdge.Weight].Remove(bestEdge);
				if(availableEdges[bestEdge.Weight].Count == 0)
				{
					availableEdges.Remove(bestEdge.Weight);
				}
			}

			return g;
		}
	}
}
