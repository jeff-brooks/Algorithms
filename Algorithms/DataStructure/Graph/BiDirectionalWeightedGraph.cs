using System.Collections.Generic;

namespace DataStructure.Graph
{
	public class BiDirectionalWeightedGraph<t> : IGraph<t>
	{
		private Dictionary<t, Dictionary<t, int>> AdjacencyList { get; }
		public IList<Edge<t>> Edges { get; }
		public IList<t> Verticies { get; }

		public BiDirectionalWeightedGraph()
		{
			AdjacencyList = new Dictionary<t, Dictionary<t, int>>();
			Edges = new List<Edge<t>>();
			Verticies = new List<t>();
		}

		/// <summary>
		/// get the weight of the edge between verticies
		/// </summary>
		/// <param name="v"></param>
		/// <param name="w"></param>
		/// <returns></returns>
		public int EdgeWeight(t v, t w)
		{
			return AdjacencyList[v][w];
		}

		/// <summary>
		/// adds an edge from v to w with weight weight to the graph
		/// </summary>
		/// <param name="v"></param>
		/// <param name="w"></param>
		/// <param name="weight"></param>
		public void AddEdge(t v, t w, int weight)
		{
			if (!AdjacencyList.ContainsKey(v))
			{
				AdjacencyList.Add(v, new Dictionary<t, int>());
			}
			AdjacencyList[v].Add(w, weight);

			//if (!adjacencyList.ContainsKey(w))
			//{
			//	adjacencyList.Add(w, new SortedDictionary<t, int>());
			//}
			//adjacencyList[w].Add(v, weight);

			var edge = new Edge<t>(v, w, weight);
			Edges.Add(edge);
			AddVertices(v);
			AddVertices(w);
		}

		private void AddVertices(t vertex)
		{
			if (Verticies.Contains(vertex)) { return; }
			Verticies.Add(vertex);
		}

		/// <summary>
		/// add edge to graph
		/// </summary>
		/// <param name="e"></param>
		public void AddEdge(Edge<t> e)
		{
			t v = e.First;
			t w = e.Second;
			int weight = e.Weight;
			AddEdge(v, w, weight);
		}

		/// <summary>
		/// remove edge from graph
		/// </summary>
		/// <param name="e"></param>
		public void RemoveEdge(Edge<t> e)
		{
			t v = e.First;
			t w = e.Second;

			AdjacencyList[v].Remove(w);
			AdjacencyList[w].Remove(v);

			Edges.Remove(e);
		}

		public Dictionary<t, int> GetAdjacencyListFor(t v)
		{
			return AdjacencyList[v];
		}
	}
}
