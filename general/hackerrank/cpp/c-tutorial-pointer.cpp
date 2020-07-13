/***************************************************************************************************
* Title : Functions
* URL   : https://www.hackerrank.com/challenges/c-tutorial-pointer
* Author: Atiq Rahman
* Status: Accepted
* Notes : a should contain sum, b contains absolute difference between them
* meta  : tag-lang-cpp
***************************************************************************************************/
#include <iostream>
#include <cstdlib>  // abs

void update(int *a, int *b) {
  int tmp = *a;
  *a += *b;
  *b = abs(tmp - *b);
}

int main() {
  int a, b;
  int *pa = &a, *pb = &b;

  std::cin >> a >> b;
  update(pa, pb);
  std::cout << a << std::endl << b;

  return 0;
}
