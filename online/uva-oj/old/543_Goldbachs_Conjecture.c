/***************************************************************************************************
* Title : Goldbach's Conjecture
* meta  : tag-number-theory, tag-primality
***************************************************************************************************/

#include<stdio.h>
#include<math.h>

void main() {
  int en,st,i,j,n;
  short p,sq;

  while (scanf("%d",&n) && n) {
    printf("%d = ",n);
    st=3;

    while (1) {
      en=n-st;
      p=0;
      sq=sqrt(en);

      for (i=2;i<=sq;i++)
        if (!(en%i))
          break;

      if (i==sq+1)
        break;

      for (i=3;;i+=2) {
        sq=sqrt(i);

        for (j=2;j<=sq;j++)
          if (!(i%j))
            break;

        if (j==sq+1 && st<i) {
          st=i;
          break;
        }
      }
    }

    printf("%d + %d\n",st,en);
  }
}
