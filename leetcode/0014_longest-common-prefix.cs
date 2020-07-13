/***************************************************************************
* Title : Longest Common Prefix
* URL   : https://leetcode.com/problems/longest-common-prefix
* Date  : 2017-12
* Author: Atiq Rahman
* Comp  : O(nm)
* Status: Accepted
* Notes : brute force compare chars from beginning of each string
* meta  : tag-string, tag-leetcode-easy
***************************************************************************/
public class Solution
{
  public string LongestCommonPrefix(string[] strs) {
    if (strs.Length == 0)
      return "";
    int j = 0;
    for (; j < strs[0].Length; j++) {
      char ch = strs[0][j];
      int i = 1;
      for (; i < strs.Length; i++) {
        if (j >= strs[i].Length || strs[i][j] != ch)
          break;
      }
      if (i < strs.Length)
        break;
    }
    return strs[0].Substring(0, j);
  }
}
