/*
	Problem Name: Kibbles `n' Bits `n' Bits `n' Bits
	Algorithm:       Base conversion, hexa inputs and printing in string
*/

#include<stdio.h>

void display_bin(int x);
void main()
{
	int Hex1,Hex2,T,i,res_op;
	char Operator;
	
	scanf("%d",&T);
	
	for(i=0;i<T;i++)
	{
		scanf("%X %c %X",&Hex1,&Operator,&Hex2);
		
		if(Operator=='+')res_op=Hex1+Hex2;
		else res_op=Hex1-Hex2;
		
		display_bin(Hex1);
		printf(" %c ",Operator);
		display_bin(Hex2);
		printf(" = %d\n",res_op);
	}
}

void display_bin(int x)
{
	int c,v=0x1000;
	for(c=0;c<13;c++)
	{
		if(x&v) putchar('1');
		else putchar('0');
		v>>=1;
	}
}