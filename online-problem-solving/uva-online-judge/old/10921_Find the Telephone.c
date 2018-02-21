#include<stdio.h>

void main()
{
	char c;

/*	freopen("input.dat","rt",stdin);*/
	while((c=getchar())!=EOF)
	{
		if (c=='A' || c=='B' || c=='C') c='2';
		if (c=='D' || c=='E' || c=='F') c='3';
		if (c=='G' || c=='H' || c=='I') c='4';
		if (c=='J' || c=='K' || c=='L') c='5';
		if (c=='M' || c=='N' || c=='O') c='6';
		if (c=='P' || c=='Q' || c=='R' || c=='S') c='7';
		if (c=='T' || c=='U' || c=='V') c='8';
		if (c=='W' || c=='X' || c=='Y' || c=='Z') c='9';
		putchar(c);
	}
/*	fclose(stdin);*/
}