/***************************************************************************
* Problem Name: Range Sum Query - Immutable
* Problem URL : https://leetcode.com/problems/range-sum-query-immutable/
* Date        : Dec 31 2015
* Complexity  : O(N) Time and Space
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Direct application of Prefix Sum
* 
* meta        : tag-dynamic-programming
***************************************************************************/

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
