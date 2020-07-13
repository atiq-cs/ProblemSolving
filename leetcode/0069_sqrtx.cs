/***************************************************************************
* Title : Sqrt(x)
* URL   : https://leetcode.com/problems/sqrtx
* Date  : 2018-05-05
* Author: Atiq Rahman
* Comp  : O(lg N) Time, O(lg N) space on Stack of recursion
* Status: Accepted
* Notes : Find integer square root of an integer number. If the number is not
*   perfect square return rounded integer value of square root.
*   Two overflows handled,
*   - computation of mid by adding and dividing
*   - result of a multiplication that would exceed integer limit (I guess I
*   could use sign bit of product to determine an overflow; however, I take
*   the lazy approach of casting it to a spacious primitive type to resolve the
*   overflow)
*
*   There are input range limitations of Sqrt(*) method: input should be in
*   integer limit
*
*   Encountered twice: first in JS meetup later at meetup 2018-05-06 (the den)
* meta  : tag-algo-bsearch, tag-math, tag-leetcode-easy
***************************************************************************/
public class Solution {
  private int n;
  public int MySqrt(int x) {
    return Sqrt(0, n=x);
  }
  
  // recursive binary search method
  public int Sqrt(int start, int end)
  {
    if (start >= end)
      return end;
    int mid = (end - start) / 2 + start; // overflow fix for addition
    long mul = (long) mid * mid;  // overflow fix for multiplication
    if (mul == n)
      return mid;
    if (mul > n)
      return Sqrt(start, mid-1);
    if (mul + 2*mid+1 > n)  // = (mid+1) ^ 2
      return mid;
    return Sqrt(mid+1, end);
  }
}
