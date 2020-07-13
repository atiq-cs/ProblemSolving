/***************************************************************************************************
* Title : House Robber
* URL   : https://leetcode.com/problems/house-robber/
* Date  : 2019-01-29
* Comp  : O(n), O(1)
* Occasn: leetcode meetup 229 Polaris Ave, Mtn View
* Status: Accepted
* Notes : As it is stated
*   "it will automatically contact the police if two adjacent houses were broken into on the same
*   night."
*
*   Take care of this adjacent cases and that makes the solution
* meta  : tag-algo-dp, tag-recursion, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public int Rob(int[] nums) {
    int sum1 = 0, sum2 = 0;

    foreach (var num in nums) {
      // use of temp var instead of `sum1 = sum2` to avoid losing sum1
      int temp = sum2;
      sum2 = Math.Max(sum1 + num, sum2);
      sum1 = temp;
    }
    return sum2;
  }

  // O(n) Space
  public int Rob(int[] nums) {
    var dp = new int[nums.Length];

    for (int i = 0; i < nums.Length; i++)
      dp[i] = Math.Max((i < 2 ? 0 : dp[i - 2]) + nums[i], i < 1 ? 0 : dp[i - 1]);

    return nums.Length == 0 ? 0 : dp[nums.Length - 1];
  }
}

/*
Consider following example,
2, 5, 1, 7, 6, 3

max from robbing first houses 1,
2

max from robbing first houses 2,
two houses are adjacent, only one of them can be robbed
max(2, 5) = 5

max from robbing first houses 3,
max(5, 1+2) = 5

max from robbing first houses 4,
7 + max of first 2

max profit from house i, can be represented as recurrence location,
p[i-1] = max(h[i-1] + p[i-3], p[i-2])

First implementation (2015-10-23),

  public int Rob(int[] nums) {
    int[] maxP = new int[nums.Length];
    if (nums.Length > 0)
      maxP[0] = nums[0];
    if (nums.Length > 1)
      maxP[1] = Math.Max(maxP[0], nums[1]);
    
    for (int i = 2; i<nums.Length; i++)
      maxP[i] = Math.Max(maxP[i-2]+nums[i], maxP[i-1]);
    return nums.Length<1?0:maxP[nums.Length-1];
  }
*/
