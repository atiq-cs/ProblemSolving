/***************************************************************************************************
* Title : Conditional Statements
* URL   : https://www.hackerrank.com/challenges/c-tutorial-conditional-if-else
* Date  : May 2015
* Comp  : 
* Author: Atiq Rahman
* Status: Accepted
* Notes : easy problem, cpp warmpup
* meta  : tag-strings, tag-lang-cpp
***************************************************************************************************/

#include <iostream>
#include <vector>
#include <string>

int main() {
  std::string digit_str[] = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
  
  unsigned int n; std::cin >> n;
  if (n >= 1 && n <= 9)
    std::cout << digit_str[n - 1] << std::endl;
  else
    std::cout << "Greater than 9" << std::endl;

  return 0;
}
