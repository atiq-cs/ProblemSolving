/***************************************************************************************************
* Title : Palindromic Substrings
* URL   : https://leetcode.com/problems/palindromic-substrings/
* Date  : 2017-10-17
* Comp  : O(n^3), O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Track palandrome for each index
* meta  : tag-algo-dp, tag-string-palindrome, tag-leetcode-easy
***************************************************************************************************/
public class Solution {
  public int CountSubstrings(string s) {
    int[] pLen = new int[s.Length];
    pLen[s.Length-1] = 1;
    for (int i=0; i<s.Length-1; i++) {
      pLen[i] = 1;
      for (int j=i+1; j<s.Length; j++)
        if (IsPalindrome(s.Substring(i, j-i+1)))    // utils.cs
          pLen[i]++;
    }
    return pLen.Sum();
  }
}
