/***************************************************************************
* Title : Valid Perfect Square
* URL   : https://leetcode.com/problems/valid-perfect-square
* Date  : 2018-05-05
* Author: Atiq Rahman
* Comp  : O(lg N) Time, O(lg N) space on Stack of recursion
* Status: Accepted
* Notes : Check if given integer number is a perfect square
*   Based on 'leetcode/069_sqrtx.cs'
*
*   Condition for '(mid+1) * (mid+1) > n' check is removed which is only required
*   if we want to find a rounded square root integer value
* meta  : tag-binary-search, tag-leetcode-easy
***************************************************************************/
public class Solution
{
  private int n;

  public bool IsPerfectSquare(int x)
  {
    return IsPerfectSquareRec(0, n = x);
  }

  // recursive binary search method
  public bool Sqrt(int start, int end)
  {
    int mid = start + (end - start) / 2; // overflow fix for addition
    long mul = (long) mid * mid;  // overflow fix for multiplication
    if (mul == n)
      return true;

    if (start >= end)
      return false;

    if (mul > n)
      return IsPerfectSquareRec(start, mid - 1);

    return IsPerfectSquareRec(mid + 1, end);
  }
}
