/***************************************************************************
* Title : String Matching Algorithm - Knuth–Morris–Pratt
* Date  : 2018-06-30 (update)
* Author: Atiq Rahman
* Comp  : O(m+n)
* Status: Demo
* Notes : Build Prefix Table and use the prefix table to find length of the
*   common substring between needle and haystack string.
* 
*   Each index of the prefix table keeps track of the previous index from
*   where it should start matching again when a mismatch is found.
*   
*   Explanation of 'ComputePrefix' method,
*   In summary, steps for each char during iteration,
*   1. Did it match?
*   Revert k back to a previous index.
*   2. Did it match now?
*   Move forward k to next index.
*   3. Set previous of current char's index to where k pointing now
*   
*   Please note that, till a char is matched with first char of the string k
*   is < 0 and first step is never executed. After the first match second step
*   is executed and k is moved forward.
*   
*   For example,
*    we consider the pattern string: "abcabcac"
*     
*   Previous of first index would be,
*     prefix[0] = -1,            'a', k = -1    
*     prefix[1] = -1,            'b'
*     prefix[2] = -1,            'c'
*     prefix[3] =  0,            'a', k = 0
*    This is the first time a match is found with first index; k moves forward.
*    First step, now comes into effect. Because it matches now it goes to
*    second step which moves k forward.
*     prefix[4] = 1,            'b'
*     prefix[5] = 2,            'c'
*     prefix[6] = 3,            'a', k = 3
*    i=7, now 4 and 7 does not match. k reverts back to pf[3] = 0 (points to 'a')
*    still 1 and 7 does not match. k doesn't move forward.
*     prefix[7] = 0
*   
*   'KMPStringMatcher' works similarly. However it does not modify prefix
*   table.
*
* Refs  : KMP on youtube: https://www.youtube.com/watch?v=5i7oKodCRJo 
*   Introduction to Algorithms, C.L.R.S Chapter 32, p#1005
*   https://atiqcs.wordpress.com/2018/04/13/kmp-algo/
* Rel   : https://www.hackerrank.com/challenges/string-similarity
*   More http://a2oj.com/Category.jsp?ID=29
* meta  : tag-string, tag-kmp
***************************************************************************/
public class StringMatcherUtil {
  private int[] ComputePrefix(string needle) {
    int[] pf = new int[needle.Length];

    pf[0] = -1; // first index is initialized
    for (int i = 1, k=-1; i < needle.Length; i++) {
      while (k >= 0 && needle[k + 1] != needle[i])
        k = pf[k];
      if (needle[k + 1] == needle[i])
        k++;
      pf[i] = k;
    }
    return pf;
  }

  public List<int> KMPStringMatcher(string haystack, string needle) {
    var matches = new List<int>();
    if (string.IsNullOrEmpty(needle)) return 0; 
    int[] pf = ComputePrefix(needle);
    for (int i=0, k=-1; i<haystack.Length; i++) {
      while (k >= 0 && needle[k + 1] != haystack[i])
        k = pf[k];
      if (needle[k + 1] == haystack[i])
        k++;
      if (k == needle.Length-1) {   // 1 less since q starts from '-1'
        matches.Add(i-k);
        k = pf[k];
      }
    }
    return matches;
  }
}
