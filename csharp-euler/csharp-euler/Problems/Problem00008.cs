/*
 * Find the greatest product of five consecutive digits in the 1000-digit number.
 73167176531330624919225119674426574742355349194934
96983520312774506326239578318016984801869478851843
85861560789112949495459501737958331952853208805511
12540698747158523863050715693290963295227443043557
66896648950445244523161731856403098711121722383113
62229893423380308135336276614282806444486645238749
30358907296290491560440772390713810515859307960866
70172427121883998797908792274921901699720888093776
65727333001053367881220235421809751254540594752243
52584907711670556013604839586446706324415722155397
53697817977846174064955149290862569321978468622482
83972241375657056057490261407972968652414535100474
82166370484403199890008895243450658541227588666881
16427171479924442928230863465674813919123162824586
17866458359124566529476545682848912883142607690042
24219022671055626321111109370544217506941658960408
07198403850962455444362981230987879927244284909188
84580156166097919133875499200524063689912560717606
05886116467109405077541002256983155200055935729725
71636269561882670428252483600823257530420752963450
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Problems
{
	class Problem00008 : ISolveProblems 
	{

		public void Solve()
		{
			var thousandDigitNumber =
				"73167176531330624919225119674426574742355349194934" +
				"96983520312774506326239578318016984801869478851843" +
				"85861560789112949495459501737958331952853208805511" +
				"12540698747158523863050715693290963295227443043557" +
				"66896648950445244523161731856403098711121722383113" +
				"62229893423380308135336276614282806444486645238749" +
				"30358907296290491560440772390713810515859307960866" +
				"70172427121883998797908792274921901699720888093776" +
				"65727333001053367881220235421809751254540594752243" +
				"52584907711670556013604839586446706324415722155397" +
				"53697817977846174064955149290862569321978468622482" +
				"83972241375657056057490261407972968652414535100474" +
				"82166370484403199890008895243450658541227588666881" +
				"16427171479924442928230863465674813919123162824586" +
				"17866458359124566529476545682848912883142607690042" +
				"24219022671055626321111109370544217506941658960408" +
				"07198403850962455444362981230987879927244284909188" +
				"84580156166097919133875499200524063689912560717606" +
				"05886116467109405077541002256983155200055935729725" +
				"71636269561882670428252483600823257530420752963450";

			/*
			Assumptions: 
			 *	- First goal is to eliminate the sequences with zeroes as this will produce no product at all
					- Maybe loop through each and substring the sections with zeroes as the delimiter.
			 */

			//var completelyParsedForZeroes = false;
			//var startingChar = 0;
			var shrinkingString = thousandDigitNumber;

			string[] consecutiveDigitArray = { };
			string[] consecutiveDigitArrayFives = { };

			int largestProduct = 0;

			do
			{
				var choppedString = ChopOffUpToIndexOf(ref shrinkingString, '0');

				if (choppedString.Length >= 5)
				{
					for (int x = 0; x <= choppedString.Length - 5; x++)
					{
						var fiver = choppedString.Substring(x, 5);

						var tempProduct = ProductOfDigitsInString(fiver);

						Console.WriteLine(tempProduct);

						if (tempProduct > largestProduct)
						{ largestProduct = tempProduct; }

						Array.Resize(ref consecutiveDigitArrayFives, consecutiveDigitArrayFives.Length + 1);
						consecutiveDigitArrayFives[consecutiveDigitArrayFives.Length - 1] = fiver;
					}

					//Array.Resize(ref consecutiveDigitArray, consecutiveDigitArray.Length + 1);
					//consecutiveDigitArray[consecutiveDigitArray.Length - 1] = choppedString;
				}
			} while (shrinkingString.Length>0);

			Console.WriteLine("Starting a print. ");
			foreach (var element in consecutiveDigitArrayFives)
			{
				//Console.WriteLine(element);
			}

			Console.WriteLine("largest product of a fiver: " + largestProduct);

		}

		private string ChopOffUpToIndexOf(ref string shrinkingString, char indexOfChar)
		{
			var distanceToFirstIndexOfChar = shrinkingString.IndexOf(indexOfChar);

			if (distanceToFirstIndexOfChar < 0)
			{ distanceToFirstIndexOfChar = shrinkingString.Length - 1; }

			var stringUpToIndexOfChar = shrinkingString.Substring(0, distanceToFirstIndexOfChar);

			shrinkingString = shrinkingString.Substring(distanceToFirstIndexOfChar + 1);

			return stringUpToIndexOfChar;
		}

		private int ProductOfDigitsInString(string input)
		{
			int product = 1;

			for(int x=0;x<input.Length;x++)
			{
				product*= int.Parse(input.Substring(x, 1));
			}

			return product;
		}
	}
}
