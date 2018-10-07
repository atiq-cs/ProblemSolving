/*
  Problem Name: The Department of Redundancy
  Algorithm : Linear Searching and counting
*/

#include<stdio.h>

main() {
  int n,stk[100000],fr[100000],ind=0,i;

  for (i=0;i<100000;i++) fr[i] = 1;
  while (scanf("%d",&n)!=EOF) {
    for (i=0;i<ind;i++) {
      if (n==stk[i]) {
        fr[i]++;
        break;
      }
    }
    if (i == ind) stk[ind++] = n;
  }
  for (i=0;i<ind;i++) {
    printf("%d %d\n",stk[i],fr[i]);
  }
  return 0;
}
