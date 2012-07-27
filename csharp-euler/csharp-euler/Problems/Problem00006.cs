/*
 * The sum of the squares of the first ten natural numbers is,
12 + 22 + ... + 102 = 385

The square of the sum of the first ten natural numbers is,
(1 + 2 + ... + 10)2 = 552 = 3025

Hence the difference between the sum of the squares of the first ten natural numbers and the square of the
 * sum is 3025 − 385 = 2640.

Find the difference between the sum of the squares of the first one hundred natural numbers and the 
 * square of the sum. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Problems
{
	class Problem00006 : ISolveProblems
	{
		/*
		 Definition for natural number:
			Web definitions:	
			the number 1 and any other number obtained by adding 1 to it repeatedly.
		 */

		public void Solve()
		{
			/*Assumption:
			 *	- Efficiency is going to be gained by only looping through the first 100 numbers once
			*/

			double sumOfNaturalNumbers = 0;
			double sumOfSquaresOfNaturalNumbers = 0;

			for (int x = 1; x <= 100; x++)
			{
				sumOfNaturalNumbers += x;

				sumOfSquaresOfNaturalNumbers += (Math.Pow(x, 2));
			}

			Console.WriteLine("Sum is " + sumOfNaturalNumbers + " Sum of squares is " + sumOfSquaresOfNaturalNumbers);

			double squareOfSumOfNaturalNumbers = Math.Pow(sumOfNaturalNumbers, 2);

			Console.WriteLine("Diff between " + squareOfSumOfNaturalNumbers + " and " +
				sumOfSquaresOfNaturalNumbers + " = " +
				Math.Abs(squareOfSumOfNaturalNumbers - sumOfSquaresOfNaturalNumbers));
		}
	}
}
