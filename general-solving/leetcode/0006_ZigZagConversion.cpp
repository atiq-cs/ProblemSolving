/***************************************************************************************************
* Title : ZigZag Conversion
* URL   : https://leetcode.com/problems/zigzag-conversion/
* Date  : 2015-05-29
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted (beat 99.49%)
* Notes : Problem description is terrible. Look here for clarification,
*   https://leetcode.com/discuss/35640/please-help-understand-question-description-about-pattern
* meta  : tag-string, tag-leetcode-medium
***************************************************************************************************/

class Solution {
public:
  string convert(string s, int numRows) {
    vector<string> zigzag(numRows);
    int k = 0;
    if (numRows>2)
      k = numRows + numRows - 2;
    else
      k = numRows;

    for (int i = 0; i<s.length(); i++) {
      // map the index to output 
      // we have a diagonal
      int index = i%k;
      if (index >= numRows)
        zigzag[k - index] += s[i];
      // we don't have a diagonal
      else
        zigzag[index] += s[i];
    }

    string zigzag_final;
    for (int i = 0; i<numRows; i++)
      zigzag_final += zigzag[i];
    return zigzag_final;
  }
};
