/***************************************************************************************************
* Title : Train Swapping
* URL   : 299
* Status: Accepted
* Notes : 
* meta  : tag-algo-sort, tag-lang-c
***************************************************************************************************/
#include<stdio.h>

void main() {
  short i,n,l,tc[51],tmp,k,j,p,sw;
  scanf("%hd",&n);

  for (i=0;i<n;i++) {
    scanf("%hd", &l);
    for (j=0; j<l; j++)
      scanf("%hd", &tc[j]);

    sw=0;
    for (p=0;p<j-1;p++)
      for (k=p+1;k<j;k++)
        if (tc[p]>tc[k]) {
          tmp=tc[k];
          tc[k]=tc[p];
          tc[p]=tmp;
          sw++;
        }
    printf("Optimal train swapping takes %hd swaps.\n", sw);
  }
}
