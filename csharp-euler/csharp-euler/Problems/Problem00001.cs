/*
 Add all the natural numbers below one thousand that are multiples of 3 or 5.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Problems
{
	class Problem00001 : ISolveProblems
	{
		public void Solve()
		{
			long total = 0;

			for (int x = 0; x < 1000; x++)
			{
				//Console.WriteLine(x);

				//Console.WriteLine(x % 3);

				if (x % 3 == 0 || x % 5 == 0)
				{
					total += x;
				}

				//Console.WriteLine(total);
			}

			Console.WriteLine("Answer is " + total);
		}
	}
}
