/***************************************************************************
*   Problem Name:   Maximum Subarray
*   Problem URL :   https://leetcode.com/problems/maximum-subarray/
*                  related solved: http://www.lintcode.com/en/problem/continuous-subarray-sum/
 *                   which also require index
*   Date        :   July 23, 2015
*   Algo, DS    :   Maximum_subarray_problem
*   Desc        :   Simple implementation
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   Note        :   A simple example of DP is kadane algorithm
*   meta        :   tag-dynamic-programming, tag-kadane
***************************************************************************/

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
