using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Common
{
	static class MathFunc
	{
		private static int minFactor = 7;

		public static bool IsPrime(long checkForPrime)
		{
			if(checkForPrime<2)
				return false;

			if (checkForPrime == 2 || checkForPrime == 3 || checkForPrime == 5 || checkForPrime==7)
			{
				return true;
			}

			if ((checkForPrime % 2 == 0) ||
				(checkForPrime % 3 == 0) ||
				(checkForPrime % 5 == 0))
			{ return false; }

			long maxFactor = checkForPrime / minFactor; 

			for (long x = minFactor; x <= maxFactor; x++)
			{
				if (checkForPrime % x == 0)
				{
					return false;
				}
			}

			return true;
		}


		//private static bool IsPrimeQuicker(long checkForPrime)
		//{
		//    if (checkForPrime == 2 || checkForPrime == 3 || checkForPrime == 5)
		//    {
		//        return true;
		//    }

		//    if (
		//                !(checkForPrime % 2 == 0) &&
		//                !(checkForPrime % 3 == 0) &&
		//                !(checkForPrime % 5 == 0)
		//                )
		//    {
		//        if(IsPrimeOver3(checkForPrime))
		//            return true;
		//    }

		//    return false;
		//}

		//private static bool IsPrimeOver3(long checkForPrime)
		//{
		//    long upperEndPrimeCheck = (checkForPrime - (checkForPrime % 2)) / 2;

		//    for (long currentCheck = 3; currentCheck < upperEndPrimeCheck; currentCheck++)
		//    {
		//        if (checkForPrime % currentCheck == 0)
		//        {
		//            return false;
		//        }
		//    }

		//    return true;
		//}
	}
}
