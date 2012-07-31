/*
The following iterative sequence is defined for the set of positive integers:

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:
13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1

It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_euler.Problems
{
    class Problem00014: ISolveProblems
    {
        public void Solve()
        {
            //Going to start by writing the rules

            int numberOfTermsInSequence = 0;

            //do
            //{
            // in numberOfTermsInSequence = GetCollatzCount();
            //}while();

        }

        private int GetCollatzCount(int startingInteger)
        {
            int countOfTerms = 0 ;

            int currentTerm = startingInteger;
            do
            {
                if (currentTerm % 2 == 1)
                {
                    currentTerm *= 3;
                    currentTerm++;
                }
                else
                {
                    currentTerm /= 2;
                }

                countOfTerms++;
            } while (currentTerm != 1);

            return countOfTerms;
        }
    }
}
