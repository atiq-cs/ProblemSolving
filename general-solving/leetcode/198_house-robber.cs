/***************************************************************************
* Problem Name: House Robber
* Problem URL : https://leetcode.com/problems/house-robber/
* Date        : Oct 23 2015
* Complexity  : O(n) Time, O(n) space
* Author      : Atiq Rahman
* Status      : Accepted (beat 23%)
* Notes       : Take care of the adjacent houses, that's it
* meta        : tag-dynamic-programming, tag-easy
***************************************************************************/

public class Solution {
    public int Rob(int[] nums) {
        int[] maxP = new int[nums.Length];
        if (nums.Length > 0)
            maxP[0] = nums[0];
        if (nums.Length > 1)
            maxP[1] = Math.Max(maxP[0], nums[1]);
        
        for (int i = 2; i<nums.Length; i++)
            maxP[i] = Math.Max(maxP[i-2]+nums[i], maxP[i-1]);
        return nums.Length<1?0:maxP[nums.Length-1];
    }
}

/*  Consider following example,
    2, 5, 1, 7, 6, 3

    max from robbing first houses 1,
    2

    max from robbing first houses 2,
    two houses are adjacent, only one of them can be robbed
    max(2, 5) = 5

    max from robbing first houses 3,
    max(5, 1+2) = 5

    max from robbing first houses 4,
    7 + max of first 2

    max profit from n
    p[n-1] = max(h[n-1] + p[n-3], p[n-2])
*/
