/***************************************************************************************************
* Title : Lucky words
* Occasn: Graduate School Programming Contest
* Date  : 2015-09-15
* Notes : A word is lucky if it contains each of the letters of sbu at least once
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* meta  : tag-string, tag-easy
***************************************************************************************************/
#include <iostream>
#include <string>

bool isluckyword(std::string str) {
  bool l1 = false, l2 = false, l3 = false;
  for (auto ch : str) {
    if (ch == 's')
      l1 = true;
    if (ch == 'b')
      l2 = true;
    if (ch == 'u')
      l3 = true;
  }
  int count = (int)l1 + (int)l2 + int(l3);
  return count>2;
}

int main() {
  // Take n input strings and count number of lucky words
  int n; std::cin >> n;
  for (int i = 0; i<n; i++) {
    int l;

    std::cin >> l;
    int count = 0;
    for (int j = 0; j<l; j++) {
      std::string str;
      std::cin >> str;
      if (isluckyword(str))
        count++;
    }
    std::cout << count << std::endl;
  }
  return 0;
}
