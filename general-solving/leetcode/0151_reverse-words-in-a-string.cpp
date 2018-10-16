/***************************************************************************
* Title : Reverse Words in a String
* URL   : https://leetcode.com/problems/reverse-words-in-a-string
* Date  : 2018-02-20
* Author: Atiq Rahman
* Comp  : Time O(N), Space O(N)
* Status: Accepted
* Notes : using a new string to store the reversed result
*   a prefered solution is to use O(1) space probably using C programing
*   language
*   As we are allowed to modify passed string we can reverse the whole string
*   in one iteration. In another iteration, we can reverse the words inside it
*   got get the expected result
* meta  : tag-string, tag-company-bloomberg
***************************************************************************/
#include <sstream>
#include <string>
#include <vector>

class Solution {
private:
  std::string trim(const std::string& str, const std::string& whitespace =
    " \t") {
    const auto strBegin = str.find_first_not_of(whitespace);
    if (strBegin == std::string::npos)
      return ""; // no content

    const auto strEnd = str.find_last_not_of(whitespace);
    const auto strRange = strEnd - strBegin + 1;

    return str.substr(strBegin, strRange);
  }

public:
  void reverseWords(string &str) {
    std::istringstream ss(str);
    std::string token, rev;
    char sep = ' ';
    while (std::getline(ss, token, sep))
      if (token.empty() == false && token != " ")
        rev = token + " " + rev;
    str = trim(rev);
  }
};
