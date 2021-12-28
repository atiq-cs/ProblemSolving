/***************************************************************************************************
* Title : Maximum Subarray
* URL   : https://leetcode.com/problems/maximum-subarray/
* Date  : 2015-07
* Comp  : O(n) Time
* Author: Atiq Rahman
* Status: Accepted (176ms)
* Notes : Largest sum in contiguous subarray; Kadane's Linear Algorithm to find max sum
*   
* ref   : https://en.wikipedia.org/wiki/Maximum_subarray_problem#Kadane's_algorithm
* meta  : tag-algo-dp, tag-dp-kadane
***************************************************************************************************/
public class Solution
{
  public int MaxSubArray(int[] A)
  {
    // initialize max sum with first element
    int current_sum = A[0];
    int max_sum = current_sum;
  
    for (int i = 1; i < (int) A.Length; i++) {
      current_sum = Math.Max(A[i], current_sum + A[i]);
      max_sum = Math.Max(max_sum, current_sum);
    }
    return max_sum;
  }
}
