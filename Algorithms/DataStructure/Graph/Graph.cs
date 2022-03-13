using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Graph
{
	public class Graph<t>
	{
		private Dictionary<t, SortedDictionary<t, int>> adjacencyList;
		public IList<Edge<t>> Edges { get; }
		public IList<t> Verticies { get; }

		public Graph()
		{
			adjacencyList = new Dictionary<t, SortedDictionary<t, int>>();
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
			return adjacencyList[v][w];
		}

		/// <summary>
		/// adds an edge from v to w with weight weight to the graph
		/// </summary>
		/// <param name="v"></param>
		/// <param name="w"></param>
		/// <param name="weight"></param>
		public void AddEdge(t v, t w, int weight)
		{
			if (!adjacencyList.ContainsKey(v))
			{
				adjacencyList.Add(v, new SortedDictionary<t, int>());
			}
			adjacencyList[v].Add(w, weight);

			if (!adjacencyList.ContainsKey(w))
			{
				adjacencyList.Add(w, new SortedDictionary<t, int>());
			}
			adjacencyList[w].Add(v, weight);

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

		//public bool HasEdge(Edge<t> e)
		//{
		//	return Edges.Contains(e);
		//	//return adjacencyList.ContainsKey(e.First) && adjacencyList[e.First].ContainsKey(e.Second);
		//}

		//public bool HasEdge(t v, t w, int weight)
		//{
		//	return Edges.Any(e => e.First.Equals(v) && e.Second.Equals(w) && e.Weight.Equals(weight));
		//	//return adjacencyList.ContainsKey(v) && adjacencyList[v].ContainsKey(w) && adjacencyList[v][w] == weight;
		//}

		/// <summary>
		/// remove edge from graph
		/// </summary>
		/// <param name="e"></param>
		public void RemoveEdge(Edge<t> e)
		{
			t v = e.First;
			t w = e.Second;

			adjacencyList[v].Remove(w);
			adjacencyList[w].Remove(v);

			Edges.Remove(e);

			//CheckForVertexRemoval(v);
			//CheckForVertexRemoval(w);
		}

		public void RemoveVertex(t vertex)
		{
			//delete edges originating from vertex
			var originEdges = Edges.Where(e => e.First.Equals(vertex));


			//delete edges terminating at vertex
			var terminatingEdges = Edges.Where(e => e.Second.Equals(vertex));

			var edgesToDelete = originEdges.Union(terminatingEdges).ToList();

			foreach (var edge in edgesToDelete)
			{
				RemoveEdge(edge);
			}

			//remove vertex
			Verticies.Remove(vertex);
		}

		//private void CheckForVertexRemoval(t vertex)
		//{
		//	if(adjacencyList[vertex].Keys.Count == 0)
		//	{
		//		Verticies.Remove(vertex);
		//		adjacencyList.Remove(vertex);
		//	}
		//}

		/// <summary>
		/// find the edge connecting v and w
		/// </summary>
		/// <param name="v"></param>
		/// <param name="w"></param>
		/// <returns></returns>
		public Edge<t> FindEdge(t v, t w)
		{
			int weight = adjacencyList[v][w];
			return new Edge<t>(v, w, weight);
		}

		//return adjacency list for given vertex
		public SortedDictionary<t, int> GetAdjacencyListFor(t v)
		{
			return adjacencyList[v];
		}
	}
}
