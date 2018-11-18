/***************************************************************************************************
* URL   : 10812
* Status: Accepted
* Notes : 
* meta  : tag-math
***************************************************************************************************/
#include<stdio.h>

void main() {
  unsigned t,s,d,a,b;

  while(scanf("%u", &t) != EOF)
    while(t && scanf("%u %u",&s,&d)) {
      if (s<d || (s+d)%2)
        printf("impossible\n");
      else {
        a=(s+d)/2;
        b=(s-d)/2;
        printf("%u %u\n",a,b);
      }

      t--;
    }
}
