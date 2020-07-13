/***************************************************************************
* Title : Group Anagrams
* URL   : https://leetcode.com/problems/group-anagrams
* Date  : 2018-04
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : ToDo: check npp if found
* meta  : tag-leetcode-medium, tag-hash-table
***************************************************************************/
public class Solution {
  public IList<IList<string>> GroupAnagrams(string[] strs) {
    var dict = new Dictionary<string, IList<string>>();

    foreach (string str in strs) {
      char[] chars = str.ToCharArray();
      // can be replaced with linear counting sort
      Array.Sort(chars);
      string key = new string(chars);
      if (dict.ContainsKey(key) == false)
        dict.Add(key, new List<string>());
      dict[key].Add(str);
    }

    /* IList<IList<string>> groups = new List<IList<string>>();
    foreach(var entry in dict)
      groups.Add(entry.Value.ToList());

     one liner below,  
    */
    return new List<IList<string>>(dict.Values);
  }
}
