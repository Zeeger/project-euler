using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using csharp_euler.Problems;

namespace csharp_euler
{
	class Program
	{
		
		static void Main(string[] args)
		{
			var problemList = new List<ISolveProblems>();

			bool classInstantiationSuccess = true;
			int problemNumber = 1;

			do
			{
				var className = "csharp_euler.Problems.Problem" + problemNumber.ToString().PadLeft(5, '0');

				ISolveProblems problem = Assembly.GetExecutingAssembly().CreateInstance(className) as ISolveProblems;

				if (problem != null)
				{
					problemList.Add(problem);
				}
				else
				{
					classInstantiationSuccess = false;
				}

				problemNumber++;
			}
			while (classInstantiationSuccess == true);

			//problemList.Add(new Problem00001());
			//problemList.Add(new Problem00002());
			//problemList.Add(new Problem00003()); 
			//problemList.Add(new Problem00004());
			//problemList.Add(Assembly.GetExecutingAssembly().CreateInstance("csharp_euler.Problems.Problem00004") as ISolveProblems);

			Console.WriteLine("Start at problem:");

			var input = Console.ReadLine();

			long startingProblem;

			if (!long.TryParse(input, out startingProblem))
			{
				startingProblem = 1;
			}

			for (long x = 0;x<problemList.ToArray().Length;x++)
			{
				var problem = problemList.ToArray()[x];

				if (x+1 >= startingProblem)
				{

					problem.Solve();

					var problemClassName = problem.GetType().FullName;

					Console.WriteLine("Problem " + problemClassName + " solved. Enter 'Q' to exit.");

					var nextInput = Console.ReadLine();

					if (nextInput.ToLower() == "q")
						break;

					Console.WriteLine();
				}
			}
		}
	}
}
