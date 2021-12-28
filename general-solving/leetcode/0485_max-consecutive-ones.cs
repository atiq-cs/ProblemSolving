/***************************************************************************
* Title : Max Consecutive Ones
* URL   : https://leetcode.com/problems/max-consecutive-ones/
* Date  : 2017-10-24
* Author: Atiq Rahman
* Comp  : O(1)
* Status: Accepted
* Notes : Counting from an array
* meta  : tag-easy
***************************************************************************/
public class Solution {
  public int FindMaxConsecutiveOnes(int[] nums) {
    int max = 0;
    int count = 0;
    for (int i=0; i<nums.Length; i++) {
      if (nums[i] == 0) {
        if (max<count)
          max = count;
        count = 0;
      }
      else
        count++;
    }
    if (max<count)
      max = count;
    return max;
  }
}
