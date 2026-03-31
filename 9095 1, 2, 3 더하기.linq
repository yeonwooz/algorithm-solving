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
		var memo = new Dictionary<int, int>();
		return F(n);
		int F(int x)
		{
			if (x == 0) return 1;
			if (x < 0) return 0;

			if (memo.ContainsKey(x)) return memo[x];

			memo[x] = F(x - 1) + F(x - 2) + F(x - 3);
			return memo[x];
		}
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
