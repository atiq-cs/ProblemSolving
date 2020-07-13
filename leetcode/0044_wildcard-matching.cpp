/***************************************************************************************************
* Title : Wildcard Matching
* URL   : https://leetcode.com/problems/wildcard-matching
* Date  : 2018-01-01
* Author: Atiq Rahman
* Comp  : O(..) [ToDo]
* Status: Partially Solved
* Notes :
* meta  : tag-string, tag-regex, tag-company-cruise-automation, tag-interview
***************************************************************************************************/
class Solution {
public:
  /* TODO: when fails to match have to try other aspects by which it can match
   * For example, daa does not match with d*a right now
  */
  bool isMatch(string str, string wild) {
    // parse wild char string and create list of all separate strings
    char wild_char = '*';
    size_t previousPosition = 0;
    size_t currentPosition = wild.find(wild_char, previousPosition);
    std::vector<std::string> wildCharPartStrings;

    // tokenize using wild char
    do {
      std::string partString = wild.substr(previousPosition, currentPosition -
        previousPosition);
      wildCharPartStrings.push_back(partString);

      // skip a char for wild char
      previousPosition = currentPosition + 1;
      if ((currentPosition = wild.find(wild_char, previousPosition)) ==
        std::string::npos) {
        std::string partString = wild.substr(previousPosition, wild.size() -
          previousPosition);
        wildCharPartStrings.push_back(partString);
      }
    } while (currentPosition != std::string::npos);

    // for each token found using wild char validate if all of them found
    // inside target string
    size_t strSearchPosition = 0;
    for (auto& part : wildCharPartStrings) {
      size_t currentStrSearchPosition = str.find(part, strSearchPosition);
      if (currentStrSearchPosition == std::string::npos)
        return false;
      strSearchPosition = currentStrSearchPosition + part.size();
    }
    return strSearchPosition == str.size();
  }
};

/*
part of original solution, source below,

bool match(std::string str, std::string wild);

int main() {
  bool ret;
  // "dab" "d*a*b"
  ret = match("", "d*a"); // true
  printf("empty string match with d*a is %d\n", (int)ret);
  ret = match("daaba", "d*a*b"); // true
  printf("daba match with d*a*b is %d\n", (int)ret);
  ret = match("data", "d*a*b*c*ecf"); // true
  printf("data match with d*a*b*c*ecf is %d\n", (int)ret);
  ret = match("daabbcceecf", "d*a*b*c*ecf"); // true
  printf("daabbcceecf match with d*a*b*c*ecf is %d\n", (int)ret);
  ret = match("daabbcceecff", "d*a*b*c*ecf"); // true
  printf("daabbcceecf match with d*a*b*c*ecf is %d\n", (int)ret);
  ret = match("data", "d*a"); // true
  printf("data match with d*a is %d\n", (int)ret);
  ret = match("date", "d*a"); // false
  printf("date match with d*a is %d\n", (int)ret);
  ret = match("da",   "d*a"); // true
  printf("da   match with d*a is %d\n", (int)ret);

  return 0;
}
*/
