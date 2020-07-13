/***************************************************************************************************
* Title : Longest Substring Without Repeating Characters
* URL   : https://leetcode.com/problems/longest-substring-without-repeating-characters
* Date  : 2018-03-18
* Author: Atiq Rahman
* Comp  : see below for each version
* Status: Accepted
* Notes : Naive version,
*   Maintain boolean flags for 128 chars. Every time during the iteration if a
*   repeatation is found update max length, unset boolean array and start
*   afresh.
*   
*   First version,
*   Naive version fails when the max length string before the repeation index,
*   for example, "dvdf" instead of length being "df" it's "vdf".
*   
*   This test-case give us a hint that we should start back from the index (+1)
*   where this character appeared first when we found the repeatation of it.
*   Therefore, we maintain an array of each char to record in which index it
*   appeared previously. We use that index restart the iteration right from
*   there. For example, for "dvdf", the iteration starts back from index 1
*   instead of index 1.
*   We also unset all previous occurrence indices to 0; 0 = unused
*   Because, we start back right after the previous index it leads to a time
*   complexity of O(n^2) considering worst case. Example, "abcdabcd"
*   
*   Second version,
*   We don't need to unset all indices every time we hit a repeatation.
*   Instead we keep track of the last index where a repeatation was found.
*   We find the length subtracting last index from current index.
* meta  : tag-hash-table, tag-algo-dp, tag-leetcode-easy
***************************************************************************************************/
// Version 1: Time O(n*n); Constant Space exactly 128 extra space though
public class LeetcodeSolutionV1 {
  public int LengthOfLongestSubstring(string s) {
    int longestLength = 0;
    int length = 0;
    int[] prevOccurrence = new int[128];

    for(int i=0; i<s.Length; i++) {
      char ch = s[i];
      if (prevOccurrence[ch]>0) { // non-zero means used
        i = prevOccurrence[ch]-1;
        SetCharsUnused(prevOccurrence);

        if (longestLength < length)
          longestLength = length;
        length = 0;
      }
      else {
        length++;
        prevOccurrence[ch] = i+1;   // +1, to use 0 as flag..
      }
    }
    return Math.Max(longestLength, length);
  }
  
  // 0 to mean unused
  // Complexity: O(128) =~ O(1)
  private void SetCharsUnused(int[] prevOccurrence) {
    for(int i=0; i<prevOccurrence.Length; i++)
      prevOccurrence[i] = 0;
  }
}

// O(N), O(1) DP Solution
public class LeetcodeSolutionV2 {
  public int LengthOfLongestSubstring(string s) {
    int maxLength = 0;
    int[] prevOccurrence = new int[128];
    int i=0, j=0;

    for(; i<s.Length; i++) {
      char ch = s[i];
      if (prevOccurrence[ch]>0)
        j = prevOccurrence[ch]-1;
      if (maxLength < i-j)
        maxLength = i - j;
      prevOccurrence[ch] = i+1;
    }
    return maxLength;
  }
}

/*
inputs to consider,
abcabcbb
abc

""
"c"
"dvdf"
"aabcd"
"abcabcd"
"abcdabc"
"abcabcbb"
*/
