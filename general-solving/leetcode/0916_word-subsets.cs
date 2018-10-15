/***************************************************************************
* Title : Word Subsets
* URL   : https://leetcode.com/problems/word-subsets
* Date  : 2018-09-28
* Author: Atiq Rahman
* Comp  : O(nA+mB)
* Status: Accepted
* Notes : Build, yet to add..
*   may be check discuss
* rel   : https://leetcode.com/problems/subarray-product-less-than-k
* meta  : tag-hash-table, tag-leetcode-medium, tag-string
***************************************************************************/
public class Solution
{
  int[] charSet = new int[26];
  
  void BuildCharSet(string[] B) {
    foreach(var str in B) {
      var freq = new int[26];
      foreach(var ch in str) {
        freq[ch-'a']++;
        charSet[ch-'a'] = Math.Max(charSet[ch-'a'], freq[ch-'a']);
      }
    }
  }
  
  bool IsUniversal(string str) {
    var freq = new int[26];
    foreach(var ch in str)
      freq[ch-'a']++;
    // for big strings with bigger lengths this has better time comp.
    for (int i=0; i<26; i++)
      if (charSet[i] > freq[i])
        return false;
    return true;
  }

  public IList<string> WordSubsets(string[] A, string[] B) {
    BuildCharSet(B);
    IList<string> result = new List<string>();
    foreach( var str in A) {
      if (IsUniversal(str))
        result.Add(str);
    }
    return result;
  }
}
