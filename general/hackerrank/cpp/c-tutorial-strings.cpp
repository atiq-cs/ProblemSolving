/***************************************************************************************************
* Title : Strings
* URL   : https://www.hackerrank.com/challenges/c-tutorial-strings
* Author: Atiq Rahman
* Status: Accepted
* Notes : Safety check on line 23 is recommended, whether any of the strings in empty
* meta  : tag-string, tag-lang-cpp
***************************************************************************************************/
#include <iostream>
#include <string>

int main() {
  std::string a, b;
  std::cin >> a >> b;

  std::cout << a.length() << " " << b.length() << std::endl;
  std::cout << a + b << std::endl;

  std::swap(a[0], b[0]);
  std::cout << a << " " << b << std::endl;

  return 0;
}
