/***************************************************************************************************
* Title : Excel Sheet Column Number
* URL   : https://leetcode.com/problems/excel-sheet-column-number/
* Date  : 2015-10-07
* Comp  : O(n), O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : The problem kinda maps to base 26 conversion problem.
*   Comparing with base 10, this looks like,
*   9 -> 26
*   10 -> 27
*   100 -> 26 ^ 2 + 1
*   1000 -> 26 ^ 3 + 1
*   Where for base on the right side numbers are 0 to 9
*   for this one it's from 1 to 26 instead of 0 to 25.
* meta  : tag-math, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public int TitleToNumber(string s) {
    int sum = 0;
    foreach (char ch in s)
      sum = sum * 26 + (int)(ch - 'A' + 1);
    return sum;
  }
}

/*
Draft,
We know,
Z = 26
AA = 1 + 26
AB = 27
AC = 28
...
...
AZ = 52
BA = 2 * 26 + 1 = 53
...
...
BZ = 2 * 26 + 26 = 78
CA = 3 * 26 + 1
ZA = 26 * 26 + 1

base is 26
first number is 1

A formula can be generalized from above that the number converted from title is
 n = L_(n-1) * Pow(26, n) + .... + L2 * 26 * 26 + L1 * 26 + L0
*/
