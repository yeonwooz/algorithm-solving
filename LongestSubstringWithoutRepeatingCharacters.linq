<Query Kind="Program">
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll</Reference>
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll</Reference>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	var solution = new Solution();

	solution.LengthOfLongestSubstring("abcabcbb").Dump("abcabcbb"); // 3 ("abc")
	solution.LengthOfLongestSubstring("bbbbb").Dump("bbbbb");       // 1 ("b")
	solution.LengthOfLongestSubstring("pwwkew").Dump("pwwkew");     // 3 ("wke")
	solution.LengthOfLongestSubstring("abba").Dump("abba");         // 2 (left가 뒤로 안 가는지 확인)
	solution.LengthOfLongestSubstring("").Dump("(empty)");          // 0
	solution.LengthOfLongestSubstring(" ").Dump("(space)");         // 1
}

public class Solution
{
	public int LengthOfLongestSubstring(string s)
	{
		Dictionary<char, int> dict = new Dictionary<char, int>();
		var left = 0;
		var longest = 0;

		for (var i = 0; i < s.Length; i++)
		{
			var c = s[i];
			if (dict.TryGetValue(c, out int prev) && prev >= left)
			{
				left = prev + 1;
			}

			dict[c] = i;
			longest = Math.Max(longest, i - left + 1);
		}

		return longest;
	}
}
