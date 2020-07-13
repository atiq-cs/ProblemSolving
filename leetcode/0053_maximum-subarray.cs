/***************************************************************************************************
* Title : Maximum Subarray
* URL   : https://leetcode.com/problems/maximum-subarray/
* Date  : 2015-07-23
* Comp  : O(n), O(1)
* Status: Accepted
* Notes : Largest sum in contiguous subarray; Kadane's Linear Algorithm to find max sum
*   kadane algorithm applies to contiguous subarray max sum prbolem
*   related to this problem that also requires index
*   
*   ToDo: variation: find minimal absolute subarray sum of a subarray
*    https://stackoverflow.com/q/25965939
* rel   : http://www.lintcode.com/en/problem/continuous-subarray-sum/
* ref   : https://en.wikipedia.org/wiki/Maximum_subarray_problem#Kadane's_algorithm
* meta  : tag-algo-dp, tag-dp-kadane, tag-leetcode-easy
***************************************************************************************************/
public class Solution {
  /// <summary>
  /// Kadane Dynamic Prgramming algorithm
  /// </summary>
  /// <remarks>Consider method name as 'KadaneDP' </remarks>
  /// <param name="A"> Input array collection from which max sum to find </param>
  /// <returns> max sum possible from subarrays</returns>
  public int MaxSubArray(int[] A) {
    // initialize max sum with first element
    int current = A[0];   // current sum
    int max = current;    // max possible sum

    // run simple kadane's algorithm to get max sum
    for (int i = 1; i < A.Length; i++) {
      // instead of taking max between previous sum and current sum, it takes between current sum
      // and A[i], because if we are considering subarrays
      // At any point of time, we only decide between whether to continue previous subarray or
      // start a new one
      current = Math.Max(A[i], current + A[i]);
      max = Math.Max(max, current);
    }
    return max;
  }
}
