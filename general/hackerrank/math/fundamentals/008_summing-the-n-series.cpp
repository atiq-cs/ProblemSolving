/***************************************************************************************************
* Title : Summing the N series
* URL   : https://www.hackerrank.com/challenges/summing-the-n-series
* Author: Atiq Rahman
* Status: Accepted
* Notes : Apply big mod technique
* meta  : tag-big-mod, tag-math
***************************************************************************************************/
#include <iostream>

int main() {
  unsigned long long n;
  unsigned long long cp = 1000000007;
  unsigned long long res = 0;

  int testcase; std::cin >> testcase;

  while (testcase--) {
    std::cin >> n;
    res = (n % cp) * (n % cp) % cp;
    std::cout << res << std::endl;
  }
  return 0;
}
