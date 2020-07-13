/***************************************************************************************************
* Title : Excel Sheet Column Number
* URL   : https://leetcode.com/problems/excel-sheet-column-number/
* Date  : 2015-10-07
* Comp  : O(n), O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes :
* meta  : tag-math, tag-leetcode-easy
***************************************************************************************************/
class Solution
{
  public int titleToNumber(String s) {
    int number = 0;
    for(int i =0; i<s.length(); i++) {
      // for(var ch : s.toCharArray()) {
      number *= 26;
      number += s.charAt(i) - 'A' + 1;
    }
    return number;
  }

  // optional driver main method
  public static void main(String[] args) {
    System.out.print("result " + new Solution().titleToNumber("AB"));
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
