using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace csharp_euler
{
	class Program
	{
		
		static void Main(string[] args)
		{
			var problemList = new List<ISolveProblems>();

			problemList.Add(new Problem00001());

			foreach (var problem in problemList)
			{
				problem.Solve();

				var problemClassName = problem.GetType().FullName ;

				Console.WriteLine("Problem " + problemClassName + " solved.");

				Console.ReadLine();
			}
		}
	}
}
