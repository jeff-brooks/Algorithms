using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ValidParentheses;

namespace ValidParenthesesTest
{
	[TestClass]
	public class UnitTest
	{
		[TestMethod]
		public void TestMethod()
		{
			IList<string> expectedFalse = new List<string>();
			//uneven pairs
			expectedFalse.Add("(){}[");
			expectedFalse.Add("{}[](");
			expectedFalse.Add("[](){");

			//close before open
			expectedFalse.Add(")(");
			expectedFalse.Add("}{");
			expectedFalse.Add("][");
			

			//more close than open
			expectedFalse.Add("())");
			expectedFalse.Add("[]]");
			expectedFalse.Add("{}}");

			//more open than close
			expectedFalse.Add("(()");
			expectedFalse.Add("[[]");
			expectedFalse.Add("{{}");

			//wrong order
			expectedFalse.Add("([)]");
			expectedFalse.Add("[{]}");
			expectedFalse.Add("{(})");

			//not enough characters to close
			expectedFalse.Add("((((((((((()");

			foreach (string s in expectedFalse)
			{
				Assert.IsFalse(StackSolution.IsValid(s));
			}

			IList<string> expectedTrue = new List<string>();
			//un-nested
			expectedTrue.Add("()");
			expectedTrue.Add("{}[]()");

			//nested
			expectedTrue.Add("({[]})");
			expectedTrue.Add("{[]()}");
			expectedTrue.Add("{{([[[]()][]{}])[]}}");

			foreach (string s in expectedTrue)
			{
				Assert.IsTrue(StackSolution.IsValid(s));
			}
		}
	}
}
