/***************************************************************************************************
* Title : Maximum Subarray
* URL   : https://leetcode.com/problems/maximum-subarray/
* Date  : 2015-07-23

* Notes : Simple implementation
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : A simple example of DP is kadane algorithm
*   Algo, DS-   Maximum_subarray_problem
*   related problem below also requires index
* rel   : http://www.lintcode.com/en/problem/continuous-subarray-sum/
* meta  : tag-algo-dp, tag-kadane
***************************************************************************************************/
public class Solution
{
  public int MaxSubArray(int[] nums) {
    return kadane_algo(nums);
  }

  private int kadane_algo(int[] A) {
    // initialize max sum with first element
    int current_sum = A[0];
    int max_sum = current_sum;

    // run simple kadane's algorithm to get max sum
    for (int i = 1; i < A.Length; i++) {
      current_sum = Math.Max(A[i], current_sum + A[i]);
      max_sum = Math.Max(max_sum, current_sum);
    }
    return max_sum;
  }
}
