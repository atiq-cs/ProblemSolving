/***************************************************************************
* Title : Jolly Jumpers
* URL   : https://uva.onlinejudge.org/external/100/p10038.pdf
* Date  : 2017-10-25 (C++ Port)
* Author: Atiq Rahman
* Comp  : O(n), O(1) space
* Status: Accepted
* Algo  : 
* Notes : Array, hash-table
          ref: https://ideone.com/HlschJ
* meta  : tag-easy, tag-data-structure
***************************************************************************/
#include<iostream>

bool isJolly(int stat[], int t) {
  for (int i = 0; i<t - 1; i++)
    if (stat[i] > 0)
      return false;
  return true;
}

int main() {
  int t;

  while (std::cin >> t) {
    /* A sequence of n > 0 integers is called a jolly jumper if the absolute
    * values of the difference between successive elements take on all the
    * values 1 through n-1 */
    int stat[t - 1];    // status of each number between 1 through n-1
    for (int i = 0; i<t - 1; i++)
      stat[i] = 1;

    int tmp;

    // does not use an additional array, O(1) space complexity
    for (int i = 0; i<t; i++) {
      int n; std::cin >> n;
      if (i>0) {
        int diff = abs(n - tmp);
        if (diff<t)
          stat[diff - 1] = 0;
      }
      tmp = n;
    }

    std::cout << (isJolly(stat, t) ? "Jolly" : "Not jolly") << std::endl;
  }
  return 0;
}
