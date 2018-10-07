#include<stdio.h>

void main()
{
  int v,t;
  while(scanf("%d %d",&v,&t)!=EOF)
  {
    t=v*t*2;
    printf("%d\n",t);
  }
}
