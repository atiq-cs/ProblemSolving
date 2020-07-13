/***************************************************************************
* Title : For Loop
* URL   : https://www.hackerrank.com/challenges/c-tutorial-for-loop
* Date  : May 2015
* Comp  : 
* Author: Atiq Rahman
* Status: Accepted
* Notes : cpp warmpup
* meta  : tag-strings, tag-lang-cpp, tag-easy
***************************************************************************/

#include <iostream>
#include <vector>
#include <string>

int main() {
  std::string digit_str[] = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

  unsigned int a, b; std::cin >> a >> b;
  for (int n = a; n <= b; n++) {
    if (n >= 1 && n <= 9)
      std::cout << digit_str[n - 1] << std::endl;
    else if (n % 2)
      std::cout << "odd" << std::endl;
    else
      std::cout << "even" << std::endl;
  }

  return 0;
}
