//Find the largest prime factor of a composite number.

//Additional info:
//The prime factors of 13195 are 5, 7, 13 and 29.

//What is the largest prime factor of the number 600851475143 ?

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Problems
{
	class Problem00003 : ISolveProblems 
	{
		long _loopIterations = 0;

		public void Solve()
		{
			Console.WriteLine("Enter a number for calculation: ");

			var input = Console.ReadLine();

			long subject = 0;
			long largestPrimeFactor = 0;
			long[] progressingLowendFactors = { };
			long upperEndFactorCheck = 0;

			_loopIterations = 0;

			//Bounce out if the number isn't valid
			if (!long.TryParse(input, out subject))
				return;

			if (subject < 2)
				return;

			upperEndFactorCheck = subject - 1;

			for (long checkForFactor = 2; checkForFactor < upperEndFactorCheck; checkForFactor++)
			{
				_loopIterations++;

				if (subject % checkForFactor == 0)
				{
					Console.WriteLine(checkForFactor + " and " + (subject / checkForFactor) + " are factors.");

					upperEndFactorCheck = subject / checkForFactor;

					//Check for prime of the current upper end factor
					//	(only if we'd be changing the found number
					if (Common.MathFunc.IsPrime(upperEndFactorCheck))
					{
						largestPrimeFactor = upperEndFactorCheck;

						//found - get the heck out
						break;
					}

					//If the largest prime factor has not been found yet,
					//	add the lower companion factor to an array will will be processed in reverse later
					Array.Resize(ref progressingLowendFactors, progressingLowendFactors.Length + 1);
					progressingLowendFactors[progressingLowendFactors.Length - 1] = checkForFactor;
				}

				
			}

			//If the largest prime factor is still zero, loop in reverse through the progressing low end factors 
			//	and check for primes
			if (largestPrimeFactor == 0)
			{
				foreach (long lowendFactor in progressingLowendFactors.Reverse())
				{
					if (Common.MathFunc.IsPrime(lowendFactor))
					{
						largestPrimeFactor = lowendFactor;
						break;
					}
				}
			}

			if (largestPrimeFactor != 0)
			{
				Console.WriteLine("The largest prime factor is " + largestPrimeFactor);
			}
			else
			{
				Console.WriteLine(subject + " has no prime factors.");
			}

			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("Loop iterations: " + _loopIterations);


			//This works, but takes too long when we get up in the billions

			//for (long x = subject-1; x > 1; x--)
			//{
			//    //Console.WriteLine("Testing " + x);

			//    bool isPrime = true;

			//    //If the subject is evenly divisible by the current number
			//    if (subject % x == 0)
			//    {
			//        Console.WriteLine(x + " is a factor");

			//        //Test if that number is prime
			//        for (long n = x - 1; n > 1; n--)
			//        {
			//            //Console.WriteLine(n + " " + x % n);

			//            if (x % n == 0)
			//            {
			//                isPrime = false;
			//                break;
			//            }
			//        }

			//        if (isPrime)
			//        {
			//            Console.WriteLine(x + " is the largest prime factor of " + subject);
			//            break;
			//        }
			//        else
			//        { Console.WriteLine(" But is not prime. "); }
			//    }
			//}
		}

		
	}
}
