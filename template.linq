<Query Kind="Program">
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll</Reference>
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll</Reference>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		var (n, nums) = getInputs();
		for (int i = 0; i < n; i++)
		{
			Console.WriteLine(solve(nums[i]));
		}
	}

	static int solve(int n)
	{
		return 1;
	}

	static (int, int[]) getInputs()
	{
		var input = Console.ReadLine();
		var n = int.Parse(input);
		var i = 0;
		var nums = new List<int>() { };

		while (i < n)
		{
			input = Console.ReadLine();
			if (input == "")
				throw new Exception("input is empty");

			var num = int.Parse(input);
			nums.Add(num);
			i++;
		}
		return (n, nums.ToArray());
	}
}
