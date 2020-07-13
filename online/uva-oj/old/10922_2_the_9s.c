/***************************************************************************************************
* URL   : https://uva.onlinejudge.org/external/109/10922.pdf
* Date  : 2007-07-15
* meta  : tag-math, tag-divisibility, tag-lang-c
***************************************************************************************************/
#include<stdio.h>
#include<ctype.h>

int main() {
  char dg, t;
  int num = 0, stp, tmp, mod, n = 0;

  while ((dg = getchar())) {
    if (dg == '\n') {
      if (n && t == '0')
        break;

      if ((num % 9))
        printf(" is not a multiple of 9.\n");
      else {
        stp = 1;
        while (num>9) {
          tmp = num;
          num = 0;

          while (tmp) {
            mod = tmp % 10;
            tmp /= 10;
            num += mod;
          }

          stp++;
        }

        printf(" is a multiple of 9 and has 9-degree %d.\n", stp);
      }

      n = 0;
      num = 0;
    }
    else if (isdigit(dg)) {
      if (dg != '0' || t != '\n')
        putchar(dg);

      num += dg - '0';
      if (t == '\n' && dg == '0')
        n = 1;
    }

    t = dg;
  }

  return 0;
}
