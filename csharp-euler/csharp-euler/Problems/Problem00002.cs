/*
 
 By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
 * find the sum of the even-valued terms.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Problems
{
	class Problem00002 : ISolveProblems 
	{
		private const long sequenceMaxValue = 4000000;

		public void Solve()
		{
			long total = 0;

			long[] fibonacciArray = { 0, 1 };

			do
			{
				Array.Resize(ref fibonacciArray, fibonacciArray.Length + 1);

				fibonacciArray[fibonacciArray.Length - 1] = 
					fibonacciArray[fibonacciArray.Length - 2] + fibonacciArray[fibonacciArray.Length - 3];

				if (fibonacciArray.Last() < sequenceMaxValue
					&& (fibonacciArray.Last() % 2 == 0))
				{
					total += fibonacciArray.Last();
				}

				Console.WriteLine(fibonacciArray.Last());
			}
			while (fibonacciArray.Last() < sequenceMaxValue);

			Console.WriteLine("Answer is " + total);
		}
	}
}
