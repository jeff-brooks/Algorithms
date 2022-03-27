using DataStructure.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphApplications
{
	public class Dijkstra<t> where t : struct
	{
		private IGraph<t> graph;
		private Dictionary<t, Dictionary<t, int>> matrix;
		public Dijkstra(IGraph<t> g)
		{
			graph = g;
			matrix = new Dictionary<t, Dictionary<t, int>>();
			BuildMatrix(graph);
		}
		public int GetSmallestDistanceBetween(t startingNode, t destinationNode)
		{
			return matrix[startingNode][destinationNode];
		}

		private void BuildMatrix(IGraph<t> g)
		{
			//initialize matrix with info from adjacency list
			foreach(var vertex in g.Verticies)
			{
				matrix.Add(vertex, new Dictionary<t, int>());
				matrix[vertex][vertex] = 0;
				var adj = g.GetAdjacencyListFor(vertex);
				foreach(var vertex2 in g.Verticies)
				{
					if (vertex.Equals(vertex2)) { continue; }
					if (adj.ContainsKey(vertex2)) 
					{ 
						matrix[vertex][vertex2] = adj[vertex2]; 
						continue; 
					}
					matrix[vertex][vertex2] = int.MaxValue;
				}
			}

			foreach(var key in matrix.Keys)
			{
				var vertexSet = new List<t>() { key };
				var unVisited = matrix.Keys.ToList();
				while (unVisited.Count > 0)
				{
					var v = ClosestUnvisitedVertex(key, unVisited);
					if(v == null)
					{
						//remaining verticies are unreachable
						break;
					}
					vertexSet.Add(v.Value);
					unVisited.Remove(v.Value);

					var vAdj = graph.GetAdjacencyListFor(v.Value);
					foreach(var u in vAdj.Keys)
					{
						if(matrix[key][u] > matrix[key][v.Value] + matrix[v.Value][u])
						{
							matrix[key][u] = matrix[key][v.Value] + matrix[v.Value][u];
						}
					}
				}
			}
		}

		private t? ClosestUnvisitedVertex(t startingVertex, IList<t> unvisitedVerticies) 
		{
			t? next = null;
			int min = int.MaxValue;
			foreach(var vertex in unvisitedVerticies)
			{
				if(matrix[startingVertex][vertex] < min)
				{
					min = matrix[startingVertex][vertex];
					next = vertex;
				}
			}

			return next;
		}
	}
}
