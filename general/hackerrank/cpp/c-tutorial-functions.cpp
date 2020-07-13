/***************************************************************************************************
* Title : Functions
* URL   : https://www.hackerrank.com/challenges/c-tutorial-functions
* Author: Atiq Rahman
* Status: Accepted
* meta  : tag-lang-cpp
***************************************************************************************************/
#include <iostream>
#include <algorithm>

int max_of_four(int a, int b, int c, int d) {
  int max1 = std::max(a, b);
  int max2 = std::max(c, d);
  return std::max(max1, max2);
}

int main() {
  int a, b, c, d;
  std::cin >> a >> b >> c >> d;
  int ans = max_of_four(a, b, c, d);
  std::cout << ans << std::endl;

  return 0;
}
