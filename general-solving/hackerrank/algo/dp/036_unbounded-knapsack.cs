/***************************************************************************
* Title : Knapsack
* URL   : https://www.hackerrank.com/challenges/unbounded-knapsack
* Date  : 2018-08-19
* Author: Atiq Rahman
* Comp  : O(nk), O(k)
* Status: Accepted
* Notes : This is unbounded knapsack
*   Hence, our inner loop starts from 1 to T 
* meta  : tag-medium, tag-dp, tag-knapsack
***************************************************************************/
using System;

public class KnapsackUtil {
  private int FindClosestSum(int n, int T, int[] values) {
    int max = 0;
    bool[] dp = new bool[T + 1]; dp[0] = true;

    foreach (var value in values)
      for (int w = 1; w <= T; w++)
        if (dp[w] == false && w-value>=0 && dp[w - value]) {
          dp[w] = true;
          if (w == T) return T;
          max = Math.Max(max, w);
        }
    return max;
  }

  public void Run() {
    int t = int.Parse(Console.ReadLine());
    while(t-- >0) { 
      string[] tokens = Console.ReadLine().Split();
      int n = int.Parse(tokens[0]);
      int k = int.Parse(tokens[1]);
      tokens = Console.ReadLine().Split();
      int[] items = Array.ConvertAll(tokens, int.Parse);
      Console.WriteLine(FindClosestSum(n, k, items));
    }
  }
}

public class HK_Solution {
  public static void Main() {
    KnapsackUtil demo = new KnapsackUtil();
    demo.Run();
  }
}
