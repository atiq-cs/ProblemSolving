/***************************************************************************************************
* Title : Palindrome Pairs
* URL   : https://leetcode.com/problems/palindrome-pairs/
* Date  : 2019-02-20
* Occasn: leetcode meetup remote 229 Polaris Ave, Mtn View
* Comp  : O(n^2 * m), O(m)
* Status: Accepted
* Notes : Find pairs of palindromes we can make
*  comp - n = length of words array, m = max length of the string
* ref   : https://leetcode.com/problems/palindrome-pairs/discuss/215269/Very-easy-to-understand-On2
*   -JAVA-Accepted-solution
* meta  : tag-string-palindrome, tag-leetcode-hard
***************************************************************************************************/
public class Solution {
  public IList<IList<int>> PalindromePairs(string[] words) {
    IList<IList<int>> result = new List<IList<int>>();

    for (int i = 0; i < words.Length - 1; i++)
      for (int j = i + 1; j < words.Length; j++) {
        if (IsPalindrome(words[i] + words[j]))
          result.Add(new List<int>(new[] { i, j }));
        if (IsPalindrome(words[j] + words[i]))
          result.Add(new List<int>(new[] { j, i }));
      }

    return result;
  }

  private bool IsPalindrome(string s) {
    for (int i = 0, j = s.Length - 1; i < j; i++, j--)
      if (s[i] != s[j])
        return false;
    return true;
  }
}
