/***************************************************************************************************
* Title : Maximum Subarray
* URL   : https://leetcode.com/problems/maximum-subarray/
* Date  : 2015-07-23
* Comp  : O(n), O(1)
* Status: Accepted
* Notes : Largest sum in contiguous subarray; Kadane's Linear Algorithm to find max sum
*   kadane algorithm applies to contiguous subarray max sum prbolem
*   related to this problem that also requires index
* rel   : http://www.lintcode.com/en/problem/continuous-subarray-sum/
* ref   : https://en.wikipedia.org/wiki/Maximum_subarray_problem#Kadane's_algorithm
* meta  : tag-algo-dp, tag-dp-kadane
***************************************************************************************************/
public class Solution
{
  public int MaxSubArray(int[] nums) {
    return kadaneDP(nums);
  }

  private int kadaneDP(int[] A) {
    // initialize max sum with first element
    int current_sum = A[0];
    int max_sum = current_sum;

    // run simple kadane's algorithm to get max sum
    for (int i = 1; i < A.Length; i++) {
      // instead of taking max between previous sum and current sum, it takes between current sum
      // and A[i], because if we are considering subarrays
      // At any point of time, we only decide between whether to continue previous subarray or
      // start a new one
      current_sum = Math.Max(A[i], current_sum + A[i]);
      max_sum = Math.Max(max_sum, current_sum);
    }
    return max_sum;
  }
}
