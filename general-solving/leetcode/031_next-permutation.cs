/***************************************************************************
* Problem Name: Next Permutation
* Problem URL : https://leetcode.com/problems/next-permutation/
* Date        : Oct 24 2015
* Complexity  : O(n) Time
* Author      : Atiq Rahman
* Status      : Accepted (beat 93%)
* Notes       : have to test the approach with UVA - 146
*               Tested with spoj: online-problem-solving/spoj/12150_JNEXT.cs
*               Credits: https://github.com/animeshh
 *              Further improvement: http://codeforces.com/blog/entry/3980
* meta        : tag-next-permutation
***************************************************************************/

public class Solution {
    public void NextPermutation(int[] nums) {
        // iterate in reverse, find the index before which item is less
        int i = nums.Length - 1;
        while (i > 0 && nums[i - 1] >= nums[i])
            i--;
        // find the item that is immediately greater than nums[i-1] and swap
        if (i>0) {
            int j = nums.Length - 1;
            while (nums[i - 1] >= nums[j])  //>= so we choose the last one
                j--;  // so that after swapping small number comes at the later index
            int temp = nums[j]; nums[j] = nums[i - 1]; nums[i - 1] = temp;
        }   // afterwards, when we reverse the string order is maintained
        for (int j=i, k=nums.Length-1; j<k;j++,k--)
            /* if (nums[j]>nums[k]) */ {  // swap condition not required
                int temp = nums[j]; nums[j] = nums[k]; nums[k] = temp;
            }
    }
}

/*  Mental sketch:
    5, 4, 3, 1, 2
    5 4 3 2 1
    5 4 3 1 2

    [5, 4, 1, 3, 2]
    [5, 4, 2, 3, 1]
    [5, 4, 2, 1, 3]


    [2,3,1,3,3]
    [2,3,3,1,3]

    [2,1,2,2,2,2,2,1]
    [2,2,2,2,2,2,1,1]

    [2,1,3,2,2,2,2,1]
    [2,3,1,2,2,2,2,1]

    [2,2,3,2,2,2,2,1]

    [2,2,3,3,3,3,3,2]
    [2,3,2,3,3,3,3,2]

    [2,2,1,1,2,2,2,2]

    [5, 4, 2, 3, 1, 0]
    [5, 4, 3, 2, 1, 0]

    [3,4,1,4,3,3]
    [3,4,3,4,3,1]
    [3,4,3,3,1,4]

 * Special Inputs:
 * [3,4,1,4,3,3]
 * [5, 4, 3, 2, 1]
 * [5, 4, 3, 1, 2]
 * [4, 3, 5, 2, 1]
 * [2,3,1,3,3]
 * [2,1,2,2,2,2,2,1]
*/
