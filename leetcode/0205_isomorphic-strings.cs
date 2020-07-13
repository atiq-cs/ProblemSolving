/***************************************************************************************************
* Title : Isomorphic Strings
* URL   : https://leetcode.com/problems/isomorphic-strings/
* Date  : 2018-12-31
* Comp  : O(n), O(N)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Takes care of the case that when adding t[i], they do not become duplicate in the mapping...
* meta  : tag-ds-hash-table, tag-leetcode-easy
***************************************************************************************************/
public class Solution {
  public bool IsIsomorphic(string s, string t) {
    if (s.Length != t.Length)
      return false;

    var charDict = new Dictionary<char, char>();
    var charSet = new HashSet<char>();

    for (int i = 0; i < s.Length; i++) {
      var ch = s[i];
      if (charDict.ContainsKey(ch)) {
        if (charDict[ch] != t[i])
          return false;
      }
      else if (charSet.Contains(t[i]))
        return false;
      else {
        charDict.Add(ch, t[i]);
        charSet.Add(t[i]);
      }
    }

    return true;
  }
}
