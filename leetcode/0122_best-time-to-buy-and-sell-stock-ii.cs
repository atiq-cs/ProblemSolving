/***************************************************************************************************
* Title : Best Time to Buy and Sell Stock II
* URL   : https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
* Date  : 2015-11-17
* Comp  : O(n), O(1)
* Status: Accepted
* Notes : Look at example for better understanding how this solution progresses
*   Sub-problems (intervals) actually depend, after we find first interval
*   that's when we know where second interval starts. So even though across an
*   interval though max, min are not dependent, this is still a dynamically progressing
*   solution.
*   
*   Thanks Md Abdul Kader (Sreezin) for his opinion on the analysis on this part.
* meta  : tag-algo-dp, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public int MaxProfit(int[] prices) {
    int sumProfit = 0;
    int minP = prices.Length>0?prices[0]:0;
    int maxP = 0;
    for (int i=1; i<prices.Length; i++) {
      if (prices[i] < maxP) {     // start of a new interval
        sumProfit += maxP - minP;
        maxP = 0;                 // max and min reset
        minP = prices[i];
      }
      else if (prices[i]<minP)    // update min
        minP = prices[i];
      else if (prices[i] > maxP)  // update max
        maxP = prices[i];
    }
    return maxP==0? sumProfit : sumProfit+maxP-minP;
  }
}

/*
Example scenario 1: 1 4 10 2 1 5

  start from first index, update min if next number is less
  if next number is greater update max
at index = 2:
  sumProfit = 0
  min = 1,
  max = 10

at index = 3
  sumProfit = max - min = 9
  min = 2
  max = -1
  
at index = 4
  sumProfit = 9
  min = 1
  max = -1
  
at index = 5
  sumProfit = 9
  min = 1
  max = 5
  
result = sumProfit += max - min = 4
  = 13
*/
