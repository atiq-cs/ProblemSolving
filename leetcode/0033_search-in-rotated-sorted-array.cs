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
* meta  : tag-algo-bsearch, tag-recursion
***************************************************************************/
public class Solution {
  public int Search(int[] A, int item) {
    return BSearch(A, item, 0, A.Length-1);
  }

  private int BSearch(int[] A, int item, int start, int end) {
    if (start > end)
      return -1;

    int mid = start + (end-start) / 2;
    if (A[mid] == item)
      return mid;

    // left side is sorted if the first element is less or equal to the middle
    // element
    if (A[start] <= A[mid]) {
      // For regular binary search when A[mid] > item item is definitely on
      // left side.
      // However, in this problem, due to rotation, it is possible that even
      // though mid item is bigger than item, the item we are looking for
      // actually on right side Example, 1 2 3 4 rotated as, 2 3 4 1
      // Suppose, start = 2, mid = 3 and item =1
      // will be on left side if target lies between start and mid
      if (A[mid] > item && A[start] <= item)
        return BSearch(A, item, start, mid-1);
      // mid > item: yet, item is not in left side because of starting item
      return BSearch(A, item, mid+1, end);
    }
    // otherwise, right side is sorted
    else {
      // Similarly, checking item <= A[end] if rotation has moved the item to
      // left side
      if (A[mid] < item && item <= A[end])
        return BSearch(A, item, mid+1, end);
      return BSearch(A, item, start, mid-1);
    }
  }
}

/*
Debug prints,
 Console.WriteLine("start " + start + " end " + end + " mid " + mid);
*/
