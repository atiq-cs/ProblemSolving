/***************************************************************************
* Title : Subarray Sum Equals K
* URL   : https://leetcode.com/problems/subarray-sum-equals-k
* Date  : 2018-04-18
* Author: Atiq Rahman
* Comp  : O()
* Status: Accepted
* Notes : O(N^2) solution added, O(N) solution yet to add
*   may be check discuss
* meta  : tag-hash-table, tag-leetcode-medium
***************************************************************************/
public class Solution {
  public int SubarraySum(int[] nums, int k)
  {
    int[] prefixSum = GetPrefixSum(nums);
    int count = 0;
    for (int j=0; j<nums.Length; j++)
      for (int i=0; i<=j; i++) {
        int sum = prefixSum[j] - (i==0?0:prefixSum[i-1]);
        if (sum == k)
          count++;
      }
    return count;
  }

  int[] GetPrefixSum(int[] nums)
  {
    int[] prefixSum = new int[nums.Length];
    prefixSum[0] = nums.Length ==0?0:nums[0];
    for (int i = 1; i < nums.Length; i++)
      prefixSum[i] += nums[i] + prefixSum[i - 1];
    return prefixSum;
  }
}
