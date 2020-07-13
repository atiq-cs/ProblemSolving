/***************************************************************************
* Title : Find Pivot Index
* URL   : https://leetcode.com/problems/find-pivot-index
* Occasn: Den 2018-04-21
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : Den's Problem Desc,
*   Given an array of integers, 
*   find the pivot index where the sum of the items to the left
*   equal to the sum of the items to the right.
*   Example
*    [1, 2, 1, 6, 3, 1] -> 3
*    [5, 2, 7] -> -1
*   My solution following initial intuition of prefix sum added below.
*   There is another approach a few people tried at DEN which is explained in
*   draft at the bottom.
* meta  : tag-array, tag-leetcode-easy, tag-sweep-line
***************************************************************************/
public class Solution {
  // second version following python sol by somebody at the meetup
  public int PivotIndex(int[] nums) {
    for (int i=0, left = 0, right = nums.Sum(); i<nums.Length; i++) {
      left += nums[i];
      if (left - nums[i] == right - left)
        return i;
    }
    return -1;
  }

  // another version based on first version, bound checks required in this one
  public int PivotIndex(int[] nums) {
    for (int i = 0, left = nums.Length == 0 ? 0 : nums[i], right = nums.Sum();
      i < nums.Length; i++, left += i < nums.Length ? nums[i] : 0)
      if (left - nums[i] == right - left)
        return i;
    return -1;
  }

  // shortened first version
  public int PivotIndex_v1(int[] nums) {
    for (int i=0, left = 0, right = nums.Sum(); i<nums.Length; i++) {
      left += i==0?0:nums[i-1];
      right -= i==0?0:nums[i-1];
      if (left == right - nums[i])
        return i;
    }
    return -1;
  }

}

/*
Left, right sweep algorithm,
initialize left with first index and right with last index
when left sum is less than the right sum increment left side index pionter
otherwise increment right side index pointer

When there are repitions this approach has issues.

Critical case with left right algorithm
[-1,-1,-1,0,1,1]
sum = -1

1 = -1, 1
2 = -2, 2

Need to put more effort to find out whether this approach will really work to
handle duplicates or negatives number cases.
*/
