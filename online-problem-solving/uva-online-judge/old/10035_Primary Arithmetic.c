/*
	Problem Name: Primary Arithmetic
	Algorithm      : Native
*/

#include<stdio.h>

void main()
{
	unsigned a,b,c,d;
	unsigned short s,f,mod1,mod2,p;
	while (scanf("%u %u",&c,&d) && (c || d))
	{
		f=0;
		p=0;
		while (c || d)
		{
			mod1=c%10;
			c/=10;
			mod2=d%10;
			d/=10;
			s=mod1+mod2+p;
			if (s>9) s=1;
			else s=0;
			p=s;
			f+=s;
		}
		if (!f) printf("No");
		else printf("%u",f);
		printf(" carry operation");
		if (f>1) printf("s");
		printf(".\n");
	}
}