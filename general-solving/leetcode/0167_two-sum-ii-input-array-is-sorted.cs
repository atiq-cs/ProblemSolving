/***************************************************************************
* Title : Two Sum II - Input array is sorted
* URL   : https://leetcode.com/problems/two-sum-ii-input-array-is-sorted
* Date  : 2016-08
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : 
* Rel   : https://leetcode.com/problems/two-sum (not sorted)
*   https://leetcode.com/problems/two-sum-iv-input-is-a-bst
* meta  : tag-leetcode-easy, tag-two-pointers
***************************************************************************/
public class Solution {
  public int[] TwoSum(int[] nums, int target) {
    for (int left = 0, right = nums.Length-1, sum; left<right; ) {
      if ((sum = nums[left] + nums[right]) == target)
        return new int[] { left + 1, right + 1};
      if (sum < target) left++;
      else right--;
    }
    return new int[] {-1, -1};
  }
}
