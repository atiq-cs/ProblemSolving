/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/best-time-to-buy-and-sell-stock-iii
* Author: Tianshu Bao (tianshubao1), commit#47b65e92b
* Date  : 2015-06-05
***************************************************************************************************/
class Solution {
  /**
   * @param prices: Given an integer array
   * @return: Maximum profit
   */
  public int maxProfit(int[] prices) {
    // write your code here
    if(prices == null || prices.length == 0)
      return 0;
      
    int len = prices.length;
    int[] left = new int[len];
    int[] right = new int[len];
    int min = prices[0], max = prices[len - 1];
    int profit = 0;
    
    for(int i = 1; i < len; i++){//consider max profit from left to right
      min = Math.min(prices[i], min);
      left[i] = Math.max(prices[i] - min, left[i - 1]);
    }
    
    for(int i = len - 2; i >= 0; i--){// consider max profit from right to left
      max = Math.max(prices[i], max);
      right[i] = Math.max(max - prices[i], right[i + 1]);
    }
    
    for(int i = 0; i < len; i++){
      profit = Math.max(left[i] + right[i], profit);
    }
    
    return profit;
  }
};
