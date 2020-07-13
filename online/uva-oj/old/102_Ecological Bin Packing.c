/***************************************************************************************************
* Title : Ecological Bin Packing
* Status: Accepted
* meta  : tag-permutation, tag-combination, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>

void main() {
  int B[3], G[3], C[3], Bin[6], min, p, i;

  while (scanf("%d %d %d %d %d %d %d %d %d", &B[0], &G[0], &C[0], &B[1], &G[1], &C[1],
      &B[2], &G[2], &C[2]) != EOF) {
    Bin[5] = C[0] + B[1] + B[2] + G[0] + G[1] + C[2];
    Bin[4] = G[0] + B[1] + C[0] + B[2] + C[1] + G[2];
    Bin[3] = B[0] + C[1] + G[0] + C[2] + G[1] + B[2];
    Bin[2] = B[0] + C[2] + G[0] + C[1] + B[1] + G[2];
    Bin[1] = B[0] + G[1] + C[0] + G[2] + C[1] + B[2];
    Bin[0] = C[0] + G[1] + B[0] + G[2] + B[1] + C[2];
    min = Bin[0], p = 0;

    for (i = 1; i < 6; i++)
      if (min >= Bin[i]) {
        min = Bin[i];
        p = i;
      }

    show_color(p);
    printf(" %d\n", min);
  }
}

void show_color(int s) {
  switch (s) {
    case 0:
      printf("GCB");
      break;
    case 1:
      printf("GBC");
      break;
    case 2:
      printf("CGB");
      break;
    case 3:
      printf("CBG");
      break;
    case 4:
      printf("BGC");
      break;
    case 5:
      printf("BCG");
      break;
    default:
      printf("Error!");
      break;
  }
}
