using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

namespace ArabicToRomanNumbers
{
	public class Program
	{
		public static void Main(string[] args)
		{
			while (true)
			{
				if (!PromptInput(out int arabic))
				{
					continue;
				}
				else
				{
					Console.WriteLine($"The Roman number is {Convert(arabic)}");
					break;
				}
			}
		}

		public static bool PromptInput(out int arabicNumber)
		{
			Console.WriteLine("Please enter a number between 1 and 3999: ");
			string arabic = Console.ReadLine();

			if (!int.TryParse(arabic, out arabicNumber))
			{
				Console.WriteLine("Please enter numbers!");
				return false;
			}

			if (arabicNumber <= 0 || arabicNumber > 3999)
			{
				Console.WriteLine("Please enter a number between 1 and 3999!");
				return false;
			}

			return true;
		}

		public static string Convert(int arabicNumber)
		{
			int i = 10;
			List<string> romanNumberList = new List<string>();
			while (arabicNumber > i / 10)
			{
				int currentDigit = arabicNumber % i - arabicNumber % (i / 10);
				string currentRoman = ParseNumber(currentDigit);
				romanNumberList.Add(currentRoman);
				i *= 10;
			}
			romanNumberList.Reverse();
			var romanNumber = new StringBuilder();
			foreach (var s in romanNumberList)
			{
				romanNumber.Append(s);
			}
			return romanNumber.ToString();
		}

		public static string ParseNumber(int arabic)
		{
			string[] thousands = { "", "M", "MM", "MMM" };
			string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
			string[] tenths = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
			string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

			string roman;
			if (arabic > 0 && arabic < 10)
			{
				roman = ones[arabic % 10];
			}
			else if (arabic > 9 && arabic < 100)
			{
				roman = tenths[(arabic / 10) % 10];
			}
			else if (arabic > 99 && arabic < 1000)
			{
				roman = hundreds[(arabic / 100) % 10];
			}
			else if (arabic > 999 && arabic < 4000)
			{
				roman = thousands[(arabic / 1000) % 10];
			}
			else
			{
				roman = "";
			}

			return roman;
		}

	}
}
