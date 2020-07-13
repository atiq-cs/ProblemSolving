/***************************************************************************************************
* Title : Pangram
* URL   : http://codeforces.com/problemset/problem/520/A
* Occasn: Codeforces Round #295 (Div. 2)
* Date  : 2015-12-31
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : String is a pangram if all latin letters are present either as upper case of lower case
*   Linear time required to read all letters
* meta  : tag-anagram, tag-string
***************************************************************************************************/
using System;
using System.Collections.Generic;

public class Solution
{
  private static void Main() {
    int length = int.Parse(Console.ReadLine());
    string line = Console.ReadLine();
    int[] freq = new int[26];
    foreach (char ch in line)
      freq[(ch > 'Z' ? ch - 'a' : ch - 'A')]++;
    for (int i = 0; i < 26; i++)
      if (freq[i] == 0)
        Console.WriteLine("NO"); return;
    Console.WriteLine("YES");
  }
}
