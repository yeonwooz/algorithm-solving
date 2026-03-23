<Query Kind="Program">
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll</Reference>
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll</Reference>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	var (n, nums) = getInputs();	
	n.Dump();
	nums.Dump();
}

private (int, int[]) getInputs()
{
	var input = Console.ReadLine();	
	var n = int.Parse(input);
	var i = 0;		
	var nums = new List<int>() {};
	
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

// You can define other methods, fields, classes and namespaces here
