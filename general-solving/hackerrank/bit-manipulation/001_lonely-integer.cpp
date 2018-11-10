/***************************************************************************************************
* Title : Lonely Integer
* URL   : https://www.hackerrank.com/challenges/lonely-integer
* Date  : 2015-09-07
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : This solution applies if all numbers are given in pairs (or even number of times) except
*   the number we want to find.
*   Indeed a nice trick to find the lonely integer
* ref   : http://www.geeksforgeeks.org/find-the-element-that-appears-once/
*   
* meta  : tag-bit-manip, tag-math
***************************************************************************************************/
using System;

class HKSolution
{
  static int lonelyinteger(int[] a) {
    int res = a[0];
    for (int i = 1; i<a.Length; i++) {
      res ^= a[i];
    }
    return res;
  }
}
