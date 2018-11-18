/***************************************************************************************************
* URL   : https://uva.onlinejudge.org/external/106/10696.pdf
* Date  : 2006-08-17
* meta  : tag-lang-c, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>

int main() {
  int a, r;

  while (scanf("%d", &a) && a) {
    if (a <= 100)
      r = 91;
    else
      r = a - 10;

    printf("f91(%d) = %d\n", a, r);
  }

  return 0;
}
