/***************************************************************************************************
* URL   : https://uva.onlinejudge.org/external/111/11172.pdf
* Date  : 2007-05-31
* meta  : tag-uva-easy
***************************************************************************************************/
#include<stdio.h>

int main() {
  int t, i;
  long long a, b;

  while (scanf("%d", &t) != EOF)
    for (i = 0; i<t; i++) {
      scanf("%lld%lld", &a, &b);

      if (a<b)
        putchar('<');
      else if (a>b)
        putchar('>');
      else
        putchar('=');

      putchar('\n');
    }

  return 0;
}
