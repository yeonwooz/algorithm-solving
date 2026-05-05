<Query Kind="Program">
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.dll</Reference>
  <Reference Relative="..\..\..\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll">&lt;UserProfile&gt;\projects\Tsl_server\Source\src\Bro\BroServ\bin\Debug\net9.0\Helical.All.dll</Reference>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	var l1 = BuildList(new[] { 9 });
	var l2 = BuildList(new[] { 1,9,9,9,9,9,9,9,9,9 });

	var solution = new Solution();
	var result = solution.AddTwoNumbers(l1, l2);

	PrintList(result);
}

ListNode BuildList(int[] values)
{
	ListNode dummy = new ListNode(0);
	ListNode current = dummy;

	foreach (var v in values)
	{
		current.next = new ListNode(v);
		current = current.next;
	}

	return dummy.next;
}

void PrintList(ListNode node)
{
	var list = new List<int>();

	while (node != null)
	{
		list.Add(node.val);
		node = node.next;
	}

	list.Dump(); // [0,0,0,...] 형태
}

public class ListNode
{
	public int val;
	public ListNode next;

	public ListNode(int val = 0, ListNode next = null)
	{
		this.val = val;
		this.next = next;
	}
}

public class Solution
{	
	public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{
		var digit = 1;
		var num1 = 0;
		while (l1 != null)
		{
			num1 += digit * l1.val;
			l1 = l1.next;
			digit *= 10;
		}

		digit = 1;
		var num2 = 0;
		while (l2 != null)
		{
			num2 += digit * l2.val;
			l2 = l2.next;
			digit *= 10;
		}

		var sum = num1 + num2;

		return BuildFromNumber(sum);
	}

	public ListNode BuildFromNumber(int num)
	{
		if (num == 0) return new ListNode(0);

		ListNode dummy = new ListNode(0);
		ListNode current = dummy;

		while (num > 0)
		{
			int digit = num % 10;
			current.next = new ListNode(digit);
			current = current.next;

			num /= 10;
		}

		return dummy.next;
	}
}