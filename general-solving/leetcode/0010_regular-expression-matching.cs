/***************************************************************************
* Title : Regular Expression Matching
* URL   : https://leetcode.com/problems/regular-expression-matching
* Date  : 2018-07-10
* Author: Atiq Rahman
* Comp  : O(nm), O(nm)
* Status: Accepted
* Notes : Implement regex matching supporting '.' and '*'
*
*   Index mapping: dp[1][1] maps to index of str at 0 and index of pattern at 0
*   youtube video adds X in the beginning of string and pattern which is not
*   required if initialization is done properly for *
* ref video: https://www.youtube.com/watch?v=l3hda49XcDE
*  Example in the video: a*b.c and aabyc
*
*  ref for initialization part: https://leetcode.com/problems/regular-
*    expression-matching/discuss/5651/Easy-DP-Java-Solution-with-detailed-
*    Explanation
*    
*   https://leetcode.com/articles/regular-expression-matching/
* rel   : https://leetcode.com/problems/wildcard-matching
* meta  : tag-string, tag-algo-dp, tag-backtracking, tag-company-microsoft, tag-leetcode-hard
***************************************************************************/
public class Solution {
  public bool IsMatch(string s, string p) {
    // Memory Allocation
    bool[][] dp = new bool[p.Length + 1][];
    for (int i=0; i<=p.Length; i++)
      dp[i] = new bool[s.Length+1];

    // Initialization
    // Compiler initialized rest of the array
    // set true for patterns like a*b*
    for (int i=1; i<=p.Length; i++)
      if (p[i-1] == '*' && dp[i-2][0])
        dp[i][0] = true;

    for (int i=1; i<=p.Length; i++)
      for (int j=1; j<=s.Length; j++) {
        if (p[i-1] == '*') {
          // was there match till prev pattern char
          if (i>1 && dp[i-2][j])
            dp[i][j] = dp[i-2][j];
          // this char matches prev pattern char and that we have a * at current pattern char,
          // propagate result
          else if (s[j-1] == p[i-2] || p[i-2] == '.')
            dp[i][j] = dp[i][j-1];
        }
        // for example, a.b, abb
        // here we have at last index b = b, get result from prev index
        else if (p[i-1] == s[j-1] || p[i-1] == '.')
          dp[i][j] = dp[i-1][j-1];
      }
      return dp[p.Length][s.Length];
  }
}

/*
when result array is not intialized for * this will fail,
"aa"
"a*"
*/
