/***************************************************************************************************
* Title : C Data Type formatting using printf
* URL   : https://www.hackerrank.com/challenges/c-tutorial-basic-data-types
* Author: Atiq Rahman
* Status: Accepted
* Notes : This problem became rather challenging when I tried to solve it
*   using C++, following are notable finding,
*   Could not make case 1 any shorter than this
* ref   : http://stackoverflow.com/questions/1207762/what-is-c-printf-f-default-precision
*   http://stackoverflow.com/questions/4264127/correct-format-specifier-for-double-in-printf
* meta  : tag-cpp-precision, tag-lang-cpp
***************************************************************************************************/
#include <iostream>
#include <iomanip>

int main() {
  // Input will consists of an int, long, long long, char, float and double, each separated by a space.
  int var_int;
  long var_l;
  long long var_ll;
  char var_char;
  float var_f;
  double var_d;

  while (std::cin >> var_int >> var_l >> var_ll >> var_char >> var_f >> var_d) {
    std::cout << var_int << std::endl << var_l << std::endl << var_ll << std::endl << var_char << std::endl;
    // in seperate line to avoid a bigger line that is difficult to read
    std::cout << std::setprecision(6) << std::fixed << var_f << std::endl << var_d << std::endl;
  }

  return 0;
}
