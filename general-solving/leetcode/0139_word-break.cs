/***************************************************************************
* Title : Word Break
* URL   : https://leetcode.com/problems/word-break
* Date  : 2018-07-21
* Status: Accepted
* Occasn: Usama's facebook interview, iBridge slack discussion
* Comp  : O(n*k*w) Time, O(w) space, if we optimize replacing substring that
*   becomes O(1) in space
* Notes : Find if given word can be split among given dictionary words
*   Explanation of code,
*   'DP[i] = true' means that we could form the string using provided word list till index i.
*   Base case, DP[0] is naturally true
*   In the beginning dp[i] is false for all other indices
*
*   Termination case, length we just made up equals to length of the string
*
*  Recurrence relation,
*   if dp[i] is true and we have a word matching from the list starting from index i of given word
*   then dp[i+len] is also true where len = length of matched word
*
*   TODO, TRIE solution, TRIE ack: Adnan
* meta  : tag-algo-dp, tag-company-facebook, tag-leetcode-medium
***************************************************************************/
public class Solution {
  public bool WordBreak(string s, IList<string> words) {
    bool[] dp = new bool[s.Length];
    dp[0] = true;

    for(int i=0; i<s.Length; i++)
      if (dp[i])
        foreach(string word in words)
          if (i+word.Length <= s.Length && s.Substring(i, word.Length) == word) {
            if (i+word.Length == s.Length)
              return true;
            dp[i+len] = true;
          }

    return false;
  }
}
