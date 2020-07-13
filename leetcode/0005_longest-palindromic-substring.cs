/***************************************************************************
* Title : Longest Palindromic Substring
* URL   : https://leetcode.com/problems/longest-palindromic-substring
* Date  : 2018-05-01
* Author: Atiq Rahman
* Comp  : O(N), O(N)
* Status: Accepted
* Notes : Tests my first implementation of Manacher’s Algorithm
*   Add the note for index computation
*
*   rel: https://leetcode.com/problems/palindromic-substrings
*    https://leetcode.com/problems/shortest-palindrome
*
*   ref:
*    https://atiqcs.wordpress.com/2018/05/01/manachers-algo/
*    https://www.hackerrank.com/topics/manachers-algorithm
*    https://en.wikipedia.org/wiki/Longest_palindromic_substring
*    Java impl
*    https://algs4.cs.princeton.edu/53substring/Manacher.java.html
*
*    adding chars, combining as string
*    https://stackoverflow.com/q/1324009/
*    
*    Comment from https://leetcode.com/problems/longest-palindromic-substring/solution/
*    "There is even an O(n)O(n) algorithm called Manacher's algorithm, explained here in detail.
*    However, it is a non-trivial algorithm, and no one expects you to come up with this algorithm
*    in a 45 minutes coding session. But, please go ahead and understand it, I promise it will be
*    a lot of fun."
* meta  : tag-dp-manacher, tag-string-palindrome, tag-two-pointers, tag-leetcode-medium
***************************************************************************/
public class Solution {
  /// <summary>
  /// Compute Array P using Manacher's Algorithm
  /// <remarks>
  /// Linear algo.
  /// </remarks>
  /// </summary>
  /// <param name="s">input string in which to find the palindrome</param>
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
      // check the bound and check equality on both sides
      while (i-(1+P[i])>=0 && i+(1+P[i])<T.Length &&
          T[i+(1+P[i])] == T[i-(1+P[i])])
        P[i]++;

      // Ensure current index is in boundary of last palindrome discovered
      if (i+P[i] > R) {
        C = i;
        R = i+P[i];
      }
    }
    
    // This would be an one-liner if we use linq? Can linq give us index though?
    int maxIndex = 0;
    for(int i=1; i<P.Length; i++) {
      Console.WriteLine(P[i]);
      if (P[i] > P[maxIndex])
        maxIndex = i;
    }
    return s.Substring((maxIndex-P[maxIndex])/2, P[maxIndex]);
  }

  // Adds specified symbol to provided string
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
