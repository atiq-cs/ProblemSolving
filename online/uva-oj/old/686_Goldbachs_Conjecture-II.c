/***************************************************************************************************
* Title : Goldbach's Conjecture (II)
* Notes : pime factors calculation
* meta  : tag-number-theory, tag-primality
***************************************************************************************************/
#include<stdio.h>
#include<math.h>


void main() {
  int en, st, i = 1, j, n, pr[3513] = { 2 };
  short sq, g;

  for (j = 3; j <= 32767; j += 2) {
    for (en = 0; en < i; en++)
      if (!(j%pr[en]))
        break;

    if (en == i)
      pr[i++] = j;
  }

  while (scanf("%d", &n) && n) {
    st = pr[0];
    en = n - st;
    g = 0;
    j = 3512;
    sq = 1;

    while (st <= en) {
      for (i = j; i >= 0; i--)
        if (en == pr[i]) {
          ++g; j = i;
          break;
        }

      st = pr[sq++];
      en = n - st;
    }

    printf("%d\n", g);
  }
}
