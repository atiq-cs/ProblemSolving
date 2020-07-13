/***************************************************************************************************
* Title : First Bad Version
* URL   : https://leetcode.com/problems/first-bad-version/
* Date  : 2015-10-09
* Comp  : O(log n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
*   1. The recursive version does not get runtime error not because of stack overflow
*   but because of integer overflow while using
*     int mid = (start + end)/2;
*   Changing variables to unint also makes the solution acceptable for large numbers
*   2. I never knew binary search could return the first item found among many items with same values
* ref   : https://leetcode.com/discuss/62255/o-lgn-simple-java-solution
* meta  : tag-binary-search, tag-recursion
***************************************************************************************************/
/* The isBadVersion API is defined in the parent class VersionControl.
    bool IsBadVersion(int version); */
public class Solution : VersionControl
{
  public int FirstBadVersion(int n) {
    return FirstBadVersionRec(1, n);
  }
  
  int FirstBadVersionRec(int start, int end) {
    if (start >= end)
      return start;
    int mid = start + (end-start)/2;
    if (IsBadVersion(mid))
      return FirstBadVersionRec(start, mid);
    return FirstBadVersionRec(mid+1, end);
  }
}

// iterative version using uint
public int FirstBadVersion(int n) {
  uint start = 1;
  uint end = (uint)n;
    
  while (start < end) {
    uint mid = (start+end)/2;
    if (!IsBadVersion((int)mid))
      start = mid + 1;
    else
      end = mid;
  }
  return (int)start;
}
