/***************************************************************************************************
* URL   : https://uva.onlinejudge.org/external/3/369.pdf
* Date  : 2007-03-18
* Notes : large result which does not fit in 'long long' type
* meta  : tag-math, tag-combination, tag-lang-c
***************************************************************************************************/
#include<stdio.h>

int main() {
  short int n, m, t;
  long double r, i, j;

  while (scanf("%hd %hd", &n, &m) && (n || m)) {
    t = m>n - m ? m : n - m;
    r = 1;
    for (i = t + 1, j = 1; i <= n; i++, j++)
      r *= i / j;

    printf("%hd things taken %hd at a time is %.0Lf exactly.\n", n, m, r);
  }
  return 0;
}
