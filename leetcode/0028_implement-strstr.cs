/***************************************************************************
* Title : Implement strStr()
* URL   : https://leetcode.com/problems/implement-strstr
* Date  : 2018-01-06
* Author: Atiq Rahman
* Comp  : O(n+m)
* Status: Accepted
* Notes : Also solved in meetup 2018-02-08 (http://collabedit.com/fk87m)
* meta  : tag-string, tag-kmp, tag-leetcode-easy
***************************************************************************/
public class Solution {
  // KMP is at 'algo/string/KMP-String-Matcher.cs' 
  // method signature should be changed and code block inside to return single
  // index instead of a list of indices
  public int StrStr(string haystack, string needle) {
    if (q == needle.Length - 1)
      return i-q;   // single index of match
    // after the loop
    return -1;  // when no match is found
  }
  // Naive String Matcher C.L.R.S, p988, O(n*m)
  public int StrStr(string haystack, string needle) {
    for (int i=0; i <= haystack.Length - needle.Length; i++)
      if (haystack.Substring(i, needle.Length) == needle)
        return i;
    return -1;
  }
}
