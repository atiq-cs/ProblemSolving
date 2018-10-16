/***************************************************************************
* Title : Recursion: Davis' Staircase
* URL   : https://www.hackerrank.com/challenges/ctci-recursive-staircase
* Occasn: CTCI
* Date  : 2018-05-26
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : In today's meetup at DEN
*   How many ways - means DP
* Rel   : https://leetcode.com/problems/climbing-stairs
* meta  : tag-algo-dp, tag-recursion
***************************************************************************/
using System;

class HK_Solution {
  static int CountStairWays(int n) {
    int fibA = 1;   // 0
    int fibB = 1;   // 1
    int fibC = 2;   // 2
    for (int i=2; i<n; i++) {
      int temp = fibC; fibC += fibB + fibA; fibA = fibB;  fibB = temp;
    }
    return n==1?fibB:fibC;
  }

  static void Main(String[] args) {
    // Take input
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      int n = int.Parse(Console.ReadLine());
      Console.WriteLine(CountStairWays(n));
    }
  }
}

/*
1 - 1
 0 -> 1
2 - 1 + 1
 0 -> 1 -> 2
 0 -> 2
 
3 - 
 0 -> 1 -> 3 = 1
      2 -> 3 = 2
 0 -> 3      = 1
 -------------------
 Total       = 4

numWays[n] = numWays[n-3] + numWays[n-2] + numWays[n-1]
            = 1 + 1 + 2
            
5 = 1 + 1 + 2 + 4 + 7 + 13
*/
