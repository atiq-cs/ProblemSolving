/***************************************************************************
* Title : Valid Palindrome II
* URL   : https://leetcode.com/problems/valid-palindrome-ii
* Date  : 2018-05-31
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : if two pointers do not match then try considering removing character
*   on left side. If that does not give valid pal try right side.
* meta  : tag-two-pointers, tag-leetcode-medium, tag-palindrome
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
        return firstMismatch? false: IsValidPalindrome(s, i+1, j) ||
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
        return (i+1<s.Length && IsValidPalindrome(s, i+1, j, true)) || (j>0 &&
          IsValidPalindrome(s, i, j-1, true));
      }
    }
    return true;
  }
}
