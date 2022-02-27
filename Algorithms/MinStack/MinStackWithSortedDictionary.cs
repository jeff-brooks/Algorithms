using System.Collections.Generic;
using System.Linq;

namespace MinStack
{
	/// <summary>
	/// Implement a stack that supports push, pop, top, and retrieving the minimum element in constant time, as described in the problem.txt file.
	/// 
	/// High-level design:
	/// Use the composition design to add additional functionality to the Stack data structure. 
	/// A SortedDictionary object will be used for the purpose of accessing the minimum element of the stack in constant time
	/// </summary>
	public class MinStackWithSortedDictionary
	{
		private Stack<int> stack;

		/// <summary>
		/// This dictionary will store the stack value as the dictionary key, and a count of the number of times 
		/// the value appears in the stack as the dictonary value.
		/// </summary>
		private SortedDictionary<int, int> valueDictionary;

		public MinStackWithSortedDictionary()
		{
			stack = new Stack<int>();
			valueDictionary = new SortedDictionary<int, int>();
		}

		public void Push(int val)
		{
			stack.Push(val);

			if (valueDictionary.ContainsKey(val))
			{
				valueDictionary[val]++;
				return;
			}

			valueDictionary.Add(val, 1);
		}

		public void Pop()
		{
			//remove from stack
			int valtoRemove = stack.Pop();

			//if the removed value is in the stack more than once, just decrement the value in the dictionary.
			//otherwise, remove the key from the dictionary
			if (valueDictionary[valtoRemove] > 1)
			{
				valueDictionary[valtoRemove]--;
				return;
			}
			valueDictionary.Remove(valtoRemove);
		}

		public int Top()
		{
			//return most recently added item
			return stack.Peek();
		}

		public int GetMin()
		{
			//return smallest value left on the stack
			return valueDictionary.Keys.First();
		}
	}
}
