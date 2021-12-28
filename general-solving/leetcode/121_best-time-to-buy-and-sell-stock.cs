/***************************************************************************
* Problem Name: Best Time to Buy and Sell Stock
* Problem URL : https://leetcode.com/problems/best-time-to-buy-and-sell-stock
* Date        : Dec 2015
* Complexity  : O(n) Time beats 76%
* Author      : Atiq Rahman
* Status      : Accepted (160ms)
* Notes       : find max diff
*               desc draft at bottom
* Ref         : 'online-problem-solving/icpc.kattis/artichoke.cs'               
* meta        : tag-dynamic-programming
***************************************************************************/
public class Solution {
  public int MaxProfit(int[] prices) {
    int previousPrice = prices.Length>0?prices[0]:0;
    int minPrice = previousPrice;
    int maxDiff = 0;
    
    for (int i = 1; i < prices.Length; i++) {
      // min is the min till (before) current item
      minPrice = Math.Min(minPrice, previousPrice);
      // get diff with min to get max diff
      int curDiff = prices[i]-minPrice;
      maxDiff = Math.Max(maxDiff, curDiff);
      previousPrice = prices[i];
    }
    return maxDiff;
  }
}


/*
1 5 6 10 1 2 5

take 1,10 profit = 9
take 1, 5 profit = 4,
take 5, 6 profit = 1
take 6, 10 proft = 4

1 4 1 10
3 + 9

1 4 2 1 10
3 + 9

3 + 


Case 1:
how to know if we should sell a share
1 4 2 5 9
3 + 7
find max profit upto a max number, whenever a smaller number is found sell the share..
1 5 6 10 1 2 5
1 to 10 = 9
1 to 5  = 4

1 ... 10 2 1 5
*/
