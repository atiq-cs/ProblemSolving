/***************************************************************************************************
* Title : Roman to Integer
* URL   : https://leetcode.com/problems/roman-to-integer/
* Date  : 2017-08-23
* Comp  : O(n), O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Easy implementation problem
* ref   : http://www.rapidtables.com/convert/number/how-number-to-roman-numerals.htm
* meta  : tag-leetcode-easy, tag-implementation
***************************************************************************************************/
using System;
using System.Collections.Generic;

public class Solution {
  public int RomanToInt(string s) {
    Dictionary<string, int> roman_digits = new Dictionary<string, int>() {
      { "I", 1 },
      { "IV", 4 },
      { "V", 5 },
      { "IX", 9 },
      { "X", 10 },
      { "XL", 40 },
      { "L", 50 },
      { "XC", 90 },
      { "C", 100 },
      { "CD", 400 },
      { "D", 500 },
      { "CM", 900 },
      { "M", 1000 }
    };

    // left to right expression evaluation
    // For every currency equiv found add value
    // Consider,
    // 1. two digit matches need to be processed first
    //  for example, IV before I

    int rValue = 0;
    for (int i=0; i<s.Length; ) {
      if ((i + 1) < s.Length) {
        string keyx = s[i].ToString() + s[i + 1].ToString();
        if (roman_digits.ContainsKey(keyx)) {
          rValue += roman_digits[keyx];
          i += 2;
          continue;
        }
      }

      string key = s[i].ToString();
      if (roman_digits.ContainsKey(key)) {
        rValue += roman_digits[key]; i++;
        continue;
      }
      // else
      //  shouldn't be here..
      return -1;
    }
    return rValue;
  }
}

/*
 Custom test-cases
  "MCMXCVI"
  "MMXII"
  "CM"
  "M"
  "I"
  ""
*/
