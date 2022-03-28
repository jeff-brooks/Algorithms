using System;
using System.Collections.Generic;

namespace Sort
{
	public static class SortAlgorithms<T> where T : IComparable<T>
	{
		/// <summary>
		/// Runtime complexity: O(n^2). 
		/// Will require O(n^2) comparisions, but only O(n) data moves.
		/// </summary>
		/// <param name="collection"></param>
		public static void SelectionSort(IList<T> collection) 
		{
			for(var i = collection.Count - 1; i >= 0; i--)
			{
				T largest = collection[0];
				int largestIndex = 0;
				for(var j = i; j >= 0; j--)
				{
					if (collection[j].CompareTo(largest) > 0)
					{
						largest = collection[j];
						largestIndex = j;
					}
				}
				T temp = collection[i];
				collection[i] = collection[largestIndex];
				collection[largestIndex] = temp;
			}

			return;
		}

		/// <summary>
		/// Runtime complexity: O(n^2)
		/// Will require O(n^2) comparisions, and possibily O(n^2) data moves
		/// </summary>
		/// <param name="collection"></param>
		public static void BubbleSort(IList<T> collection)
		{
			for(int i = collection.Count - 1; i >= 0; i--)
			{
				bool hasBubble = false;
				for (int j = 1; j <= i; j++)
				{
					if(collection[j - 1].CompareTo(collection[j]) > 0)
					{
						hasBubble = true;
						T temp = collection[j];
						collection[j] = collection[j - 1];
						collection[j - 1] = temp;
					}
				}
				if(!hasBubble)
				{
					break;
				}
			}
		}

		/// <summary>
		/// Runtime complexity: O(n^2)
		/// comparisons: O(n^2), data moves: O(n^2)
		/// </summary>
		/// <param name="collection"></param>
		public static void InsertionSort(IList<T> collection)
		{
			for(int unsorted = 1; unsorted < collection.Count; unsorted++)
			{
				T itemToInsert = collection[unsorted];
				int insertAt = unsorted;
				while(insertAt > 0 && collection[insertAt - 1].CompareTo(itemToInsert) > 0)
				{
					collection[insertAt] = collection[insertAt - 1];
					insertAt--;
				}

				collection[insertAt] = itemToInsert;
			}
		}

		#region Merge Sort
		/// <summary>
		/// Runtime complexity: O(n log n)
		/// </summary>
		/// <param name="collection"></param>
		public static void MergeSort(IList<T> collection)
		{
			MergeSortRecursion(collection, 0, collection.Count - 1);
		}

		private static void MergeSortRecursion(IList<T> collection, int first, int last)
		{
			if(first < last)
			{
				int mid = (first + last) / 2;
				MergeSortRecursion(collection, first, mid);
				MergeSortRecursion(collection, mid + 1, last);
				Merge(collection, first, mid, last);
			}
		}

		private static void Merge(IList<T> collection, int first, int mid, int last)
		{
			int maxSize = collection.Count;
			IList<T> tempCollection = new T[maxSize];

			int first1 = first;
			int last1 = mid;
			int first2 = mid + 1;
			int last2 = last;
			int index = first1;
			while((first1 <= last1) && (first2 <= last2))
			{
				if(collection[first1].CompareTo(collection[first2]) < 0)
				{
					tempCollection[index] = collection[first1];
					first1++;
				}
				else
				{
					tempCollection[index] = collection[first2];
					first2++;
				}
				index++;
			}

			while(first1 <= last1)
			{
				tempCollection[index] = collection[first1];
				first1++;
				index++;
			}

			while(first2 <= last2)
			{
				tempCollection[index] = collection[first2];
				first2++;
				index++;
			}

			for(int i = first; i <= last; ++i)
			{
				collection[i] = tempCollection[i];
			}
		}
		#endregion

		#region Quick Sort
		/// <summary>
		/// Chooses a pivot for quicksort's partition algorithm and swaps it with the first item in the array
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="first"></param>
		/// <param name="last"></param>
		private static void ChoosePivot(IList<T> collection, int first, int last)
		{
			int pivotIndex = (last + first) / 2;
			T pivotItem = collection[pivotIndex];

			collection[pivotIndex] = collection[first];
			collection[first] = pivotItem;
		}


		private static int Partition(IList<T> collection, int first, int last)
		{
			T tempSwapItem;
			ChoosePivot(collection, first, last);
			T pivot = collection[first];

			int lastS1 = first;
			for(int firstUnknown = first + 1; firstUnknown <= last; ++firstUnknown)
			{
				if(collection[firstUnknown].CompareTo(pivot) < 0)
				{
					++lastS1;
					tempSwapItem = collection[firstUnknown];
					collection[firstUnknown] = collection[lastS1];
					collection[lastS1] = tempSwapItem;
				}
			}

			tempSwapItem = collection[first];
			collection[first] = collection[lastS1];
			collection[lastS1] = tempSwapItem;
			return lastS1;
		}

		private static void QuickSortRecursive(IList<T> collection, int first, int last)
		{
			int pivotIndex;

			if(first < last)
			{
				pivotIndex = Partition(collection, first, last);

				QuickSortRecursive(collection, first, pivotIndex - 1);
				QuickSortRecursive(collection, pivotIndex + 1, last);
			}
		}

		public static void QuickSort(IList<T> collection)
		{
			QuickSortRecursive(collection, 0, collection.Count - 1);
		}

		#endregion

		//public static void QuickSort(IList<T> collection)
		//{
		//	QuickSortRecursion(collection, 0, collection.Count - 1);
		//}

		//private static void QuickSortRecursion(IList<T> collection, int low, int high)
		//{
		//	if(collection[low].CompareTo(collection[high]) < 0)
		//	{
		//		int partition = Partition(collection, low, high);
		//		QuickSortRecursion(collection, low, partition);
		//		QuickSortRecursion(collection, partition + 1, high);
		//	}
		//}

		//private static int Partition(IList<T> collection, int low, int high)
		//{
		//	T pivot = collection[(high + low) / 2];
		//	int leftIndex = low - 1;
		//	int rightIndex = high + 1;


		//}
	}
}
