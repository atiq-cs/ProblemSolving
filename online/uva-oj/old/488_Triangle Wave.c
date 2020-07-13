/***************************************************************************************************
* Title : Triangle Wave
* Notes : Basic IO in C; only printing cases critical
* meta  : tag-uva-easy, tag-lang-c
***************************************************************************************************/
#include<stdio.h>


void line(int k) {
  for (int l = 1; l <= k; l++)
    printf("%d", k);
  printf("\n");
}

void main() {
  int a, f, i, j, k, l = 1, t;
  scanf("%d", &t);

  for (i = 1; i <= t; i++) {
    scanf("%d %d", &a, &f);

    for (j = 1; j <= f; j++) {
      if (!l)
        printf("\n");

      l = 0;
      for (k = 1; k < a; k++)
        line(k);

      for (k = a; k > 0; k--)
        line(k);
    }
  }
}
