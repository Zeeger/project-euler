/*
 
A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

Find the largest palindrome made from the product of two 3-digit numbers.
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Problems
{
	class Problem00004 : ISolveProblems 
	{
		//public void Solve()
		//{
		//    //It's probably most efficient if we find palindromes first, and then mod
		//    //	that by 3-digit numbers to see if there is no remainder. If there isn't
		//    //	check if the dividend is 3 digits

		//    int largest3DigitX3DigitProduct = 999 * 999;

		//    Console.WriteLine("Largest 3 digit * 3 digit product is " + largest3DigitX3DigitProduct);

		//    int lengthOfLargestProduct = largest3DigitX3DigitProduct.ToString().Length;

		//    Console.WriteLine("Length: " + lengthOfLargestProduct);

		//    int extraDigitAfterMod2 = lengthOfLargestProduct % 2;


		//    int maxRequiredPalindromicDigits = (lengthOfLargestProduct - extraDigitAfterMod2) / 2;

		//    Console.WriteLine("Max palindromic digits: " + maxRequiredPalindromicDigits);

		//    //The top end of the loop is going to be the required palindromic characters
		//    int topEndOfLoop = largest3DigitX3DigitProduct.ToString().Substring(0,ma
		//}

		//The below was an initial attempt, but it doesn't work extremely well
		public void Solve()
		{
			int min3DigitValue = 99;

			int largestPalindromeFound = 0;

			for (int x = 999; x > min3DigitValue; x--)
			{

				for (int y = x; y > min3DigitValue; y--)
				{
					int product = x * y;

					//Console.WriteLine("Checking " + product + " (" + x + " * " + y + ")");

					if (product>largestPalindromeFound && IsPalindrome(product.ToString()))
					{
						largestPalindromeFound = product;

						int newMin = 0;
						if (x > y)
						{ newMin = y; }
						else
						{ newMin = x; }

						if (newMin > min3DigitValue)
						{ min3DigitValue = newMin;

						Console.WriteLine("Min updated to " + min3DigitValue + " (" + x + " * " + y + ")");
						//Console.ReadLine();
						}
					}
				}

			}

			if (largestPalindromeFound != 0)
			{
				Console.WriteLine("Largest palindrome is " + largestPalindromeFound);
			}
		}

		public void SolveTry2()
		{
			int x = 999;
			int y = 999;

			bool decrementX = false; // decrement y first, so that we can assume x is always equal or greater

			do
			{
				int product = x*y;

				Console.WriteLine("Examining " + product + " (" + x + " * " + y + ")");

				if (IsPalindrome(product.ToString()))
				{

					Console.WriteLine("Palindrome found! " + product);

					//Now we have a palindrome, but it's really only the minimum value of y
					// x and y are at most 1+-. Now we have to go back and check all numbers <y * x
					//	where x is from 999 to our current x value, decrementing

					for (int newX = 999; newX > x; newX--)
					{
						for (int newY = y; newY > 99; newY--)
						{
							int smartProduct = newX * newY;

							Console.WriteLine("Examining(intelligently) " + smartProduct + " (" + newX + " * " + newY + ")");

							if (smartProduct > product && IsPalindrome(smartProduct.ToString()))
							{
								Console.WriteLine("Smart Palindrome found! " + smartProduct);
								return;
							}
						}
					}


					//If the above loop didn't find anything, then we have done out due dilligence and 
					//	really found the largest palindrome

					Console.WriteLine("Palindrome found! " + product);
					return;
				}

				if (decrementX)
				{
					x--;
					decrementX = false;
				}
				else
				{
					y--;
					decrementX = true;
				}
			} while (x > 99 && y > 99);
		}


		//The below was an initial attempt, but it doesn't work extremely well
		public void SolveTry1()
		{
			for (long x = 999; x > 99; x--)
			{
				long largestPalindrome = 0;

				for (long y = x; y > 99; y--)
				{
					long product = x * y;

					Console.WriteLine("Checking " + product + " (" + x + " * " + y + ")");

					if (IsPalindrome(product.ToString()))
					{
						largestPalindrome = product;
						break;
					}
				}

				if (largestPalindrome != 0)
				{
					Console.WriteLine("Largest palindrome is " + largestPalindrome);
					break;
				}
			}
		}

		private bool IsPalindrome(string input)
		{
			var inputLength = input.Length;

			var examiningLength = inputLength - (inputLength % 2);

			//Example.. In "racecar", we would go from char 0 to char 3
			for(int x=0;x<=(examiningLength/2);x++)
			{
				var earlyChar = input.Substring(x, 1);
				var lateChar = input.Substring(input.Length - (x+1), 1);

				//Console.WriteLine(input + " Does " + earlyChar + " equal " + lateChar + " ?");

				if (!earlyChar.Equals(lateChar))
				{
					return false;
				}
			}

			return true;
		}
	}
}
