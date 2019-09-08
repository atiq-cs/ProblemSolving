/***************************************************************************************************
* Title : Find Peak Element
* URL   : find-peak-element
* Date  : 18-10-21 (update to CS)
* Author: Atiq Rahman
* Comp  : O(lg n)
* Status: Accepted
* Notes : Alternative name "local maxima"
*   Finding a local minima is rather easy. Why Binary Search?
*   In worst case, local minima can be located at the end of the array. In such a case, linear
*   search takes O(N).
*   
*   Therefore, a binary search which starts from the middle element and goes to the left side if
*   item on the left is larger is intuitive. Similarly if the item on the right side is larger then
*   it takes the search direction towards the right side.
*   This approach works because returning any maxima suffices for this problem.
*
* ref   : https://stackoverflow.com/q/12238241 (detailed explanation)
*   https://www.geeksforgeeks.org/find-local-minima-array/
* rel   : 
* meta  : tag-binary-search, tag-ds-array, tag-leetcode-medium
***************************************************************************************************/
public class Solution
{
  public int FindPeakElement(int[] nums) {
    return FindPeakElement(nums, 0, nums.Length - 1);
  }

  public int FindPeakElement(int[] nums, int low, int high) {
    if (low == high)
      return low;
    else {
      int mid1 = (low + high) / 2;
      int mid2 = mid1 + 1;
      if (nums[mid1] > nums[mid2])
        return FindPeakElement(nums, low, mid1);
      else
        return FindPeakElement(nums, mid2, high);
    }
  }
}
