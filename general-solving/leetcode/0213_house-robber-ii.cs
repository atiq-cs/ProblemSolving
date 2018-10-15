/***************************************************************************************************
* Title : House Robber II
* URL   : https://leetcode.com/problems/house-robber-ii
* Date  : 2017-09-18
* Comp  : O(n) Time, O(n) space
* Author: Atiq Rahman
* Status: Accepted
* Notes : Same to previous problem with a new arranement as stated,
*   "all houses at this place are arranged in a circle"
*   
*   Due to this arrangement,
*   The solution that includes first house cannot contain the last house.
*   Similarly, the solution that includes last house cannot include first
*   house. Taking care of collision between first and last one solves the
*   problem.
* meta  : tag-dp, tag-leetcode-medium
***************************************************************************************************/
public class Solution {
  public int Rob(int[] nums) {
    if (nums.Length == 0)
      return 0;
    // if there's single element then include the whole range
    if (nums.Length == 1)
      return Rob(nums, 0, nums.Length);
    return Math.Max(Rob(nums, 1, nums.Length), Rob(nums, 0, nums.Length-1));
  }
  /* won't work if r<p ToDo: add a check */
  public int Rob(int[] nums, int p, int r) {
    int n = r - p;
    int[] maxP = new int[n];
    if (n > 0)
      maxP[0] = nums[p];
    if (n > 1)
      maxP[1] = Math.Max(maxP[0], nums[p+1]);
    
    for (int i = 2; i<n; i++)
      maxP[i] = Math.Max(maxP[i-2]+nums[p+i], maxP[i-1]);
    return n<1?0:maxP[n-1];      
  }
}
