/***************************************************************************
* Problem Name: Maximum Subarray
* Problem URL : https://leetcode.com/problems/maximum-subarray/
* Date        : July 2015
* Complexity  : O(n) Time
* Author      : Atiq Rahman
* Status      : Accepted (176ms)
* Notes       : Largest sum in contiguous subarray
*               fill in ...
*               
* meta        : tag-dynamic-programming
***************************************************************************/

public class Solution {
    public int MaxSubArray(int[] nums) {
        return kadane(nums);
    }
    
    private int kadane(int[] A) {
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