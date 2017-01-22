/***************************************************************************
* Problem Name: Best Time to Buy and Sell Stock
* Problem URL : https://leetcode.com/problems/best-time-to-buy-and-sell-stock
* Date        : Dec 2015
* Complexity  : O(n) Time
* Author      : Atiq Rahman
* Status      : Accepted (160ms)
* Notes       : find max diff
*               fill in ...
*               
* meta        : tag-dynamic-programming
***************************************************************************/

public class Solution {
    public int MaxProfit(int[] prices) {
        int previousPrice = prices.Length>0?prices[0]:0;
        int minPrice = previousPrice;
        int maxDiff = 0;
        
        for (int i = 1; i < prices.Length; i++) {
            minPrice = Math.Min(minPrice, previousPrice);   // max is the max till current item
            int curDiff = prices[i]-minPrice;              // get diff with max
            maxDiff = Math.Max(maxDiff, curDiff);
            previousPrice = prices[i];
        }
        return maxDiff;
    }
}
