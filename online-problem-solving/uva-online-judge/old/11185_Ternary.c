/***************************************************************************************************
* Author: Atiq Rahman
* meta  : tag-base-conversion, tag-math
***************************************************************************************************/
#include<stdio.h>


void rec_conv(int n) {
  static int base = 3;
  if (n == 0)
    return;
  int mod = n % base;
  n /= 3;
  rec_conv(n);
  printf("%d", mod);
}

int main () {
  long long n;
  short ind,res[1000];
  
  while (scanf("%lld", &n) && n>=0) {
    if (n)
      rec_conv(n);
    else
      putchar('0');

    putchar('\n');
  }

  return 0;
}
