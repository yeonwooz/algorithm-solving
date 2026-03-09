<Query Kind="Program">
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll</Reference>
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll</Reference>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

// BFS
class Answer
{
	static void Main()
	{
		var (board, ry, rx, by, bx) = MakeBoard();
		var N = board.GetLength(0);
		var M = board.GetLength(1);
			
		var answer = BFS(ry, rx, by, bx, N, M, board);
		Console.Write(answer);
	}

	static (char[,], int ry, int rx, int by, int bx) MakeBoard()
	{
		var firstLine = Console.ReadLine().Split();
		var rowParsed = int.TryParse(firstLine[0], out int N);
		if (!rowParsed)
		{
			throw new Exception("Input is wrong");
		}		

		var colParsed = int.TryParse(firstLine[1], out int M);
		if (!colParsed)
		{
			throw new Exception("Input is wrong");
		}
		
		char[,] board = new char[N, M];

		int ry = 0, rx = 0, by = 0, bx = 0;

		for (int i = 0; i < N; i++)
		{
			string line = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				char c = line[j];
				// 보드의 칸을 만들어준다. 단 R, B 는 보드의 지형이 아니므로 채워준다.
				
				if (c == 'R')
				{
					ry = i;
					rx = j;
					board[i,j] = '.'; 
				}
				else if (c == 'B')
				{
					by = i;
					bx = j;
					board[i,j] = '.';
				}
				else 
				{
					board[i,j] = c;
				}
			}
		}
		return (board, ry, rx, by, bx);
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
		// 벽이면 stop, hole이면 즉시 종료, dist 증가 
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
			
			if (board[y, x] == 'O')
			{
				return (y, x, dist, true);
			}
		}
		
		return (y, x, dist, false);
	}

	static int BFS(int ry, int rx, int by, int bx, int N, int M, char[,] board)
	{
		Queue<State> q = new Queue<State>();
		q.Enqueue(new State(ry, rx, by, bx, 0));
		bool[,,,] visited = new bool[N, M, N, M];
		visited[ry, rx, by, bx] = true;

		int[] dy = { -1, 1, 0, 0 };
		int[] dx = { 0, 0, -1, 1 };
		
		while (q.Count > 0)
		{
			var cur = q.Dequeue();
			
			if (cur.Depth >= 10) continue;
			
			for (int d = 0; d < 4; d++) // 4방향으로 기울이기
			{
				var r = Roll(cur.Ry, cur.Rx, dy[d], dx[d], board);
				var b = Roll(cur.By, cur.Bx, dy[d], dx[d], board);
				
				if (b.hole) continue;
				if (r.hole) return cur.Depth + 1; // 다음 이동지점이 hole
				
				int nry = r.y, nrx = r.x;
				int nby = b.y, nbx = b.x;
				
				if (nry == nby  && nrx == nbx)
				{
					//두 구슬이 동시에 굴러가면 같은 칸에 멈출 수 없으므로, 뒤에서 온 구슬을 한칸 뒤로 보냄 
					if (r.dist > b.dist) // 빨간 구슬이 더 많이 굴러왔다. (뒤에서 출발했다)
					{
						nry -= dy[d];
						nrx -= dx[d];
					} 
					else
					{
						nby -= dy[d];
						nbx -= dx[d];
					}
				}
				
				if (visited[nry, nrx, nby, nbx]) continue;
				visited[nry, nrx, nby, nbx] = true;
				q.Enqueue(new State(nry, nrx, nby, nbx, cur.Depth + 1));
			}
		}
		return -1;
	}
}
