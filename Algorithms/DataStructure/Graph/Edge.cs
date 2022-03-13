using System;
using System.Collections.Generic;
using System.Text;
using DataStructure;

namespace DataStructure.Graph
{
	public class Edge<t>
	{
		public readonly t First; // { get; private set; }
		public readonly t Second; // { get; private set; }
		public readonly int Weight; // { get; set; } //weight of the edge

		public Edge(t first, t second, int weight)
		{
			First = first;
			Second = second;
			this.Weight = weight;
		}
	}
}
