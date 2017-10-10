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
*               
* meta        : tag-dp, tag-dynamic-programming
***************************************************************************/
using System;
using System.Collections.Generic;

public class Demo {
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
 */
