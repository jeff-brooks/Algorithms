using System.Collections.Generic;

namespace DataStructure.Graph
{
	public static class DFS<t>
	{
		private static Dictionary<t, bool> mark;      //keeps track of the visited vertices

		/// <summary>
		/// Traverse the graph beginning at vertex by using depth-first search
		/// </summary>
		/// <param name="vertex"></param>
		public static void Search(t vertex, Graph<t> g)
		{
			mark = new Dictionary<t, bool>();
			Stack<t> stack = new Stack<t>();
			stack.Push(vertex);
			mark.Add(vertex, true);

			t curr = vertex;

			while (stack.Count > 0)
			{
				var u = g.GetAdjacencyListFor(curr);
				bool unvisitedVerticiesExist = false;
				foreach (var v in u.Keys)
				{
					if(!mark.ContainsKey(v))
					{
						unvisitedVerticiesExist = true;
						curr = v;
						break;
					}
				}
				if (!unvisitedVerticiesExist)
				{
					stack.Pop();
					if(stack.Count > 0)
					{
						curr = stack.Peek();
					}
				}
				else
				{
					stack.Push(curr);
					mark.Add(curr, true);
				}
			}
		}
	}
}
