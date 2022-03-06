namespace TrappingRainWater
{
	public static class Soln1
	{
		/// <summary>
		/// Build the model of a fully filled elevation map.
		/// Subtract from the original map to arrive at how much water was added.
		/// </summary>
		/// <param name="height"></param>
		/// <returns></returns>
		public static int Trap(int[] height)
		{
			if (height.Length < 3)
			{
				return 0;
			}

			//iterate the array.
			//if the next value is higher, add value to target array and keep moving
			//if the next value is lower, move forward to see if a higher number is encountered
			//	keep track of the highest value found while looking forward

			int[] filledMap = new int[height.Length];

			for (int i = 0; i <= height.Length - 2; i++)
			{
				if (height[i] <= height[i + 1])
				{
					filledMap[i] = height[i];
					if (i == height.Length - 2)
					{
						filledMap[i + 1] = height[i + 1];
					}
					continue;
				}
				else
				{
					if(i == height.Length - 2)
					{
						filledMap[i + 1] = height[i + 1];
					}
				}
				
				filledMap[i] = height[i];

				//next column is smaller. look forward until reaching the end, or finding a column of equal or greater value.
				var result = SearchForward(i, height, filledMap);
				if(result != -1)
				{
					i = result - 1;
				}
			}

			int waterCount = 0;

			for(int l = 0; l < height.Length; l++)
			{
				waterCount += filledMap[l] - height[l];
			}

			return waterCount;
		}

		/// <summary>
		/// what exactly should be returned here?
		/// </summary>
		/// <param name="startingIndex"></param>
		/// <param name="map"></param>
		/// <param name="target"></param>
		/// <returns></returns>
		private static int SearchForward(int startingIndex, int[] map, int[] target)
		{
			if (map.Length < startingIndex + 2)
			{
				return -1;
			}

			var targetValue = map[startingIndex];
			var indexOfMaxFound = startingIndex + 1;
			var maxFound = map[startingIndex + 1];

			for (int j = startingIndex + 2; j < map.Length; j++)
			{
				if (map[j] >= targetValue)
				{
					fill(target, targetValue, startingIndex + 1, j);
					target[j] = map[j];
					return j; //return the index to continue with from
				}
				if(map[j] > maxFound)
				{
					maxFound = map[j];
					indexOfMaxFound = j;
				}
			}

			if(indexOfMaxFound > startingIndex + 1)
			{
				//did not find a value to match the target, but did find a section to fill in.
				fill(target, maxFound, startingIndex + 1, indexOfMaxFound);
				return indexOfMaxFound;
			}

			return -1;
		}

		private static void fill(int[] target, int value, int start, int stop)
		{
			for(int k = start; k <= stop; k++)
			{
				target[k] = value;
			}
		}
	}
}
