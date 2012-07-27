/*
By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

What is the 10 001st prime number? 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Problems
{
	class Problem00007 : ISolveProblems 
	{
		public void Solve()
		{
			/*
			 Assumptions: Efficiency can be gained by eliminating mod 2, 3, 5.
			 */

			int tenThousandAndFirstPrime = 0;

			int currentPrimeIndex = 6;
			int currentPrimeValue = 13;

			int nextPossiblePrime = 13 + 1;

			do
			{
				if (
					!(nextPossiblePrime % 2 == 0) &&
					!(nextPossiblePrime % 3 == 0) &&
					!(nextPossiblePrime % 5 == 0)
					)
				{
					if (Common.MathFunc.IsPrime(nextPossiblePrime))
					{
						currentPrimeIndex++;
						currentPrimeValue = nextPossiblePrime;
					}
				}

				if (currentPrimeIndex == 10001)
				{
					tenThousandAndFirstPrime = currentPrimeValue;
				}

				nextPossiblePrime++;
			} while (tenThousandAndFirstPrime == 0);

			Console.WriteLine("Ten thousand and first prime is: " + tenThousandAndFirstPrime);
		}
	}
}
