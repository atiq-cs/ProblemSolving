/***************************************************************************
* Problem Name: The Coin Change Problem
* Problem URL : https://www.hackerrank.com/challenges/coin-change
* Date        : Jan 26, 2016
* Complexity  : O(nm) Time
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : 
*               The goal is to find number of ways coins can sum up to n. 
*               By trying the regular DP concept, I was able to
*               write the algo/solution that can compute number of ways
*               However, because the coin iteration loop was inner
*               it included solutions where order of coins mattered or
*               position of the coins mattered. To give an example,
*               consider 3 coins are given to make sum 4 like following,
*               
*               4 3
*               1 2 3
*               solutions are considered:
*                1 1 1 1
*                1 1 2
*                1 2 1
*                2 1 1
*                1 3
*                2 2
*                3 1
*               which gives us total ways = 7
*               
*               To include only the unique solutions all we need to do is put
*               the coin loop as outer
*               
*               Lessons:
*                sorting coins not necessary
*                
*               Refs:
*               This one uses 2D Array
*               https://en.wikipedia.org/wiki/Change-making_problem
*               Similarly,
*               http://www.algorithmist.com/index.php/Coin_Change
*                
* Ack         : Mak               
* meta        : tag-dynamic-programming
***************************************************************************/
using System;

class CoinChange {
  int n;
  int m;
  int[] coins;
  public void Run() {
    // Take input
    string[] tokens = Console.ReadLine().Split(' ');
    n = Convert.ToInt32(tokens[0]);
    m = Convert.ToInt32(tokens[1]);

    coins = new int[m];
    tokens = Console.ReadLine().Split(' ');
    for (int i = 0; i < m; i++)
      coins[i] = Convert.ToInt32(tokens[i]);

    // Print Result
    Console.WriteLine(CountWays());
  }

  // compute number of ways
  long CountWays() {
    long[] w = new long[n+1];
    w[0] = 1;
    Array.Clear(w, 1, n);

    for (int i = 0; i < m; i++)
      for (int j = 1; j <= n; j++) {
        if (j >= coins[i])
          w[j] += w[j - coins[i]];
      }
    return w[n];
  }
}

class HK_Solution {
  static void Main(String[] args) {
    CoinChange Demo = new CoinChange();
    Demo.Run();
  }
}
