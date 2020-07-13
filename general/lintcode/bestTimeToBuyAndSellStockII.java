/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/best-time-to-buy-and-sell-stock-ii/
* Author: Tianshu Bao (tianshubao1), commit#47b65e92b
* Date  : 2015-06-05
***************************************************************************************************/
class Solution
{
  public int maxProfit(int[] prices) {
    int sum = 0, diff = 0;
    
    for(int i = 1; i < prices.length; i++) {
      // return all the differences
      diff = prices[i] - prices[i - 1];
      if(diff > 0)
        sum += diff;
    }
    
    return sum;
  }
}
