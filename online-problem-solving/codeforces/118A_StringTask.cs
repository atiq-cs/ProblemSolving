/***************************************************************************************************
* Title : String Task
* URL   : http://codeforces.com/contest/118/problem/A
* Occasn: Codeforces Beta Round #89 (Div. 2)
* Date  : 2017-09-10
* Comp  : O(n) 124ms, Space O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : String manipulation
* meta  : tag-string, tag-easy, tag-implementation
***************************************************************************************************/
using System;
using System.Text;

class Solution {
  static void Main(String[] args) {
    string str = Console.ReadLine();
    Console.WriteLine(ConvertStringCustom(str));
  }
  
  // Too easy using additional space
  public static string ConvertStringCustom(string input) {
    StringBuilder result = new StringBuilder();
    char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };

    foreach (char ch in input) {
      bool isVowel = false;
      foreach (char vowel in vowels)
        if (ch == vowel) { isVowel = true; break; }
      if (isVowel) continue;
      result.Append('.');
      result.Append(Char.ToLower(ch));
    }
    return result.ToString();
  }
}

/*
Input: xnhcigytnqcmy
From this one I found that y is also vowel in this problem
*/
