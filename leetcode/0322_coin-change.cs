/***************************************************************************************************
* Title : Coin Change
* URL   : https://leetcode.com/problems/coin-change
* Date  : 2017-12
* Author: Atiq Rahman
* Comp  : O(mn)
* Status: Accepted
* Notes : My previous solution works to find of number of ways
*   This problem asks for min number of coins
*   
*   To compute number of ways,
*   we initially set that 0 can be made in 1 ways.
*
*   for (int i = 0; i < m; i++)
*     for (int j = 1; j <= n; j++) {
*       if (j >= coins[i])
*         w[j] += w[j - coins[i]];
*     }
*   
*   if a target amount can be made in 1
*   
*   when we are tryin
*   
*   11
*   1 2 5
*   
*   5 2 1
*   we know that
*   we can make 5, 2, 1
*   
*   we will get,
*   nc[1] = 1
*   nc[2] = 1
*   nc[5] = 1
*   
*   for (int i = 0; i < m; i++)
*     for (int j = 1; j <= n; j++)
*       if (j >= coins[i] && nc[j] > nc[j - coins[i]]+1)
*         nc[j] = nc[j - coins[i]]+1;
*   
*   initialize with 0
*   
*   one first round iteration for first coin it becomes,
*    0 1 2 3 4 5 6 7 8 9 10 11
*   
*   second iteration,
*    0 1 1 1
* rel   : https://www.hackerrank.com/challenges/coin-change
*   https://leetcode.com/problems/coin-change-2
* meta  : tag-coin-change, tag-algo-dp, tag-leetcode-medium
***************************************************************************************************/
public class Solution {
  static int INF = int.MaxValue;

  // make amount n using m coins
  public int CoinChange(int[] coins, int n) {
    int m = coins.Length;
    int[] nc = new int[n+1];
    nc[0] = 0;

    for (int i=1; i<n+1; i++)
      nc[i] = INF;

    for (int i = 0; i < m; i++)
      // might be better than starting from 1
      for (int j = coins[i]; j <= n; j++)
        if (j >= coins[i] && nc[j - coins[i]] != INF && nc[j] > nc[j - coins[i]]+1)
          nc[j] = nc[j - coins[i]]+1;

    return nc[n]==INF?-1:nc[n];
  }
}
