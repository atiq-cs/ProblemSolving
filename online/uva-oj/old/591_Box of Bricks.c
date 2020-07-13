/***************************************************************************************************
* Title : Box of Bricks
* Notes : Minimum moves calculation
* meta  : tag-lang-c, tag-uva-easy
***************************************************************************************************/

#include<stdio.h>


void main() {
  unsigned short s, n, h[60], i, t = 0, mv;

  while (scanf("%hu", &n) && n) {
    t++; s = 0;

    for (i = 1; i <= n; i++) {
      scanf("%hu", &h[i]);
      s += h[i];
    }

    s /= n; mv = 0;
    for (i = 1; i <= n; i++)
      if (h[i] > s)
        mv += h[i] - s;

    printf("Set #%hu\nThe minimum number of moves is %hu.\n\n", t, mv);
  }
}
