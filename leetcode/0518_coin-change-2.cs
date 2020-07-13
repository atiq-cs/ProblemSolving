/***************************************************************************
* Title : Coin Change
* URL   : https://leetcode.com/problems/coin-change-2
* Date  : 2018-05-19
* Author: Atiq Rahman
* Comp  : O(mn)
* Status: Accepted
* Notes : More info in following problem,
*   'general-solving/hackerrank/algo/dynamic-programming/001_coin-change.cs'
*   and the leetcode prob in reference below (because that was solved before
*   this)
* Rel   : https://leetcode.com/problems/coin-change
* meta  : tag-coin-change, tag-algo-dp
***************************************************************************/
public class Solution {
  public int Change(int n, int[] coins) {
    int[] numWays = new int[n+1];
    numWays[0] = 1;
    for (int i=0; i<coins.Length; i++)
      for (int j=1; j<=n; j++)
        if (j >= coins[i])
          numWays[j] += numWays[j-coins[i]];
    return numWays[n];
  }
}
