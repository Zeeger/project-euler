/*
 The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Problems
{
	class Problem00010 : ISolveProblems 
	{
		public void Solve()
		{
			long sumOfPrimesBelowTwoMillion = 2;

			int primeCount = 1;

			DateTime startVal = DateTime.Now;

			for (long x = 3; x < 2000000; x+=2)
			{
				if (Common.MathFunc.IsPrime(x))
				{
					sumOfPrimesBelowTwoMillion += x;

					//Console.WriteLine(sumOfPrimesBelowTwoMillion + " " + x);

					//Console.WriteLine(x);
					
					primeCount++;
				}

				if (primeCount % 10 == 0)
				{
					//Console.ReadLine();
				}

				//if (startVal.AddSeconds(10) < DateTime.Now)
				//{
				//    Console.WriteLine(x + " in 10 seconds");
				//    break; }
			}



			Console.WriteLine("Sum of primes below 2 million: " + sumOfPrimesBelowTwoMillion);
		}
	}
}
