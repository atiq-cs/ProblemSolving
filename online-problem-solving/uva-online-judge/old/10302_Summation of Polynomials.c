#include<stdio.h>

void main()
{
	unsigned long long s;
	while(scanf("%llu",&s)!=EOF)
	{
		s=s*(s+1)/2;
		s*=s;
		printf("%llu\n",s);
	}
}
