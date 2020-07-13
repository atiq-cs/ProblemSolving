/***************************************************************************************************
* Title : Add Strings
* URL   : https://leetcode.com/problems/add-strings
* Date  : 2018-01
* Author: Atiq Rahman
* Comp  : O(N+M)
* Status: Accepted
* Notes : following my binary addition approach
* rel   : https://leetcode.com/problems/add-binary/
* meta  : tag-math, tag-leetcode-easy
***************************************************************************************************/
class Solution {
private:
  static inline void ltrim(std::string &s) {
    s.erase(s.begin(), std::find_if(s.begin(), s.end(), [](int ch) {
      return ch != '0';
    }));
  }

public:
  string addStrings(string a, string b) {
    int i = a.length() - 1;
    int j = b.length() - 1;
    string result;
    int c = 0;
    for (; i >= 0 || j >= 0 || c == 1; i--, j--) {
      int nA = i >= 0 ? a[i] - '0' : 0;
      int nB = j >= 0 ? b[j] - '0' : 0;
      int r = nA + nB + c;
      if (r >= 10) {    // compare with base
        r -= 10;    // subtract base
        c = 1;
      }
      else
        c = 0;
      result += (char)(r + '0');
    }

    reverse(result.begin(), result.end());
    ltrim(result);
    return result.empty() ? "0" : result;
  }
};
