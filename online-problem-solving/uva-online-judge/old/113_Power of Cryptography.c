/*
  Problem Name: Power of Cryptography
  Algorithm      : use of pow function
*/

#include<stdio.h>
#include<math.h>

void main()
{
  long double p,n,k;

  while (scanf("%Lf %Lf",&n,&p)!=EOF)
  {
    k=pow(p,1/n);
    printf("%.0Lf\n",k);
  }
}
