/***************************************************************************************************
* Title : Count and Say
* URL   : https://leetcode.com/problems/count-and-say/
* Date  : 2017-08-05
* Comp  : O(n^2)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Easy string operations
* Notes : 
* meta  : tag-string, tag-recursion, tag-leetode-easy
***************************************************************************************************/
public class Solution {
  public string CountAndSay(int n) {
    if (n<1) // to avoid exception in corner cases
      return "0";
    if (n==1)
      return "1";
    if (n==2)
      return "11";
        
    return GetNextCSString(CountAndSay(n - 1));
  }

  public string GetNextCSString(string previous) {
    char ch = (char) 0x7FFF;   // initial value that does not match any char
    var result = new StringBuilder();
    int count = 0;

    for (int i = 0; i < previous.Length; i++) {
      if (ch == previous[i])
        count++;
      else {
        if (i > 0) {
          result.Append((char)('0' + count));
          result.Append(ch);
        }
        ch = previous[i];
        count = 1;
      }
    }

    if (count > 0) {
      result.Append((char)('0' + count));
      result.Append(ch);
    }

    return result.ToString();
  }
}
