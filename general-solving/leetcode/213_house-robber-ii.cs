/***************************************************************************
* Problem Name: House Robber II
* Problem URL : https://leetcode.com/problems/house-robber-ii
* Date        : Sept 18 2017
* Complexity  : O(n) Time, O(n) space
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Consider that the solution that includes first item cannot
*               contain the last item
*               And, the solution that includes last item cannot include first
*               one
*               Take care of collision between first and last index
* meta        : tag-dynamic-programming
***************************************************************************/

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
