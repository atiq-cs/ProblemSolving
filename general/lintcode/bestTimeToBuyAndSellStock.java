/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/best-time-to-buy-and-sell-stock
* Author: Tianshu Bao (tianshubao1), commit#47b65e92b
* Date  : 2015-06-05
***************************************************************************************************/
public class Solution
{
  public int maxProfit(int[] prices) {
    int min = Integer.MAX_VALUE;
    int profit = 0;
    
    for(int i = 0; i < prices.length; i++){
      if(prices[i] < min)
        min = prices[i];
      if(prices[i] - min > profit)
        profit = prices[i] - min;
    }
    
    return profit;
  }
}
