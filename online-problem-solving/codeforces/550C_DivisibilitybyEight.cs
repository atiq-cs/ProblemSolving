/***************************************************************************************************
* Title : Divisibility by Eight
* URL   : http://codeforces.com/problemset/problem/550/C
* Occasn: Codeforces Round #306 (Div. 2)
* Date  : 2017-09-09
* Comp  : O(n^3) 46ms, Space O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Goal
*   To remove some of the digits (possibly not remove any digit at all) so that the result contains
*   at least one digit, forms a non-negative integer, doesn't have leading zeroes and is divisible
*   by 8. After the removing, it is forbidden to rearrange the digits.
*
*   *Basic Divisibility by Eight*
*   Number composed of last 3 digits must be divisible by 8 However, there can be numbers which are
*   two digits or single digit; this also leaves the avenue for little optimization.
*   
*   n^3 is okay since length of number is maximum 100 digits
* meta  : tag-brute-force, tag-algo-dp, tag-math, tag-easy
***************************************************************************************************/
using System;

public class CFSolution {
  private static void Main() {
    string str = Console.ReadLine().Split()[0]; // explicit first index qualification might not  be required
    int res = GetDivisibilityEight(str);
    Console.WriteLine(res==-1?"NO":"YES\r\n"+res);
  }

  static int GetDivisibilityEight(string num_str) {
  // check single digit
  for (int i = 0; i < num_str.Length; i++) {
    short digit = (short)(num_str[i] - '0');
    if (digit % 8 == 0)
      return digit;
  }

  // check double digits
  for (int i = 0; i < num_str.Length-1; i++)
    for (int j = i+1; j < num_str.Length; j++) {
      short possible_num = (short)((num_str[i] - '0') * 10 + (num_str[j] - '0'));
      if (possible_num % 8 == 0)
        return possible_num;
    }

  // check triple digits
  for (int i = 0; i < num_str.Length - 2; i++)
    for (int j = i + 1; j < num_str.Length-1; j++)
      for (int k = j + 1; k < num_str.Length; k++) {
      short possible_num = (short)((num_str[i] - '0') * 100 + (num_str[j] - '0') * 10 + (num_str[k] - '0'));
      if (possible_num % 8 == 0)
        return possible_num;
    }
    return -1;
  }
}

/* Draft
  1. try single digit 0 or 8
  2. try double digits
    i = 0 to n-2
     j = i+1 to n-1
  3. try 3 digits
    i = 0 to n-3
     j = i+1 to n-2
      k = j+1 to n-1
  return false if here
*/
