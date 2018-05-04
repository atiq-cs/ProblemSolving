/***************************************************************************
* Title : Longest Palindromic Substring
* URL   : https://leetcode.com/problems/longest-palindromic-substring
* Date  : 2018-05-01
* Author: Atiq Rahman
* Comp  : O(N), O(N)
* Status: Accepted
* Notes : Tests my first implementation of Manacher’s Algorithm
*
*   rel: https://leetcode.com/problems/palindromic-substrings
*    https://leetcode.com/problems/shortest-palindrome
*   
*   ref:
*    https://atiqcs.wordpress.com/2018/05/01/manachers-algo/
*    https://www.hackerrank.com/topics/manachers-algorithm
*    https://en.wikipedia.org/wiki/Longest_palindromic_substring
* meta  : tag-dp, tag-leetcode-medium
***************************************************************************/
public class Solution {
  public string LongestPalindrome(string s) {
    string T = AddPoundsToString(s);

    int C=0, R=0;
    int[] P= new int[T.Length];
    P[0] = 0;
    for(int i=1; i<T.Length-1; i++) {
      int iPrime = C*2-i;   // i′ is mirrored index of i
      // Ensure index is in boundary of previously discovered palindrome
      if (i<R)
        // Update P[i] based on previous values
        P[i] = Math.Min(P[iPrime], R-i);
      // Possibly extend current palindrome
      while (i-(1+P[i])>=0 && i+(1+P[i])<T.Length &&
        T[i+(1+P[i])] == T[i-(1+P[i])])
        P[i]++;

      // Ensure current index is in boundary of last palindrome discovered
      if (i+P[i] > R) {
        C = i;
        R = i+P[i];
      }
    }
    
    int mIndex = 0;
    for(int i=1; i<P.Length; i++) {
      Console.WriteLine(P[i]);
      if (P[i] > P[mIndex])
        mIndex = i;
    }
    return s.Substring((mIndex-P[mIndex])/2, P[mIndex]);
  }

  // Adds specified symbol to provided to string
  private string AddPoundsToString(string s) {
    const char intervalSign = '#';
    StringBuilder sb = new StringBuilder(new string(new char[] { intervalSign }));
    foreach(char ch in s) {
      sb.Append(ch);
      sb.Append(intervalSign);
    }
    return sb.ToString();
  }
}
