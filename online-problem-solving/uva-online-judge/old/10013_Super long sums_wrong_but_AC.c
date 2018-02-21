/*
	Problem Name	: Super long sums
	Algorithm	: Arithmetic
	Consideration	: Cases like
	4
	4 5
	5 5
	3 2
	2 3
	cannot arise since in problem statement it is clearly stated:
	"Each of the two given integers is not less than 1, and the length of their sum does not exceed M."

	Judge Status:	AC
*/

#include<stdio.h>

int main()
{
	int i,j,n,m,sum,a[1000000][2];

	scanf("%d",&n);
	for (i=0;i<n;i++)
	{
		scanf("%d",&m);
		for (j=0;j<m;j++)
			scanf("%d %d",&a[j][0],&a[j][1]);
		for (j=m-1;j>=0;j--)
		{
			sum=a[j][0]+a[j][1];
			if (sum>=10)
			{
				a[j][0]=sum-10;
				a[j-1][0]=a[j-1][0]+1;
			}
			else a[j][0]=sum;
		}
		for (j=0;j<m;j++)
			printf("%d",a[j][0]);
		printf("\n");
		if (i<n-1) printf("\n");
	}
	return 0;
}
