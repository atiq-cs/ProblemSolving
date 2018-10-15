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
public class Solution
{
  public string ReverseWords(string s) {
    string[] tokens= s.Split(' ');
    Array.Reverse(tokens);
    StringBuilder result = new StringBuilder();
    
    foreach (var str in tokens)
      if (str.Length != 0)
        result.Append(str+" ");
    
    return result.ToString().TrimEnd(' ');
  }
}
