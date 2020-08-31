using NUnit.Framework;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArabicToRoman
{
	[TestClass]
	public class UnitTest1
	{
		[TestCase()]
		public void CorrectParse(int arabicNumber)
		{
			var number = Program.ParseNumber(arabicNumber);
		}
	}
}
