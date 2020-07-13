/***************************************************************************************************
* Title : Rails
* meta  : tag-ds-stack
***************************************************************************************************/

#include<stdio.h>



void main() {
  int n, i, Compare[1001], Couch[1001], Up, Down, j;

  while (scanf("%d", &n) && n && scanf("%d", &Couch[1])) {
    if (Couch[1]) {
      for (i = 2; i <= n; i++)
        scanf("%d", &Couch[i]);
      Up = 0;
      Down = 1;
      for (i = 1; i <= n; i++) {
        if (Couch[Down] == i) {
          Down++;
          while (Couch[Down] == Compare[Up] && Up > 0) {
            Up--;
            Down++;
          }
        }
        else {
          Up++;
          Compare[Up] = i;
        }
      }

      if (!Up)
        printf("Yes");
      else
        printf("No");

      printf("\n");
    }
    else {
      printf("\n");
      break;
    }
  }
}
