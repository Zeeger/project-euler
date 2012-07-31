/*
n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Problems
{
	class Problem00020 : ISolveProblems 
	{
		public void Solve()
		{
			double currentIteration = 100;

			double  factorial100 = 1;
			double  sumOfDigitsInFactorial100 = 0;

			do
			{
				factorial100 *= currentIteration;

				Console.WriteLine(factorial100 + " " + factorial100.ToString());

				currentIteration--;
			} while (currentIteration > 0);

			Console.WriteLine(factorial100);
		}
	}
}
