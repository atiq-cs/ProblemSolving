#include<stdio.h>

void main()
{
       int i,a,b,t;
       long c;
       scanf("%d",&t);

       for (i=0;i<t;i++)
       {
         scanf("%d %d",&a,&b);
         c=((int)(a/3))*(int)(b/3);
         printf("%ld\n",c);
       }
}
