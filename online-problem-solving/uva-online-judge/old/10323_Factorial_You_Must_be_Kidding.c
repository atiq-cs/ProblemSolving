/***************************************************************************************************
* URL   : 10323
* Notes : 64 bit integer
* meta  : tag-number-theory, tag-primality
***************************************************************************************************/
#include<stdio.h>

void main() {
  long long f;
  int n,i;

  while(scanf("%lld",&n)==1) {
    f=1;

    if (n>=0 && n<=13) {
      for (i=1;i<=n;i++)
        f*=i;

      if (f<10000)
        printf("Underflow!");
      else
        printf("%lld",f);
    }
    else if (n>13)
      printf("Overflow!");
    else
    {
      if (n%2)
        printf("Overflow!");
      else
        printf("Underflow!");
    }

    printf("\n");
  }
}
