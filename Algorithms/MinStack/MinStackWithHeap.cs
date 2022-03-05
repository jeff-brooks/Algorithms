using System;
using System.Collections.Generic;

namespace MinStack
{
	public class MinStackWithHeap
	{
		private Stack<int> stack;
		private int[] heap;
		private int heapSize;
		public MinStackWithHeap()
		{
			stack = new Stack<int>();
			heap = new int[4];
			heapSize = 0;
		}

		public void Push(int val)
		{
			stack.Push(val);

			//check if array needs to expand
			if (heap.Length == heapSize)
			{
				int[] temp = new int[heapSize * 2];
				Array.Copy(heap, temp, heapSize);
				heap = temp;
			}

			//add new item to the bottom of the heap, then swim upwards
			heap[heapSize++] = val;
			HeapSwim();
		}

		public void Pop()
		{
			//Remove from stack
			int valtoRemove = stack.Pop();

			//Find the heap index for this value
			int searchIndex = Array.IndexOf(heap, valtoRemove);

			if (searchIndex == -1)
			{
				//This should not happen. Items in the stack and on the heap are expected to align.
				throw new Exception("Could not find element from stack in heap.");
			}

			//Remove this value, replace it with the a value from the bottom of the heap
			heap[searchIndex] = heap[heapSize-- - 1];

			//Swim the element down to it's rightful place in the heap.
			HeapSink(searchIndex);
		}

		public int Top()
		{
			//return most recently added item
			return stack.Peek();
		}

		public int GetMin()
		{
			return heap[0];
		}

		private void HeapSink(int startingIndex)
		{
			//End swim if the given index has no children.
			if (heapSize < startingIndex * 2 + 1)
			{
				return;
			}

			int value = heap[startingIndex];

			//Compare value to children to see if further heap adjustments are needed.
			//Begin on the left side, also check the right side if it exists.
			int leftChildIndex = startingIndex * 2 + 1;
			int leftChildValue = heap[leftChildIndex];

			int smallestChildValue = leftChildValue;
			int smallestChildIndex = leftChildIndex;

			if(startingIndex * 2 + 2 < heapSize)
			{
				int rightChildIndex = startingIndex * 2 + 2;
				int rightChildValue = heap[rightChildIndex];

				if(rightChildValue < leftChildValue)
				{
					smallestChildValue = rightChildValue;
					smallestChildIndex = rightChildIndex;
				}
			}

			if (value > smallestChildValue)
			{
				heap[startingIndex] = smallestChildValue;
				heap[smallestChildIndex] = value;
				HeapSink(smallestChildIndex);
				return;
			}
		}

		private void HeapSwim()
		{
			int childIndex = heapSize - 1;
			while (childIndex > 0)
			{
				int parentIndex = (childIndex - 1) / 2;
				int childValue = heap[childIndex];
				int parentValue = heap[parentIndex];

				if (childValue < parentValue)
				{
					heap[parentIndex] = childValue;
					heap[childIndex] = parentValue;
				}

				childIndex = parentIndex;
			}
		}
	}
}
