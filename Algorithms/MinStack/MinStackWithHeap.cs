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

			if (heap.Length == heapSize)
			{
				int[] temp = new int[heapSize * 2];
				Array.Copy(heap, temp, heapSize);
				heap = temp;
			}

			//add new item to the bottom of the heap, then swim
			heap[heapSize++] = val;
			HeapSwim();
		}

		public void Pop()
		{
			//remove from stack
			int valtoRemove = stack.Pop();

			//find the heap index for this value
			int searchIndex = Array.IndexOf(heap, valtoRemove);

			if (searchIndex == -1)
			{
				throw new Exception("Could not find element from stack in heap.");
			}

			//remove this value, replace it with the largest value in the heap
			heap[searchIndex] = heap[heapSize-- - 1];

			//swim the smallest element down
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
			//end swim if there are no children
			if (heapSize < startingIndex * 2 + 1)
			{
				return;
			}

			int value = heap[startingIndex];

			//compare to children
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
