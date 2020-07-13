/***************************************************************************
* Title : Integer to Roman
* URL   : https://leetcode.com/problems/integer-to-roman
* Date  : 2018-05-28
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : Basically reverse algo of the problem in link below.
*   sort of similar to Base/currency Conversion
*   I had to reversed the dictionary initializer list following,
*    https://superuser.com/q/331098
* rel   : https://leetcode.com/problems/roman-to-integer/ 
* meta  : tag-array, tag-leetcode-medium
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

public class Solution {
  public string IntToRoman(int n) {
    var romanDenoms = new Dictionary<int, string>() {
      { 1000, "M" },
      { 900, "CM" },
      { 500, "D" },
      { 400, "CD" },
      { 100, "C" },
      { 90, "XC" },
      { 50, "L" },
      { 40, "XL" },
      { 10, "X" },
      { 9, "IX" },
      { 5, "V" },
      { 4, "IV" },
      { 1, "I" }
    };
    StringBuilder sb = new StringBuilder();
    while (n > 0) {
      // optimization possible, remember previous index in the dictionary that
      // matched last time and start from there. However, without that
      // optimization it's still constant time
      foreach (KeyValuePair<int, string> entry in romanDenoms)
        if (n >= entry.Key) {
          n -= entry.Key;
          sb.Append(entry.Value);
          break;
        }
    }
    return sb.ToString();
  }
}

/*
Running Example for  1994
1. 1000 now I have,
M

2. remaining 994
CM = 900
MCM

3. remaining 94
XC = 90
MCMXC

4. remaining 4
MCMXCIV

Test-cases tried,
1994
3
1
2
4
5
6
7
8
9
10
*/
