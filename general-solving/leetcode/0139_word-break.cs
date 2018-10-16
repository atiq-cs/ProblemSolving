/***************************************************************************
* Title : Word Break
* URL   : https://leetcode.com/problems/word-break
* Date  : 2018-07-21
* Author: Atiq Rahman
* Occasn: Usama's facebook interview, iBridge slack discussion
* Comp  : O(n*k*w) Time, O(w) space, if we optimize replacing substring that
*   becomes O(1) in space
* Status: Accepted
* Notes : 'DP[i] = true' means that we could form the string using provided
*   word list till index i.
*   Hence, DP[0] is naturally true.
*   TODO, TRIE solution
* meta  : tag-leetcode-medium, tag-algo-dp, tag-company-facebook
***************************************************************************/
public class Solution {
  public bool WordBreak(string s, IList<string> wordDict) {
    bool[] dp = new bool[s.Length];
    dp[0] = true;

    for(int i=0; i<s.Length; i++)
      if (dp[i])
        foreach(string word in wordDict) {
          if (i+word.Length <= s.Length && s.Substring(i, word.Length) == word) {
            if (i+word.Length == s.Length) return true;
            dp[i+len] = true;
          }
        }
    return false;
  }
}
