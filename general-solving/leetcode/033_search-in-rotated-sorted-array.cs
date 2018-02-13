/***************************************************************************
* Title : Search in Rotated Sorted Array
* URL   : https://leetcode.com/problems/search-in-rotated-sorted-array
* Date  : 2018-02-12
* Author: Atiq Rahman
* Comp  : O(lg n)
* Status: Accepted
* Notes : Based on Vasili's version which essentially boils down to,
*   if element on starting index is less than item on middle index then left
*   (w.r.t middle element) side is sorted
*   Otherwise, right side is sorted
*   
*   Because one of the two sides must be sorted in a rotated sorted array
*   
*   This is more comprehensive than what I was developing initially,
*   My first idea was to consider all cases where the rotation index can be (
*   starting from 1 to N-1). This means rotation point can be in between
*   first and middle or middle and last
* meta  : tag-binary-search, tag-recursion
***************************************************************************/
public class Solution {
  private int[] A;

  public int Search(int[] nums, int item) {
    A = nums;
    return BSearch(item, 0, nums.Length-1);
  }

  private int BSearch(int item, int start, int end) {
    if (start > end)
      return -1;

    int mid = (start + end) / 2;
    if (A[mid] == item)
      return mid;

    // left side is sorted if the first element is less or equal to the middle
    // element
    if (A[start] <= A[mid]) {
      if (A[mid] > item && A[start] <= item)
        return BSearch(item, start, mid-1);
      return BSearch(item, mid+1, end);
    }
    // otherwise, right side is sorted
    else {
      if (A[mid] < item && item <= A[end])
        return BSearch(item, mid+1, end);
      return BSearch(item, start, mid-1);
    }
  }
}
