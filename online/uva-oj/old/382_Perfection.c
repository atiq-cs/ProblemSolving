/***************************************************************************************************
* Title : Perfection
* Notes : Has to find out prime factors, count them and compare
* meta  : tag-number-theory, tag-primality
***************************************************************************************************/
#include<stdio.h>

void main() {
  unsigned s, n, i;

  printf("PERFECTION OUTPUT\n");

  while (scanf("%u", &n) && n) {
    s = 0;
    printf("%5u  ", n);

    for (i = 2; i <= n / 2; i++)
      if (!(n%i))
        s += i;

    if (n > 1)
      s++;
    if (n > s)
      printf("DEFICIENT");
    else if (n == s)
      printf("PERFECT");
    else
      printf("ABUNDANT");

    printf("\n");
  }

  printf("END OF OUTPUT\n");
}
