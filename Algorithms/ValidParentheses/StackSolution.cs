using System.Collections.Generic;
using System;

namespace ValidParentheses
{
	/// <summary>
	/// Determine if a string contains valid parentheses, as defined by Problem.txt, by using a stack data structure.
	/// 
	/// High-level design:
	/// Read the characters of the input string one at a time.
	/// If the character is an opening parentheses character, add it to a stack.
	/// If the character is a closing parentheses character, pop from the stack and check if the comparision is valid.
	/// characters
	/// </summary>
	public static class StackSolution
	{
		private static readonly char[] openChars = new char[3] { '(', '{', '[' };
		private static readonly char[] closeChars = new char[] { ')', '}', ']' };

		public static bool IsValid(string s)
		{
			//a string with an odd number of characters can not form matching pairs.
			if (s.Length % 2 == 1)
			{
				return false;
			}
			
			Stack<char> opened = new Stack<char>();
			bool matchesFound = false;

			for (int i = 0; i < s.Length; i++)
			{
				if(s.Length - i < opened.Count)
				{
					//not enough characters to close all open characters, return early.
					return false;
				}

				char c = s[i];

				switch (c)
				{
					case '(':
					case '{':
					case '[':
						opened.Push(c);
						continue;
					case ')':
					case '}':
					case ']':
						if(opened.Count == 0)
						{
							return false;
						}
						char left = opened.Pop();

						//perform comparison
						int leftCharIndex = Array.IndexOf(openChars, left);
						int rightCharIndex = Array.IndexOf(closeChars, c);

						if(leftCharIndex == rightCharIndex && leftCharIndex > -1)
						{
							matchesFound = true;
							continue;
						}
						return false;
				}
			}
			
			return matchesFound && opened.Count == 0;
		}
	}
}
