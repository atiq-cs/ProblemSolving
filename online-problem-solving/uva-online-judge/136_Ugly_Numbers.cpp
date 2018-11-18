/***************************************************************************************************
* Title : Ugly Numbers
* URL   : https://uva.onlinejudge.org/external/1/p136.pdf
* Date  : 
* Comp  : O(N^2)
* Author: Atiq Rahman
* Status: Accepted
* Notes : iterate through ugly numbers generated so far to find the next
*   ugly number. This algorithm does not keep track of ugly numbers
*   that were used to find the next ugly number.
*
*   max value of int using C++
*   https://stackoverflow.com/questions/1855459/maximum-value-of-int
*   compile ref: https://ideone.com/F1qZrr
* meta  : tag-algo-dp
***************************************************************************************************/
#include <iostream>
#include <limits>

int main() {
  int i, j;
  int ugly[1500];
  ugly[0] = 1;

  for (i = 1; i < 1500; i++) {
    ugly[i] = std::numeric_limits<int>::max();

    for (j = 0; j < i; j++) {
      if (ugly[j] * 2 > ugly[i - 1]) {
        if (ugly[j] * 2 < ugly[i])
          ugly[i] = ugly[j] * 2;
      }
      else if (ugly[j] * 3 > ugly[i - 1]) {
        if (ugly[j] * 3 < ugly[i])
          ugly[i] = ugly[j] * 3;
      }
      else if (ugly[j] * 5 > ugly[i - 1]) {
        if (ugly[j] * 5 < ugly[i])
          ugly[i] = ugly[j] * 5;
      }
    }
  }

  std::cout << "The 1500'th ugly number is " << ugly[1499] << "." << std::endl;

  return 0;
}
