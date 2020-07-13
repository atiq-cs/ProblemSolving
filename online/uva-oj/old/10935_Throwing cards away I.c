/***************************************************************************************************
* Title : Throwing cards away
* URL   : 10935
* Notes : 
* meta  : tag-implementation, tag-ds-queue
***************************************************************************************************/
#include<stdio.h>

int main() {
  int n, thrn[51], card[52], cut, rn, i, indt;

  while (scanf("%d",&n) && n) {
    for (i=1; i<51; i++)
      card[i] = i;

    i=0;
    cut = 0;
    card[0] = 1;
    indt=0;
    rn =n;

    while (1) {
      if (card[i]) {
        if (cut) {
          thrn[indt++] = card[i];
          card[i] = 0;
          cut = 0;
          rn--;
        }
        else {
          if (rn==1)
            break;

          cut=1;
        }
      }

      if (i==n)
        i=1;
      i++;
    }

    for (printf("Discarded cards:"),rn=0; rn<indt; rn++) {
      if (rn && rn<indt)
        putchar(',');

      printf(" %d", thrn[rn]);
    }

    printf("\nRemaining card: %d\n", card[i]);
  }

  return 0;
}
