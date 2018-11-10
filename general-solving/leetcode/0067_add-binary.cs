/***************************************************************************************************
* Title : Add Binary
* URL   : https://leetcode.com/problems/add-binary/
* Date  : 2015-10
* Comp  : O(m+n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
*   Method#1,
*   Iterate each digit in reverse order and add following grade school adding
*
*   Method#2,
*   for this solution check previous wrong answer submissions
*   reason - inputs are large strings
* meta  : tag-math, tag-string, tag-leetcode-easy
***************************************************************************************************/

public class Solution
{
  public string AddBinary(string a, string b) {
    int i=a.Length-1;
    int j=b.Length-1;
    StringBuilder result = new StringBuilder();
    int c = 0;
    for (;i>=0 || j>=0 || c==1;i--,j--) {
      int nA = i>=0?a[i]-'0':0;
      int nB = j>=0?b[j]-'0':0;
      int r = nA+nB+c;
      if (r>1) {
        r-=2;
        c = 1;
      }
      else
        c = 0;
      result.Append((char)(r+'0'));
    }
    // Copy to char array and reverse
    char[] chResult = new char[result.Length];
    result.CopyTo(0, chResult, 0, chResult.Length);
    Array.Reverse(chResult);
    // remove 0s from the beginning
    // If result contains only zeroes input becomes empty string after TrimStart
    string res = (new String(chResult, 0, chResult.Length)).TrimStart('0');
    return String.IsNullOrEmpty(res)?"0":res;
  }
}
