// Title: Peter's Smokes
#include<stdio.h>

void main()
{
  int a,b,r;
  while(scanf("%d %d",&a,&b)!=EOF)
  {
    r=a+(a-1)/(b-1);
    printf("%d\n",r);
  }
}
