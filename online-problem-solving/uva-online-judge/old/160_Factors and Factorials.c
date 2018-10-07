/**********************************************************************************************************
  Problem Name:  Factors and Factorials
  Judge Status:  Accepted
  Description:  Has to find out the number of prime factors of a number
      for every factorial number.
**********************************************************************************************************/

#include<stdio.h>

int main()
{
  short n,pr[101]={2},fr[101],i=1,j,en;

  // DP prime generation
  for (j=3;j<=101;j+=2) {
    for (en=0;en<i;en++)
      if (!(j%pr[en])) break;
    if (en==i) pr[i++]=j;
  }
  
  while (scanf("%hd",&n) && n)
  {
    printf("%3hd! =",n);
    for(i=0;pr[i]<=n;i++)
    {
      en=n;
      fr[i]=0;
      while(en)
      {
        en/=pr[i];
        fr[i]+=en;
    /*    printf("en: %d %d\n",en,fr[i]);*/
      }
    }
    for (j=0;j<i;j++)
    {
      if (j>14 && !(j%15)) printf("\n      ");
      printf("%3hd",fr[j]);
      /*printf(": %d %d\n",((j+1)%15),j);*/
    }
    printf("\n");
  }
  return 0;
}
