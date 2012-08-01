using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace csharp_euler.Common
{
	public static class FileIO<T>
	{
		public static T[] ReadFileIntoArray(string filePath)
		{
			var fsStream = File.OpenRead(filePath);

			//fsStream.rea

			return new T[2];
		}
	}

	public class ReadInputInto2DArray<T>
	{
		public T[][] Read(char delimiter)
		{
			return new T[2][];
		}
	}
}
