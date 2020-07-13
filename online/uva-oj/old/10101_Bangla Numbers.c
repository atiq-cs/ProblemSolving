/***************************************************************************************************
* URL   : 10101
* Status: Accepted
* Notes : Can be generalized in a loop
* meta  : tag-math, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>


void main() {
  unsigned long long n, s;
  unsigned short i = 0, t, f;

  while (scanf("%llu", &n) != EOF) {
    f = 1;
    printf("%4hu.", ++i);
    s = n / 10000000;

    if (n > 99)
      f = 0;

    if (s) {
      t = s / 10000000;
      if (t) {
        printf(" %hu kuti", t); s %= 10000000;
      }
      t = s / 100000;
      if (t) {
        printf(" %hu lakh", t); s %= 100000;
      }
      t = s / 1000;
      if (t) {
        printf(" %hu hajar", t); s %= 1000;
      }
      t = s / 100;
      if (t) {
        printf(" %hu shata", t); s %= 100;
      }
      if (f || s)
        printf(" %llu", s);

      printf(" kuti", t); n %= 10000000;
    }

    t = n / 100000;
    if (t) {
      printf(" %hu lakh", t); n %= 100000;
    }
    t = n / 1000;
    if (t) {
      printf(" %hu hajar", t); n %= 1000;
    }
    t = n / 100;
    if (t) {
      printf(" %hu shata", t); n %= 100;
    }
    if (f || n)
      printf(" %llu", n);
    printf("\n");
  }
}
