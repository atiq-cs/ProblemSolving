/***************************************************************************************************
* Title : Primary Arithmetic
* meta  : tag-math, tag-uva-easy
***************************************************************************************************/

#include<stdio.h>

void main() {
  unsigned a, b, c, d;
  unsigned short s, f, mod1, mod2, p;

  while (scanf("%u %u", &c, &d) && (c || d)) {
    f = 0;
    p = 0;

    while (c || d) {
      mod1 = c % 10;
      c /= 10;
      mod2 = d % 10;
      d /= 10;
      s = mod1 + mod2 + p;

      s = s > 9 ? 1 : 0;
      p = s;
      f += s;
    }

    if (f)
      printf("%u", f);
    else
      printf("No");

    printf(" carry operation");

    if (f > 1)
      printf("s");
    printf(".\n");
  }
}
