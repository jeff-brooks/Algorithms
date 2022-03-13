using System.Collections.Generic;

namespace DataStructure.Graph
{
	public static class BFS<t>
	{
		private static Dictionary<t, bool> mark;	//keeps track of the order that the vertices are visited

		/// <summary>
		/// Traverse the graph beginning at vertex by using breadth-first search
		/// </summary>
		/// <param name="vertex"></param>
		public static void Search(t vertex, Graph<t> g)
		{
			mark = new Dictionary<t, bool>();
			Queue<t> queue = new Queue<t>();
			queue.Enqueue(vertex);

			while (queue.Count > 0)
			{
				t v = queue.Dequeue();

				if (!mark.ContainsKey(v))
				{
					mark.Add(v, true);

					foreach (var w in g.GetAdjacencyListFor(v).Keys)
					{
						if (!mark.ContainsKey(w) && !queue.Contains(w))
						{
							queue.Enqueue(w);
						}
					}
				}
			}
		}
	}
}
