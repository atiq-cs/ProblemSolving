/*
 * Date: 2006-05-29
 * meta: tag-easy, tag-math
 */
#include<stdio.h>

main() {
  int a,i,j,s,C,N,g[2000];
  float k;

  scanf("%d",&C);
  for(i=1;i<=C;i++) {
    scanf("%d",&N);
    s=0;

    for(j=1;j<=N;j++) {
      scanf("%d",&g[j]);
      s=s+g[j];
    }

    a=(int)(s/N);k=0;
    for (j=1;j<=N;j++)
    if (g[j]>a)
      k++;

    printf("%2.3f%\n",(float)((k*100)/N));
  }
  return 0;
}
