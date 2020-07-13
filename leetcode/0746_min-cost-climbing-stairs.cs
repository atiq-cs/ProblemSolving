/***************************************************************************
* Title : Min Cost Climbing Stairs
* URL   : https://leetcode.com/problems/min-cost-climbing-stairs/
* Date  : 2018-04-28
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : O(N^2) solution added, O(N) solution yet to add
*   may be check discuss
* rel   : https://leetcode.com/problems/climbing-stairs
* meta  : tag-algo-dp, tag-leetcode-easy
***************************************************************************/
public class Solution {
  public int MinCostClimbingStairs(int[] costs)
  {
    int min1 = 0; // dp[i-2]
    int min2 = 0; // dp[i-1]
    int min3 =0;  // dp[i]

    foreach( int cost in costs) {
      min1 = min2;
      min2 = min3;
      min3 = Math.Min(min1, min2) + cost;
    }
    return Math.Min(min2, min3);  // result is in dp[n-2] and p[n-1]
  }
}

/*
Draft,
Understanding example 2,
[1, 100, 1, 1, 1, 100, 1, 1, 100, 1]

0 -> 2 -> 4 -> 6 -> 7 -> 9
Cost = 1 + 1 + 1 + 1 + 1 = 6

DP for this,

i-th step of the stair-case
can take 1 step or 2 step

dp[i+1] = Min(dp[i-1], dp[i]) + cost[i+1]

Understanding example 1,
[10, 15, 20]

cost[0] = 10
cost[1] = 15
cost[2] = 20

dp[-1] = 0
dp[0] = 0 + 10 = 10
dp[1] = Min(dp[i-2], dp[i-1]) + cost = Min(0, 10) + 15= 15
dp[2] = dp[0], dp[1] + cost = Min(10, 15) + 20 = 10 + 20 = 30

Answer is Min(dp[n-1], dp[n])

dp[0] = 0;
dp[1] = cost[0];
for (int i=1; i<n; i++) {
  dp[i+1] = Min(dp[i-1], dp[i])
}

(0, 0, 10)
(0, 10, 15)
(10, 15, 30)

return Min(min2, min3)
*/
