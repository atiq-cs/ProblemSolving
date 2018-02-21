/*
	Problem Name: The PlayBoy Chimp
	Description: It's Binary search problem with huge data
*/

#include<stdio.h>

void main()
{
	unsigned N,Lady_Height[50000],Q,i,j,s,l,m,Luchu_Height[25000];

	scanf("%u",&N);
	for (i=0;i<N;i++)
		scanf("%u",&Lady_Height[i]);

	scanf("%u",&Q);
	for (i=0;i<Q;i++)
		scanf("%u",&Luchu_Height[i]);

	for (i=0;i<Q;i++)
	{
		if (Lady_Height[0]>=Luchu_Height[i] && Lady_Height[N-1] <= 
Luchu_Height[i]) printf("X X");
		else if (Lady_Height[0]>Luchu_Height[i]) printf("X %u",Lady_Height[0]);
		else if (Lady_Height[N-1]<Luchu_Height[i]) printf("%u X",Lady_Height[N-1]);
		else if (Lady_Height[0]==Luchu_Height[i])
		{
			for (j=1;j<N;j++)
				if (Lady_Height[j]>Luchu_Height[i]) break;
			printf("X %u",Lady_Height[j]);
		}
		else if(Lady_Height[N-1] == Luchu_Height[i])
		{
			for (j=N-1;j>0;j--)
				if (Lady_Height[j]<Luchu_Height[i]) break;
			printf("%u X",Lady_Height[j]);
		}
		else
		{
			s=0;
			l=N-1;
			while(s<=l)
			{
				m=(s+l)/2;
				if (Lady_Height[m] == Luchu_Height[i]) break;
				if (Lady_Height[m] > Luchu_Height[i]) l=m-1;
				else s=m+1;
			}
			if (Lady_Height[m] == Luchu_Height[i])
			{
				
				for (j=m-1;j>0;j--)
					if (Lady_Height[j]<Luchu_Height[i]) break;
				printf("%u",Lady_Height[j]);
				for (j=m+1;j<N;j++)
					if (Lady_Height[j]>Luchu_Height[i]) break;
				printf(" %u",Lady_Height[j]);
			}
			else if (Lady_Height[m] < Luchu_Height[i])
			{
				for (j=m+1;j<N;j++)
					if (Lady_Height[j]>Luchu_Height[i]) break;
				printf("%u %u",Lady_Height[m],Lady_Height[j]);
			}
			else
			{
				for (j=m-1;j>0;j--)
					if (Lady_Height[j]<Luchu_Height[i]) break;
				printf("%u %u",Lady_Height[j],Lady_Height[m]);
			}
		}
		printf("\n");
	}
}
