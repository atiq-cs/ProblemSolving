/***************************************************************************
* Problem Name: Palindromic Substrings
* Problem URL : https://leetcode.com/problems/palindromic-substrings/
* Date        : Oct 17 2017
* Complexity  : O(n^3) Time, O(n) space
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Track palandrome for each index
* meta        : tag-dynamic-programming, tag-easy
***************************************************************************/
public class Solution {
  public int CountSubstrings(string s) {
    int[] pLen = new int[s.Length];
    pLen[s.Length-1] = 1;
    for (int i=0; i<s.Length-1; i++) {
      pLen[i] = 1;
      for (int j=i+1; j<s.Length; j++)
        if (IsPalindrome(s.Substring(i, j-i+1)))
          pLen[i]++;
    }
    return pLen.Sum();
  }
  
  private bool IsPalindrome(string s) {
    for (int i=0, j=s.Length-1; i<s.Length/2; i++,j--)
      if (s[i] != s[j])
        return false;
    return true;
  }
}
