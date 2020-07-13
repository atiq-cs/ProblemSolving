/***************************************************************************
* Title : Valid Palindrome
* URL   : https://leetcode.com/problems/valid-palindrome
* Date  : 2018-01
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : Compare characters from two sides, omits garbage chars, ignores cases
* meta  : tag-two-pointers, tag-string-palindrome, tag-leetcode-medium
***************************************************************************/
public class Solution
{
  public bool IsPalindrome(string s) {
    for (int i = 0, j = s.Length - 1; i < j;) {
      //ignore garbage chars from left side
      if (char.IsLetterOrDigit(s[i]) == false) { i++; continue; }
      //ignore garbage chars from right side
      if (char.IsLetterOrDigit(s[j]) == false) { j--; continue; }
      // ignore cases
      if (char.ToUpper(s[i]) != char.ToUpper(s[j]))
        return false;
      i++; j--;
    }
    return true;
  }

  public bool IsPalindrome_v1(string s) {
    for (int i = 0, j = s.Length - 1; i < j; i++, j--) {
      //ignore garbage chars from left side
      for (; i < j && !char.IsLetterOrDigit(s[i]); i++) ;
      //ignore garbage chars from right side
      for (; i < j && !char.IsLetterOrDigit(s[j]); j--) ;
      if (i >= j)
        break;
      // ignore cases
      if (char.ToUpper(s[i]) != char.ToUpper(s[j]))
        return false;
    }
    return true;
  }
}
