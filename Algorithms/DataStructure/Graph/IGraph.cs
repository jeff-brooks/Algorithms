using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Graph
{
	public interface IGraph<t>
	{
		public IList<t> Verticies { get; }
		public Dictionary<t, int> GetAdjacencyListFor(t v);
		public void AddEdge(t v, t w, int weight);
	}
}
