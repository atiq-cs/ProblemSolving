/*
  Problem Name: Simple calculations 
  Algorithm      : Series solving with patience
*/

#include<stdio.h>

main () {
  long t,i,n,j;
  long double sum_c,a0,a1,an1,c[100000], eps = 1e-8;

  scanf("%d",&t);
  for (i=0;i<t;i++) {
    scanf("%d %Lf %Lf", &n, &a0, &an1);
    for (j=0;j<n;j++) {
      scanf("%Lf",&c[j]);
    }
    a1 = (n * a0) / (n+1) + an1/ (n+1);
    for (sum_c=0,j=0;j<n;j++) {
      sum_c += (n-j)*c[j];
    }
    sum_c *= 2;
    sum_c /= (n+1);

    sum_c = a1 - sum_c;

    if (i) putchar ('\n');
    printf("%.2Lf\n",sum_c + eps);
  }
  return 0;
}
