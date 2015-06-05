//http://www.lintcode.com/en/problem/best-time-to-buy-and-sell-stock/#
public class Solution {
    /**
     * @param prices: Given an integer array
     * @return: Maximum profit
     */
    public int maxProfit(int[] prices) {
        // write your code here
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
