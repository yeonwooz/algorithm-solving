<Query Kind="Program">
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll</Reference>
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll</Reference>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

public class Answer
{	
	static void Main()
	{
		var parsed = int.TryParse(Console.ReadLine(), out int n);
		if (!parsed)
		{
			throw new Exception("Input is not a number");
		}
		
		var a = 1;  // 이전
		var b = 1;  // 현재
		
		for (int i = 3; i <= n; i++)
		{
			int c = a + b;
			a = b;
			b = c;
		}

		var answer = $"{b} {n-2}";
		Console.Write(answer);
	}
}