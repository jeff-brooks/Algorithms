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
		///		
		///		- a more performant overall approach, of course.
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
			do
			{
				rowHasBlock = false;
				//find the leftmost block
				int firstBlockIndex = height.Length;
				for (int i = 0; i < height.Length; i++)
				{
					if (height[i] > 0)
					{
						rowHasBlock = true;
						firstBlockIndex = i;
						break;
					}
				}

				//find the rightmost block
				int lastBlockIndex = 0;
				for (int j = height.Length - 1; j > firstBlockIndex; j--)
				{
					if (height[j] > 0)
					{
						rowHasBlock = true;
						lastBlockIndex = j;
						break;
					}
				}

				if (rowHasBlock && firstBlockIndex < lastBlockIndex && (lastBlockIndex - firstBlockIndex) > 1)
				{
					//add up unblocked spaces between left most and right most blocks
					for (int l = firstBlockIndex + 1; l < lastBlockIndex; l++)
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
