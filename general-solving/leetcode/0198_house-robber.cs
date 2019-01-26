/***************************************************************************************************
* Title : House Robber
* URL   : https://leetcode.com/problems/house-robber/
* Date  : 2015-10-23
* Comp  : O(n), O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : As it is stated
*   "it will automatically contact the police if two adjacent houses were broken into on the same
*   night."
*
*   Take care of this adjacent cases and that makes the solution
* meta  : tag-algo-dp, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
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
*/
