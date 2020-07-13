/***************************************************************************************************
* Title : Range Sum Query - Immutable
* URL   : https://leetcode.com/problems/range-sum-query-immutable/
* Date  : 2015-12-31
* Comp  : O(N), O(N)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Direct application of Prefix Sum
* meta  : tag-algo-dp, tag-leetcode-easy
***************************************************************************************************/
public class NumArray {
  private int[] prefix_sum = null;

  public NumArray(int[] nums) {
    if (nums.Length > 0)
    {
      prefix_sum = new int[nums.Length];
      prefix_sum[0] = nums[0];
    }

    for (int i = 1; i < nums.Length; i++)
      prefix_sum[i] = prefix_sum[i - 1] + nums[i];
  }

  public int SumRange(int i, int j) {
    return prefix_sum[j] - ((i > 0) ? prefix_sum[i - 1] : 0);
  }
}
