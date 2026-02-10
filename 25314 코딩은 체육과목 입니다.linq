<Query Kind="Program">
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll</Reference>
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll</Reference>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

namespace Answer
{
	class Answer
	{
		static void Main()
		{
			var parsed = int.TryParse(Console.ReadLine(), out int num);
			if (!parsed) 
			{
				throw new Exception("Input is not a number");
			}
			
			var str = "";
			for (var i = 0; i < num / 4; i++)
			{
				str += "long ";
			}
			str += "int";
			Console.Write(str);
		}
	}
}