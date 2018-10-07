/*
  Author:  Atiqur Rahman
*/
#include<stdio.h>

void rec_conv(int n);

int main () {
  long long n;
  short ind,res[1000];
  
  while (scanf("%lld",&n) && n>=0) {
    /*ind =0;
    if (n) {
      while(n) {
        res[ind++] = n%3;
        n /= 3;
      }
      while (ind--) printf("%hd",res[ind]);
    }
    else putchar('0');*/
    if (n)
      rec_conv(n);
    else
      putchar('0');

    putchar('\n');
  }

  return 0;
}

int base = 3;

void rec_conv(int n) {
  if (n == 0)
    return;
  int mod = n % base;
  n /= 3;
  rec_conv(n);
  printf("%d", mod);
}
