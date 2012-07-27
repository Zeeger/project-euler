/*
2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Problems
{
	class Problem00005 : ISolveProblems 
	{

		public void Solve()
		{
			/*Assumptions
				- What is the smallest increment?
			 *		Theory: 380. (19 * 20) -- 
			 *			Update: Theory confirmed.
			 * 
			 *	- When we have a number divisible by 20, that number is inherently divisible by 
			 *		1, 2, 4, 5, 10	<- we don't need to test these numbers
			 *		
			 *	- If 380 is true, then we don't need to test either 20 or 19.
			*/

			int minimumIncrement = 380;
			int minimumEvenlyDivisible = 0;

			int currentCheck = minimumIncrement;

			do
			{
				bool currentFailed=false;

				// 2 is a minimum assumption
				for (int x = 18; x > 2; x--)
				{
					if (currentCheck % x != 0)
					{
						currentFailed = true;
						break;
					}

					//Assumption skip numbers (factors of 20)
					if (x == 10 || x == 5 || x == 4)
					{
						x--;
					}
				}

				if (!currentFailed)
				{
					minimumEvenlyDivisible = currentCheck;
				}

				currentCheck += minimumIncrement;
			} while (minimumEvenlyDivisible==0);

			Console.WriteLine("Minimum evenly divisible: " + minimumEvenlyDivisible);
		}
	}
}
