/***************************************************************************************************
* Title : Parity
* URL   : 10931
* Notes : 
* meta  : tag-math, tag-number-theory
***************************************************************************************************/
#include<stdio.h>

void main() {
  int n,s;
  short p,i,f;

  while(scanf("%d",&n) && n) {
    f=0;
    s=1073741824;
    printf("The parity of ");
    p=0;

    for (i=0;i<31;i++) {
      if (s&n) {
        f=1;
        putchar('1');
        p++;
      }
      else if (f)
        putchar('0');

      s>>=1;
    }

    printf(" is %hd (mod 2).\n",p);
  }
}
