using System.Collections.Generic;

namespace NumberOfIslands
{
	public static class Soln0
	{
		public static int NumIslands(char[][] grid)
		{
			int numIslands = 0;
			for (var i = 0; i < grid.Length; i++)
			{
				for (var j = 0; j < grid[0].Length; j++)
				{
					if (grid[i][j] == '1')
					{
						numIslands++;
						FloodBfs(grid, i, j);
					}
				}
			}
			return numIslands;
		}

		private static void FloodDfs(char[][] grid, int iLand, int jLand)
		{

		}

		/// <summary>
		/// transition all land connected to point iLand, jLand in grid to water using breadth-first-search
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="iLand"></param>
		/// <param name="jLand"></param>
		private static void FloodBfs(char[][] grid, int iLand, int jLand)
		{
			var queue = new Queue<Point>();
			queue.Enqueue(new Point(iLand, jLand));
			while (queue.Count > 0)
			{
				Point p = queue.Dequeue();
				if (grid[p.i][p.j] == '1')
				{
					var points = GetNeighbors(p, grid);
					foreach (var point in points)
					{
						if (!queue.Contains(point))
						{
							queue.Enqueue(point);
						}
					}
					grid[p.i][p.j] = '0';
				}
			}
		}

		private static IList<Point> GetNeighbors(Point p, char[][] grid)
		{
			var ret = new List<Point>();
			int startI = p.i == 0 ? p.i : p.i - 1;
			int startJ = p.j == 0 ? p.j : p.j - 1;

			int stopI = p.i == grid.Length - 1 ? p.i : p.i + 1;
			int stopJ = p.j == grid[0].Length - 1 ? p.j : p.j + 1;

			for (var k = startI; k <= stopI; k++)
			{
				if (k != p.i)
				{
					if (grid[k][p.j] == '1')
					{
						ret.Add(new Point(k, p.j));
					}
				}
			}

			for (var l = startJ; l <= stopJ; l++)
			{
				if (l != p.j)
				{
					if (grid[p.i][l] == '1')
					{
						ret.Add(new Point(p.i, l));
					}
				}
			}

			return ret;
		}

		private class Point
		{
			public int i { get; set; }
			public int j { get; set; }

			public Point(int I, int J)
			{
				i = I;
				j = J;
			}
			public override bool Equals(object obj)
			{
				if (this == obj) { return true; }

				var castedPoint = obj as Point;
				if (castedPoint == null) { return false; }
				if (castedPoint.i == this.i && castedPoint.j == this.j) { return true; }

				return false;
			}

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}
		}
	}


}
