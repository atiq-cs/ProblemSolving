/***************************************************************************
* Title : Valid Palindrome II
* URL   : https://leetcode.com/problems/valid-palindrome-ii
* Date  : 2018-05-31
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : if two pointers do not match then try considering removing character
*   on left side. If that does not give valid pal try right side.
* meta  : tag-two-pointers, tag-string-palindrome, tag-leetcode-medium
***************************************************************************/
public class Solution {
  public bool ValidPalindrome(string s) {
    return IsValidPalindrome(s.ToCharArray(), 0, s.Length-1, false);
  }

  public bool IsValidPalindrome(char[] s, int i, int j,
    bool firstMismatch = true) {
    if (i==j)
      return true;
    if (i + 1 == s.Length || j == 0)
      return false;

    for (; i<j; i++, j--) {
      if (s[i] != s[j])
        return firstMismatch? false:
          // second mismatch found hence,
          // skip i-th char, now rest should match from both sides
          IsValidPalindrome(s, i+1, j) ||
          // that did not match (trying from left did not work), hence, try from
          // right skip j-th char, now rest should match from both sides
          IsValidPalindrome(s, i, j-1);
    }
    return true;
  }

  public bool IsValidPalindrome_v1(char[] s, int i, int j,
    bool firstMismatch = false) {
    if (i==j)
      return true;
    
    for (; i<j; i++, j--) {
      if (s[i] != s[j]) {
        if (firstMismatch)
          return false;
        return (i+1<s.Length && IsValidPalindrome_v1(s, i+1, j, true)) || (j>0
          && IsValidPalindrome_v1(s, i, j-1, true));
      }
    }
    return true;
  }
}
/*
abcdadcba
no delete required

abcdadcbaf
delete right

fabcdadcba
delete left

abcdadcbaa
delete right

code to validate palindrome (trivial),

for (int i=0, j=n-1; i<j; i++, j--)
  if (a[i] != a[j])
    return false;
    
simplest solution would be to count frequency on both side and count and find
out if deletion of more than one char is required.

public bool ValidPalindrome(string s) {
  int n = s.Length;
  int[] c = new int[26];
  for (int i=0, j=n-1; i<j; i++, j--) {
    c[s[i]-'a']++;
    c[s[j]-'a']--;
  }
  bool firstDiffFound = false;
  for (int i=0; i<26; i++)
    if (Math.Abs(c[i]) > 1)
      return false;
    else if (Math.Abs(c[i]) == 1) {
      if (firstDiffFound)
        return false;
      else
        firstDiffFound = true;
    }
  return true;
}

abbca

middle pionter is messed up because of 1 additional char

if at a point it does not match,
  we try deleting that char from left or right..
Based on this idea solution above is developed
*/
