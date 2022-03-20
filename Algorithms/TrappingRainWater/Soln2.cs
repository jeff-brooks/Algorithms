using System;
using System.Collections.Generic;
using System.Text;

namespace TrappingRainWater
{
	public static class Soln2
	{
		public static int Trap(int[] height)
		{
			int leftIndex = 0;
			int rightIndex = height.Length - 1;
			int capturedWaterBlocks = 0;
			int leftMax = 0;
			int rightMax = 0;

			while (leftIndex < rightIndex)
			{
				if(height[leftIndex] < height[rightIndex])
				{
					if(height[leftIndex] >= leftMax)
					{
						leftMax = height[leftIndex];
					}
					else
					{
						capturedWaterBlocks += leftMax - height[leftIndex];
					}
					leftIndex++;
				}
				else
				{
					if(height[rightIndex] >= rightMax)
					{
						rightMax = height[rightIndex];
					}
					else
					{
						capturedWaterBlocks += rightMax - height[rightIndex];
					}
					rightIndex--;
				}
			}

			return capturedWaterBlocks;
		}
	}
}
