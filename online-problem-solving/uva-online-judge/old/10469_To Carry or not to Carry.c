#include<stdio.h>

void main()
{
	unsigned a,b,c,d;
	while(scanf("%u %u",&a,&b)!=EOF)
	{
		c=a|b;
		d=a&b;
		d=~d;
		c=c&d;
		printf("%u\n",c);
	}
}

