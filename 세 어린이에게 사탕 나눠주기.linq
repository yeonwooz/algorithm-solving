<Query Kind="Program">
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll</Reference>
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll</Reference>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

/*
	N(N≤30)개의 사탕을 세 명의 어린이에게 가능한 공평하게 나눠 주려고 한다.
	공평함의 기준은 받는 사탕의 총 무게가 가장 무거운 어린이와 가장 가벼운 어린이 간의 차이로 합시다. 이 차이가 최소가 되어야 가장 공평하다.
	각 사탕의 무게는 모두 20 이하의 정수이다. 가능한 최소 차이는 얼마일까?
	
	1. 각 어린이가 받은 사탕 무게 총합을 a,b,c로 두자.
	=> 그러면 구해야 하는 것은: max(a,b,c) - min(a,b,c)
	
	2. 사탕 하나를 볼 때 선택지는 몇 개일까?
	=> 사탕 하나는 3명의 어린이게 갈 수 있다. 그래서 사탕이 N개라면, N개를 다 나누어주는 경우의 수는 3^N 개. 205조 
	
	3. 완전탐색 형태를 먼저 떠올려보기 사탕을 배열로 늘어놓고 하나씩 나눠준다고 보면, index는 사탕의 순서
	dfs(index, a, b, c)
	
	4. 종료 조건 생각하기 
	index === N이 되면 모든 사탕을 다 배정한 상태
	=> if(index === N) return max(a,b,c) - min(a,b,c) 해서 현재의 최소값과 비교해서 갱신
	
	5. 최적화 방법 고민
	(10, 7, 3)과 (7, 10, 3)은 같다. 
	=> 세 합의 분포가 같은 것들은 중복제거.
	
	6. 메모이제이션 
	그 앞 순서의 index 에서 이미 같은 분포가 나왔다면, 캐싱해두고 쓴다.
	
	7. 더 최적화 (처리할 사탕의 개수 줄이기)
	index 번째 에서는, 앞의 사탕들을 이미 다 나누어줬고 총 무게 합이 이미 정해진 상태.
	=> a + b + c = prefixSum[index]	
       c = prefixSum[index] - a - b	
	 	
	8. DP 로 전환
	Q. i 번째 사탕까까지 처리했을 때 만들 수 있는 (a,b)조합을 관리할 수 있을까?
	사탕을 A 에게 주면, (a + w, b)
	사탕을 B에게 주면, (a, b + w)
	사탕을 C에게 주면, (a, b)
	c = S - a - b
	
	9. 각 사탕 무게가 20 이하라는 조건
	=> 메모리 감당 가능할 듯함. 합 기반 DP로 풀어볼 만한 규모	
*/


void Main()
{	
	var input = Console.ReadLine();
	input.Dump();
}

