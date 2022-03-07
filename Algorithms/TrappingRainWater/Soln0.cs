namespace TrappingRainWater
{
	public static class Soln0
	{
		/// <summary>
		/// Water fills fills when the block is bounded on both left and right sides, and from the bottom up.
		/// This approach examines the input array one row at a time.
		/// Finding the leftmost and right most bounds that could collect water,
		/// adding the empty spaces between those bounds to the return value,
		/// and then "sinking" the input array one row at a time, until there are no more rows left to sink.
		/// 
		/// it works, but is not performant.
		/// 
		/// ideas to boost peformance:
		///		- find a way to take a bigger "bite" out of the input array - use a bigger "row size"
		///		- "trim" the input array of leading and trailing zero's, by keeping track of the first and last 
		///		block index outside of the loop. 
		///		UPDATE: Done - didnt make an appreciable difference in performance.
		///		
		///		- a more performant overall approach, of course. 
		///		UPDATE: one such approach found and implemented
		/// </summary>
		/// <param name="height"></param>
		/// <returns></returns>
		public static int Trap(int[] height)
		{
			if (height.Length < 3)
			{
				return 0;
			}
			bool rowHasBlock;
			int rainWaterBlocks = 0;
			int startIndex = 0;
			int stopIndex = height.Length - 1;
			do
			{
				if(stopIndex - startIndex < 2)
				{
					rowHasBlock = false;
					continue;
				}
				bool rowHasLeftBlock = false;
				for (int i = startIndex; i < height.Length; i++)
				{
					if (height[i] > 0)
					{
						rowHasLeftBlock = true;
						startIndex = i;
						break ;
					}
				}

				bool rowHasRightBlock = false;
				for (int j = stopIndex; j > startIndex; j--)
				{
					if (height[j] > 0)
					{
						rowHasRightBlock = true;
						stopIndex = j;
						break;
					}
				}

				rowHasBlock = rowHasLeftBlock && rowHasRightBlock;

				if (rowHasBlock && startIndex < stopIndex && (stopIndex - startIndex) > 1)
				{
					//add up unblocked spaces between left most and right most blocks
					for (int l = startIndex + 1; l < stopIndex; l++)
					{
						if (height[l] == 0)
						{
							rainWaterBlocks++;
						}
					}
				}
				else
				{
					rowHasBlock = false;
				}

				if (rowHasBlock)
				{
					//sink the array down 1 level
					for (int k = 0; k < height.Length; k++)
					{
						if (height[k] > 0)
						{
							height[k]--;
						}
					}
				}

			} while (rowHasBlock);

			return rainWaterBlocks;
		}
	}
}
