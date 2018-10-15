/***************************************************************************************************
* Title : Move Zeroes
* URL   : https://leetcode.com/problems/move-zeroes/
* Date  : 2015-10-06
* Comp  : 
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
* meta  : tag-two-pointers, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  // much more compact version
  public void MoveZeroes(int[] nums) {
    int j = 0;
    for (int i = 0; i < nums.Length; i++)
      if (nums[i] != 0)
        nums[j++] = nums[i];

    for (; j < nums.Length; j++)
      nums[j] = 0;
  }

  // first attempt
  public void MoveZeroes(int[] nums)
  {
    int startIndex = GetFirstZeroIndex(nums);
    for (int i = startIndex + 1; i < nums.Length; i++)
      if (nums[i] != 0)
        nums[startIndex++] = nums[i];

    for (int i = startIndex; i < nums.Length; i++)
      nums[i] = 0;
  }
  int GetFirstZeroIndex(int[] nums)
  {
    for (int i = 0; i < nums.Length; i++)
      if (nums[i] == 0)
        return i;
    return nums.Length;
  }
}

/*
Problem: Move Zeroes
---------------------
[0, 1, 0, 3, 12] to [1, 3, 12, 0, 0]

to do in-place we have to keep indices of 0
1 goes to 0 - index 0
3 goes to next index 1
12 goes to next index 2

Consider another example,
[1, 0, 4, 3, 12] to [1, 4, 3, 12, 0]

basically all zero items go to indices starting from startIndex
*/
