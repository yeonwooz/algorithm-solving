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
		var answer = Solve(n, arr);
		Console.Write(answer);
	}

	static int Solve(int n, int[][] arr)
	{
		// a,b -> a는 업무기간, b는 보수. 
		// i 일에 맡는 업무는 i + a <= N+1이어야 함 
		// N일동안 받는 보수의 총합이 최대가 되어야 함
		
		// dp[i]는 i일부터 마지막 날까지 얻을 수 있는 최대 수익	
		int[] dp = new int[n+2];  // 0번째는 버리고 1일부터 n+1일까지 만들어 둠 
		
		
		for (int i = n; i >= 1; i--)
		{
			var day = i;
			var a = arr[i-1][0]; // i일에 잡힌 업무 기간
			var b = arr[i-1][1]; // i일에 잡힌 업무 보수 
			if (day + a > n+1)
			{
				dp[i] = dp[i+1]; // i일에 일을 못하면 i+1일까지의 보수가 최대
			}
			else 
			{
				var pay = b + dp[i+a]; // i일에 일을 하면 i+a일의 보수를 받고, 그 사이에 일을 못할 거고, i일 보수를 받음
				dp[i] = Math.Max(pay, dp[i+1]);
			}							
		}
		
		return dp[1];
	}

	static (int, int[][]) GetInputs()
	{
		string line;
		while (string.IsNullOrWhiteSpace(line = Console.ReadLine())) {}
		int N = int.Parse(line.Trim()); 
		
		int[][] arr = new int[N][];
		for (int i = 0; i < N; i++)
		{
			while (string.IsNullOrWhiteSpace(line = Console.ReadLine())) {}
			arr[i] = line.Trim().Split().Select(int.Parse).ToArray();
		}
				
		return (N, arr);
	}
}