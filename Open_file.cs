using System;
using System.Collections.Generic;
using System.IO;

namespace Open_f
{
	class Open
	{
		public void Open_file(string filename)
		{
			string[] readText = File.ReadAllLines(@filename);
			foreach (string s in readText)
			{
				Console.WriteLine(s);
			}
		}
	}
}