/***************************************************************************************************
* Title : Funny Encryption Method
* meta  : tag-math, tag-uva-easy
***************************************************************************************************/

#include<stdio.h>

void main()
{
  int h,cn;
  short n,i,m,b,sb,hx;

  while (scanf("%hd",&n)!=EOF)
  {
    for (i=0;i<n;i++)
    {
      scanf("%hd",&m);
      b=m;
      hx=m;
      sb=0;
      while(b)
      {
        sb+=b%2;
         b/=2;
      }
      cn=1;
      while(hx)
      {
        m=hx%10;
        h+=cn*m;
        cn*=16;
         hx/=10;
      }
      hx=0;
      while(h)
      {
        hx+=h%2;
        h/=2;
      }
      printf("%hd %hd\n",sb,hx);
    }
  }
}
