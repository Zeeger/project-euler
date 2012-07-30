using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using csharp_euler.Problems;
using System.IO;

namespace csharp_euler
{
	class Program
	{

		static void Main(string[] args)
		{
			var problemList = new List<ISolveProblems>();

			//LoadProblemsConsecutively(ref problemList);

			Dictionary<int, ISolveProblems> problemDictionary = LoadProblemsByNamespace();

			string input = "";

			do
			{
				PrintKeysOfDictionary(problemDictionary);

				Console.WriteLine("Type a problem number to solve, C to clear screen, or Q to quit.");

				input = Console.ReadLine();

				if (input.ToUpper() == "C")
				{
					Console.Clear();
					continue;
				}

				int problemNumber = -1;

				if (int.TryParse(input, out problemNumber))
				{
					try
					{
						problemDictionary[problemNumber].Solve();
					}
					catch (KeyNotFoundException kex)
					{
						Console.WriteLine("That problem was not loaded. Try again...");
					}
				}

			} while (input.ToUpper() != "Q");
		}

		private static void PrintKeysOfDictionary(Dictionary<int, ISolveProblems> problemDictionary)
		{
			string keyString = "";

			foreach (var key in problemDictionary)
			{
				keyString += key.Key + ", ";
			}

			keyString = keyString.Substring(0, keyString.Length - 2);

			Console.WriteLine(keyString);
		}

		private static Dictionary<int,ISolveProblems> LoadProblemsByNamespace()
		 {
			string @namespace = "csharp_euler.Problems";

			var problemDictionary = new Dictionary<int,ISolveProblems>();

			var className = from typeName in Assembly.GetExecutingAssembly().GetTypes()
							where typeName.IsClass && typeName.Namespace == @namespace
							orderby typeName.Name
							select typeName;

			//var problemsLoaded = "";

			foreach (var type in className)
			{
				var currentProblem = InstantiateProblemClass(type.FullName);

				if (currentProblem != null)
				{
					//problemList.Add(currentProblem);

					var classNumberString = type.Name.Substring(type.Name.Length - 5, 5);

					var classNumber = int.Parse(classNumberString);

					problemDictionary.Add(classNumber,currentProblem);

					//problemsLoaded += classNumber + ", ";
					//Console.WriteLine(classNumber + ", ");
				}

			} 
			
			//problemsLoaded = problemsLoaded.Substring(0, problemsLoaded.Length - 2);

			//Console.WriteLine(problemsLoaded);

			return problemDictionary;
		}

		private static void LoadProblemsByFile(ref List<ISolveProblems> problemList)
		{
			string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

			string directoryPath = Path.GetDirectoryName(fullPath);

			string[] problemClassFiles = Directory.GetFiles(directoryPath + @"\Problems\", @"Problem*.cs");

			foreach (var name in problemClassFiles)
			{
				Console.WriteLine(name);

			}
		}

		private static ISolveProblems InstantiateProblemClass(string className)
		{
			ISolveProblems problem = Assembly.GetExecutingAssembly().CreateInstance(className) as ISolveProblems;

			return problem;
		}

		private static void LoadProblemsConsecutively(ref List<ISolveProblems> problemList)
		{
			bool classInstantiationSuccess = true;
			int problemNumber = 1;

			do
			{
				var className = "csharp_euler.Problems.Problem" + problemNumber.ToString().PadLeft(5, '0');

				ISolveProblems problem = InstantiateProblemClass(className);

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
		}
	}
}