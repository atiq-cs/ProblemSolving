/***************************************************************************
* Title : Implement strStr()
* URL   : https://leetcode.com/problems/implement-strstr
* Date  : 2018-01-06
* Author: Atiq Rahman
* Comp  : O(n*m)
* Status: Accepted
* Notes : for each index in source string check if the substring from that
*   index matches with the needle
* meta  : tag-easy, tag-string
***************************************************************************/
public class Solution {
  public int StrStr(string haystack, string needle) {
    for (int i=0; i <= haystack.Length - needle.Length; i++)
      if (haystack.Substring(i, needle.Length) == needle)
        return i;
    return -1;
  }
}
