using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Common
{
	static class MathFunc
	{
		public static bool IsPrime(long checkForPrime)
		{
			long upperEndPrimeCheck = checkForPrime - 1;
			for (long currentCheck = 2; currentCheck < upperEndPrimeCheck; currentCheck++)
			{
				if (checkForPrime % currentCheck == 0)
				{
					return false;
				}
			}

			return true;
		}
	}
}
