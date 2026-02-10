<Query Kind="Program">
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll</Reference>
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll</Reference>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

class Answer
{
	static void Main()
	{
		// BFS
		bool[,,,,] visited = new bool[N, M, N, M];

	}
	
	struct State
	{
		public int Ry, Rx, By, Bx, Depth;
		public State(int ry, int rx, int by, int bx, int depth)
		{
			Ry = ry;
			Rx = rx;
			By = by;
			Bx = bx;
			Depth = depth;
		}
	}
	
	static (int y, int x, int dist, bool hole) Roll (int y, int x, int dy, int dx, char[,] board)
	{
		int dist = 0;
		
		while (true)
		{
			int ny = y + dy;
			int nx = x + dx;
			
			if (board[ny, nx] == '#') 
			{
				break;
			}
			
			y = ny;
			x = nx;
			dist++;
			
			if (board[ny, nx] == 'O')
			{
				return (y, x, dist, true);
			}
		}
		
		return (y, x, dist, false);
	}
}
