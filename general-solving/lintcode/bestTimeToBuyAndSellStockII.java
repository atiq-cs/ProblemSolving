//http://www.lintcode.com/en/problem/best-time-to-buy-and-sell-stock-ii/
class Solution {
    /**
     * @param prices: Given an integer array
     * @return: Maximum profit
     */
    public int maxProfit(int[] prices) {
        // write your code here
        int sum = 0, diff = 0;
        
        for(int i = 1; i < prices.length; i++){// return all the differences
            diff = prices[i] - prices[i - 1];
            if(diff > 0)
                sum += diff;
        }
        
        return sum;
    }
}