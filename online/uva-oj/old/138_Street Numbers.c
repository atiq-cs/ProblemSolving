/***************************************************************************************************
* Title : Street Numbers
* URL   : 138
* Notes : find pair of numbers whose summation of previous numbers is equal to the summation of next
*   numbers upto limit
*   for example,
*   in case of 5 8
*   1 + 2 + 3 + 4 + 5 = 7 + 8
* meta  : tag-algo-dp, tag-math
***************************************************************************************************/
#include<stdio.h>

int main() {
  unsigned t1, t2, a = 6, b = 8, c = 35, d = 49;
  short i;

  for (i = 0; i < 10; i++) {
    printf("%10u%10u\n", a, b);
    t1 = c;
    t2 = d;
    c = c * 6 - a;
    d = d * 6 - b + 2;
    a = t1;
    b = t2;
  }

  return 0;
}
