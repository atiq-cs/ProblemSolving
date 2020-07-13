/***************************************************************************************************
* Title : Ugly Number
* URL   : https://leetcode.com/problems/ugly-number/
* Date  : 2015-08-20
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Check if given number is ugly number
* meta  : tag-math, tag-algo-dp, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public bool IsUgly(int num) {
    if (num == 0)
      return false;

    int[] divs = { 2, 3, 5 };
    for (int i = 0; i < 3; i++)
      while (num % divs[i] == 0)
        num /= divs[i];

    return num == 1;
  }
}
