#include<stdio.h>

void main()
{
	int a,b,i,t;
	scanf("%d",&t);
	for(i=1;i<=t;i++)
	{
		scanf("%d %d",&a,&b);
		if (!(a%2)) a++;
		if (!(b%2)) b--;
		printf("Case %d: %d\n",i,((b-a)/2+1)*(a+b)/2);
	}
}
