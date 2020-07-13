/***************************************************************************************************
* Title : Power of Cryptography
* Notes : use of pow function and format specifier
* meta  : tag-math, tag-uva-easy, tag-lang-c
***************************************************************************************************/
#include<stdio.h>
#include<math.h>

void main() {
  long double p, n, k;

  while (scanf("%Lf %Lf", &n, &p) != EOF) {
    k = pow(p, 1 / n);
    printf("%.0Lf\n", k);
  }
}
