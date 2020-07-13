/***************************************************************************************************
* Title : Binomial Showdown
* meta  : tag-combinations, tag-uva-easy
***************************************************************************************************/

#include<stdio.h>

void main() {
  unsigned long long n, k, i, cn;

  while (scanf("%llu %llu", &n, &k) && (n || k)) {
    cn = 1;
    if (k > n - k)
      k = n - k;

    for (i = 1; i <= k; i++)
      cn = cn * (n - k + i) / i;

    printf("%llu\n", cn);
  }
}
