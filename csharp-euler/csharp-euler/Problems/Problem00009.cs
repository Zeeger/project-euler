/*A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
a2 + b2 = c2

For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Problems
{
	class Problem00009 : ISolveProblems 
	{
		public void Solve()
		{
			SolveUltraStupid();
		}

		public void SolveUltraStupid()
		{
			/*
			 *		a^2 + b^2 = c^2
			 *		a + b + c = 1000
			 *		
			 *		a < b < c
			 *		
			 *		
			 */

			//	a + (a+1) + (a+2) = 1000
			//	3a = 997
			for (int a = 1; (3 * a) < 997; a++)
			{

				//	1 + b + (b+1) <= 1000
				//  2b <= 998
				for (int b = a + 1; (2 * b) <= 998; b++)
				{

					//	1 + 2 + c <= 1000
					//	c <= 997
					for (int c = b + 1; c <= 997; c++)
					{
						if (a + b + c == 1000)
						{ 
							//Check for pythagorean
							if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
							{
								Console.WriteLine("Found!! " + a + " " + b + " " + c + "Product: " + (a * b * c));
								return;
							}
						}
					}

				}
			}
		}

		//This is possibly the wrong way to thing about it
		public void Solve1stTry()
		{
			/*
			 Assumptions:
			 *  - To make this efficient, we need to make some rules about a, b, and c.
			 *  0 < a < 997
			 *  1 < b < 997
			 *  2 < c < 997 <- because 1 + 2 + 997 = 1000
			 *  
			 * That's an ok rule about the lower end, but the high end needs improvement
			 *	For example: 500 + 501 + 502 = 1503
			 *	1000/3 = 333 (and some), making a = 332, b=333, c=334.
			 *		332 + 333 + 334 = 999, so a's max value is 333.
			 */

			throw new NotImplementedException();
		}
	}
}
