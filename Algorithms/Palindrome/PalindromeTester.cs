using System;
using System.Text.RegularExpressions;

namespace Palindrome
{
	public static class PalindromeTester
	{
		public static bool FormatAndTestRecursive(string s)
		{
			return IsPalindromeRecursive(Format(s));
		}

		public static bool FormatAndTestIterative(string s)
		{
			return IsPalindromeIterate(Format(s));
		}
		private static bool IsPalindromeIterate(string s)
		{
			for(int i = 0; i < s.Length / 2; i++)
			{
				if(s[i] != s[s.Length - 1 - i])
				{
					return false;
				}
			}
			return true;
		}
		private static bool IsPalindromeRecursive(string s)
		{
			if (s.Length < 2)
			{
				return true;
			}
			if(s.Length == 2)
			{
				if (s[0] == s[1]) { return true; }
				return false;
			}

			string beginningAndEnd = string.Concat(s[0], s[s.Length - 1]);
			string middle = s.Substring(1, s.Length - 2);
			return IsPalindromeRecursive(beginningAndEnd) && IsPalindromeRecursive(middle);
		}

		private static string Format(string s)
		{
			return Regex.Replace(s, "[^a-zA-Z0-9]", String.Empty).ToLower();
		}
	}
}
