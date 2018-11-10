/***************************************************************************************************
* Title : Equal
* URL   : https://www.hackerrank.com/challenges/equal
* Date  : 2017-09-21
* Comp  : O(n) for n numbers in the array
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
*   Addition to all other numbers instead of one means to substract
*   from that number to reach a similar goal.
*   Consider the example,
*   2 2 3 7
*   Making it 3 3 3 8 is equivalent to,
*   2 2 2 7
*   On next step making it 8 8 8 8 is equiv to,
*   2 2 2 2
*   
*   Idea is to reduce every number from the array with a target.
*   Target is Min or Min-1 or Min-2
*   
*   Anything below Min-2 is not required. Why?
*   Reason: min, min-1, min-2 are sufficient to get minimnal
*   solution (minimal number of moves)
*   A, if the number is 'min' then we do not need a move (reducing
*   chocolate number) at all.
*   if the number is min+1 then using target 'min' and change of 1
*   chocolate will lead to minimal/optimal solution.
*   If the number is min+2 then it can be reached to target using 2
*   if the number is min+3 it will be made to the target min-2 and
*   using 5
*   
* ref   : https://www.hackerrank.com/challenges/equal/forum (baran_jana's comment approx 1 year ago)
* meta  : tag-algo-dp
***************************************************************************************************/
using System;
using System.Linq;

class HK_Solution {
  // DP if we call choosing min among 3 is called DP
  static int GetMinMovesDP(int[] a) {
    // avoid 'Linq' if slow for online judge
    int min = a.Min();
    // get the min# moves among making target as min, min-1, min-2
    return Math.Min(Math.Min(GetMoveCount(a, min), GetMoveCount(a, min-1)),
      GetMoveCount(a, min-2));
  }

  static int GetMoveCount(int[] a, int target) {
    int move_count = 0;
    for (int i = 0; i < a.Length; i++)
      move_count += GetMoveCount(a[i], target);
    return move_count;
  }

  static int GetMoveCount(int n, int t) {
    n -= t;
    // number of changes with 5
    int count = n / 5; n %= 5;
    // number of changes with 2
    count += n / 2;
    // add number of changes with 1
    return count + n % 2;
  }

  static void Main(String[] args) {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      int.Parse(Console.ReadLine());    // discard N for now
      string[] tokens = Console.ReadLine().Split();
      int[] a = Array.ConvertAll(tokens, int.Parse); // is this faster?
      Console.WriteLine(GetMinMovesDP(a));
    }
  }
}

/*
Sample input:
3
3
1 5 5
4
2 2 3 7
6
2 5 5 5 5 5
*/
