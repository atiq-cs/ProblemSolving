/***************************************************************************************************
* Title : Factors and Factorials
* Status: Accepted
* Notes : We have to find out the number of prime factors of a number for every factorial number
* meta  : tag-number-theory, tag-primality
***************************************************************************************************/
#include<stdio.h>

int main() {
  short n, pr[101] = { 2 }, fr[101], i = 1, j, en;

  // DP prime generation
  for (j = 3; j <= 101; j += 2) {
    for (en = 0; en < i; en++)
      if (!(j%pr[en]))
        break;
    if (en == i)
      pr[i++] = j;
  }

  while (scanf("%hd", &n) && n) {
    printf("%3hd! =", n);

    for (i = 0; pr[i] <= n; i++) {
      en = n;
      fr[i] = 0;

      while (en) {
        en /= pr[i];
        fr[i] += en;
      }
    }

    for (j = 0; j < i; j++) {
      if (j > 14 && !(j % 15))
        printf("\n      ");

      printf("%3hd", fr[j]);
    }

    printf("\n");
  }

  return 0;
}
