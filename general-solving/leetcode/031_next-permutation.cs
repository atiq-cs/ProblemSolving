/***************************************************************************
* Problem Name: Next Permutation
* Problem URL : https://leetcode.com/problems/next-permutation/
* Date        : Oct 24 2015
* Complexity  : O(n) Time
* Author      : Atiq Rahman
* Status      : Accepted (beat 77%)
* Notes       : have to test the approach with UVA - 146
* meta        : tag-next-permutation
***************************************************************************/

public class Solution {
    public void NextPermutation(int[] nums) {
        // iterate in reverse, find the index before which item is less
        int i;
        for (i=nums.Length-1; i>=1; i--)
            if (nums[i-1]<nums[i])
                break ;
        // find the item that is immediately greater than nums[i] and swap
        if (i>0) {
            int k = i;
            for (int j=i+1; j<nums.Length; j++)
                if (nums[i-1]<nums[j] && nums[k]>=nums[j])  //>= so we choose the last one
                    k = j;  // so that after swapping small number comes at the later index
            int temp = nums[k]; nums[k] = nums[i-1]; nums[i-1] = temp;
        }   // afterwards, when we sort the order is maintained
        for (int j=i, k=nums.Length-1; j<k;j++,k--)
            if (nums[j]>nums[k]) {  // swap
                int temp = nums[j]; nums[j] = nums[k]; nums[k] = temp;
            }
    }
}

/*  Mental sketch:
    5, 4, 3, 1, 2
    5, 4, 3, 2, 1
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
