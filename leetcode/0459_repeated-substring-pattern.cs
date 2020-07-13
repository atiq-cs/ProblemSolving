/***************************************************************************************************
* Title : Repeated Substring Pattern
* URL   : https://leetcode.com/problems/repeated-substring-pattern/
* Date  : 2019-03-19
* Comp  : O(N), O(N)
* Status: Accepted
* Notes : string matching
* rel   : algo/string/KMP-String-Matcher.cs
* meta  : tag-ds-dsf, tag-algo-union-find, tag-ds-core
***************************************************************************************************/
public class Solution {
  public bool RepeatedSubstringPattern(string s) {
    // KMP - Prefix Table Computation is at 'algo/string/KMP-String-Matcher.cs'
    int matchIndex = ComputePrefix(s)[s.Length - 1] + 1;
    return matchIndex > 0 && s.Length % (s.Length - matchIndex) == 0;
  }
}
