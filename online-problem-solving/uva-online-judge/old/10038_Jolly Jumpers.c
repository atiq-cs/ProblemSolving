/***************************************************************************************************
* Title : Jolly Jumpers
* Notes : moved to 'uva-online-judge/10038_JollyJumpers.cpp'
***************************************************************************************************/

#include<stdio.h>

void main() {
  int t, i, n, df, std[3000], cj, tmp;

  while (scanf("%d", &t) != EOF) {
    cj = 0;
    for (i = 0; i < t - 1; i++)
      std[i] = i + 1;

    for (i = 0; i < t; i++) {
      scanf("%d", &n);
      if (i) {
        if (n > tmp)
          df = n - tmp;
        else
          df = tmp - n;
        if (df < t)
          std[df - 1] = 0;
      }
      tmp = n;
    }

    for (i = 0; i < t - 1; i++)
      cj += std[i];

    if (cj)
      printf("Not jolly\n");
    else
      printf("Jolly\n");
  }
}
