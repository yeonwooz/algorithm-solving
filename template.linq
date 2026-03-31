<Query Kind="Program">
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll</Reference>
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll</Reference>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
	{
		var (n, arr) = GetInputs();
		arr.Dump();
	}

	static int Solve(int n)
	{
		return 1;
	}

	static (int, int[][]) GetInputs()
	{
		string line;
		while (string.IsNullOrWhiteSpace(line = Console.ReadLine())) { }
		int N = int.Parse(line.Trim());

		int[][] arr = new int[N][];
		for (int i = 0; i < N; i++)
		{
			while (string.IsNullOrWhiteSpace(line = Console.ReadLine())) { }
			arr[i] = line.Trim().Split().Select(int.Parse).ToArray();
		}

		return (N, arr);
	}
}
