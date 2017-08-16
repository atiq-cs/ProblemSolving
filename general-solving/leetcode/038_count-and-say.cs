/***************************************************************************
* Problem Name: Count and Say
* Problem URL : https://leetcode.com/problems/count-and-say/
* Date        : Aug 5 2017
* Complexity  : O(n^2)
* Author      : Atiq Rahman
* Status      : Accepted
* Desc        : Easy string operations
* Notes       : 
* meta        : tag-string, tag-easy
***************************************************************************/

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
    char ch = (char)0x7FFF;
    StringBuilder current = new StringBuilder();
    int count = 0;

    for (int i = 0; i < previous.Length; i++) {
      if (ch == previous[i])
        count++;
      else {
        if (i > 0) {
          current.Append((char)('0' + count));
          current.Append(ch);
        }
        ch = previous[i];
        count = 1;
      }
    }
    if (count > 0) {
      current.Append((char)('0' + count));
      current.Append(ch);
    }
    return current.ToString();
  }
}
