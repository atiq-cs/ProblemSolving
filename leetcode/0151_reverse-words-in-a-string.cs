/***************************************************************************************************
* Title : Reverse Words in a String
* URL   : https://leetcode.com/problems/reverse-words-in-a-string/
* Date  : 2015-09-29
* Author: Atiq Rahman
* Status: Accepted
* Comp  : O(n) considering Array.Reverse (confirm)
* Notes : Look after source code for detail analysis of the solution
*   Bloomberg LP has an interesting variation I think.
* meta  : tag-string, tag-company-bloomberg, tag-leetcode-medium
***************************************************************************************************/
using System.Linq;

public class Solution
{
  /// <summary>
  /// Simply returning
  ///  string.Join(' ', tokens).Trim()
  /// does not work since there are emtpy strings in tokens or contains whitespaces only
  /// Hence, utilize linq to weed out empty strings
  /// </summary>
  /// <param name="s"></param>
  /// <returns> word reversed string with unnecessary spaces removed </returns>
  public string ReverseWords(string s) {
    string[] tokens= s.Split(' ');
    Array.Reverse(tokens);
    return string.Join(' ', tokens.Where(token => !string.IsNullOrEmpty(token)));
  }
}

/* First version,
  StringBuilder result = new StringBuilder();
    
  foreach (var str in tokens)
    if (str.Length != 0)
      result.Append(str+" ");

  return result.ToString().TrimEnd(' ');   
*/
