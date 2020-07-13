/***************************************************************************************************
* Title : 3n+1 problem
* Date  : 2006-05-29
* Status: Accepted
* Notes : simple brute force, good luck getting AC this way with another lang ;)
* meta  : tag-implementation, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>

int main() {
  int i,j,l,l1,l2,k,m,n,r;

  while((scanf("%d %d",&i,&j))!=EOF) {
    l1=i;
    l2=j;

    if(i>j) {
      r=j;
      j=i;
      i=r;
    }
    m=0;

    for(k=i;k<=j;k++) {
      n=k;
      for(l=1;n!=1;l++)
        if (n%2)
          n=3*n+1;
        else
          n=n/2;

      if(m<l)
        m=l;
    }

    printf("%d %d %d\n",l1,l2,m);
  }

  return 0;
}
