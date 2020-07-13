/***************************************************************************************************
* Title : Blowing Fuses
* meta  : tag-uva-easy
***************************************************************************************************/

#include<stdio.h>


int main() {
  long n, m, c, i, s, Max;
  int t, power[20], on[20], sequence = 0;

  while (scanf("%ld %ld %ld", &n, &m, &c)) {
    if (!n && !m && !c)
      break;
    sequence++;

    for (i = 0; i < n; i++) {
      on[i] = -1;
      scanf("%d", &power[i]);
    }

    for (i = 0, Max = 0, s = 0; i < m; i++) {
      scanf("%d", &t);
      --t;
      if (s < c) {
        on[t] = -on[t];
        s += power[t] * on[t];
        if (s > Max)
          Max = s;
      }
    }

    printf("Sequence %d\n", sequence);

    if (s > c)
      printf("Fuse was blown.\n");
    else {
      printf("Fuse was not blown.\n");
      printf("Maximal power consumption was %ld amperes.\n", Max);
    }

    printf("\n");
  }

  return 0;
}
