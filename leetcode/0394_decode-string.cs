/***************************************************************************
* Title : Decode String
* URL   : https://leetcode.com/problems/decode-string
* Occasn: meetup at DEN
* Date  : 2018-06-23
* Author: Atiq Rahman
* Comp  : O(N), O(N) needs review
* Status: Accepted
* Notes : 
*   TODO, using stack
*   This might replace a few for loops
*    https://msdn.microsoft.com/en-us/library/48z14dbs.aspx
*   Checkout this solution later
*   ref: https://leetcode.com/problems/decode-string/discuss/140904/c++-recursion-with-memorization
*   or this
*   https://leetcode.com/problems/decode-string/discuss/232857/Java-solution-2msbeat-90
* meta  : tag-parsing, tag-leetcode-medium
***************************************************************************/
public class Solution
{
  public string DecodeString(string s) {
    return DecodeString(s.ToCharArray(), 0, s.Length);
  }
  
  private string DecodeString(char[] s, int start, int count) {
    // Expected pattern: string - num - [string ]
    if (start >= s.Length || count < 1)
      return "";
    var sb = new StringBuilder();
    int i = start;
    for (; i < start + count && char.IsDigit(s[i]) == false; i++) ;
    // no num expr/digit found after string, return string
    if (i == start + count)
      return new string(s, start, count);
    // currently i points to where digit/num starts
    int numStart = i;
    sb.Append(new string(s, start, numStart - start));
    // find left parenthesis
    for (i++; i < start + count && s[i] != '['; i++) ;
    // means there is [expr]
    if (i == start + count)
      return sb.ToString();
    int leftParenthPos = i;
    // frequency
    int k = int.Parse(new string(s, numStart, leftParenthPos - numStart));

    // find right parenthesis
    int pCount = 1;
    bool isNested = false;
    for (i++; i < start + count; i++)
      if (s[i] == '[') {
        pCount++;
        isNested = true;
      }
      else if(s[i] == ']')
        if (--pCount == 0)
          break;
    int rightParenthPos = i;
    string token = isNested ? DecodeString(s, leftParenthPos + 1,
      rightParenthPos - leftParenthPos - 1) :
      new string(s, leftParenthPos+1,rightParenthPos - leftParenthPos - 1);
    for (i = 0; i < k; i++)
      sb.Append(token);

    return sb.ToString() + DecodeString(s, rightParenthPos + 1,
      start + count - rightParenthPos - 1); ;
  }
}

/* Draft
initial thoughts
num[token num[token]]

represent this as 
(num, string) pair?
"3[a]2[bc]"
"abc3[d]"
*/
