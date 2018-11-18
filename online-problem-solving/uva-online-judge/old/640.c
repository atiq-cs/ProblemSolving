/***************************************************************************************************
* Title : Self Numbers
* URL   : 640
* Status: Accepted
* Notes : 
* meta  : tag-math
***************************************************************************************************/
#include<stdio.h>

void main() {
  int i, j, a, lt;
  short sd, md, f;

  for (i = 1; i < 1000001; i++) {
    a = i;
    lt = 0;

    while (a) {
      lt += 9;
      a /= 10;
    }

    lt = i - lt;
    f = 1;

    for (j = i - 1;; j--) {
      a = j;
      sd = 0;

      while (a) {
        md = a % 10;
        sd += md;
        a /= 10;
      }

      if (i == sd + j) {
        f = 0;
        break;
      }

      if (!j || j < lt)
        break;
    }

    if (f)
      printf("%d\n", i);
  }
}
