using ArabicToRomanNumbers;
using NUnit.Framework;

namespace ArabicToRoman.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase(5, "V")]
		[TestCase(100, "C")]
		[TestCase(20, "XX")]
		[TestCase(50, "L")]
		[TestCase(3000, "MMM")]
		[TestCase(3, "III")]
		public void Correct_Parse(int arabicNumber, string expected)
		{
			string romanNumber = Program.ParseNumber(arabicNumber);
			Assert.AreEqual(expected, romanNumber);
		}

		[TestCase(1009, "MIX")]
		[TestCase(105, "CV")]
		[TestCase(15, "XV")]
		[TestCase(49, "XLIX")]
		[TestCase(94, "XCIV")]
		[TestCase(559, "DLIX")]
		[TestCase(1904, "MCMIV")]
		[TestCase(1559, "MDLIX")]
		[TestCase(1444, "MCDXLIV")]
		[TestCase(599, "DXCIX")]
		[TestCase(1999, "MCMXCIX")]
		public void Should_Convert_Correctly(int input, string expected)
		{
			var romanNumber = Program.Convert(input);
			var romanNumberString = romanNumber.ToString();
			Assert.AreEqual(expected, romanNumberString);
		}
	}
}