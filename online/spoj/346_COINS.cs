/***************************************************************************
* Title       : COINS - Bytelandian gold coins
* URL         : http://www.spoj.com/problems/COINS/
* Occasion    : tutorial
* Date        : Sept 20 2017
* Complexity  : O(1)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Input limit is 1e9
*               Saving all of those in array is not practical
*               Shows how to read till End of Line
*   bytelandian ref, https://www.quora.com/What-is-the-idea-behind-the-
*   Bytelandian-gold-coins-question-on-CodeChef
*   A perfect dynamic programming problem to solve with Memoization
* meta        : tag-algo-dp, tag-recursion, tag-memoization
***************************************************************************/
using System;
using System.Collections.Generic;

public class SPOJSolution
{
  static Dictionary<ulong, ulong> coin_dict;
  // Use recursion with Memoization
  static ulong GetMaxCoins(ulong n) {
    if (n < 12)
      return n;
    if (coin_dict.ContainsKey(n))
      return coin_dict[n];
    return coin_dict[n] = Math.Max(GetMaxCoins(n/2) + GetMaxCoins(n / 3) + GetMaxCoins(n / 4), n);
  }

  public static void Main() {
    coin_dict = new Dictionary<ulong, ulong>();
    string line;
    while (!string.IsNullOrEmpty(line = Console.ReadLine())) {
      ulong n = ulong.Parse(line);
      Console.WriteLine(GetMaxCoins(n));
    }
  }
}

/*
* On Console - Std Input Ctrl + Z is EOF

12
6 + 4 + 3

6
3 + 2 + 1

14
7 + 4 + 3

15
7 + 5 + 3

16
8 + 5 + 4

1000 000 000

looks like a good problem to practice memoization

if (n < 12)
  return n;
 dp[n] if key n does not exist
 dp[n] already exists, return result
  save dp[n] if key n does not exist

dp[n] = Math.Max(n, dp[n/2] + dp[n/3] + dp[n/4]);
return dp[n];
*/
