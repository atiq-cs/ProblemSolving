/***************************************************************************************************
* Date  : 2006-05-29
* meta  : tag-math, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>
void main() {
  long long div;

  while (scanf("%lld", &div)) {
    if (div < 0)
      break;

    printf("%lld\n", (div*div + div + 2) / 2);
  }
}
