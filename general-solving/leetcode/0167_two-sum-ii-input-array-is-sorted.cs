/***************************************************************************
* Title : Two Sum II - Input array is sorted
* URL   : https://leetcode.com/problems/two-sum-ii-input-array-is-sorted
* Date  : 2016-08
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : 
* rel   : https://leetcode.com/problems/two-sum (not sorted)
*  https://leetcode.com/problems/two-sum-iv-input-is-a-bst
* meta  : tag-two-pointers, tag-leetcode-easy
***************************************************************************/
public class Solution
{
  public int[] TwoSum(int[] nums, int target) {
    for (int start = 0, end = nums.Length - 1, sum; start < end;) {
      if ((sum = nums[start] + nums[end]) == target)
        return new int[] { start + 1, end + 1 };

      if (sum < target)
        start++;
      else
        end--;
    }

    return new int[] { -1, -1 };
  }
}
