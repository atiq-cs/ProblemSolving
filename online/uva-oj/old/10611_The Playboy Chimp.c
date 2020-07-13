/***************************************************************************************************
* Title : The PlayBoy Chimp
* Notes : It's Binary search problem with huge data
* meta  : tag-algo-bsearch
***************************************************************************************************/

#include<stdio.h>

void main() {
  unsigned N, lady_heights[50000], Q, i, j, s, l, m, luchu_heights[25000];

  scanf("%u", &N);
  for (i = 0; i < N; i++)
    scanf("%u", &lady_heights[i]);

  scanf("%u", &Q);
  for (i = 0; i < Q; i++)
    scanf("%u", &luchu_heights[i]);

  for (i = 0; i < Q; i++) {
    if (lady_heights[0] >= luchu_heights[i] && lady_heights[N - 1] <=
        luchu_heights[i])
      printf("X X");
    else if (lady_heights[0] > luchu_heights[i])
      printf("X %u", lady_heights[0]);
    else if (lady_heights[N - 1] < luchu_heights[i])
      printf("%u X", lady_heights[N - 1]);
    else if (lady_heights[0] == luchu_heights[i]) {
      for (j = 1; j < N; j++)
        if (lady_heights[j] > luchu_heights[i])
          break;

      printf("X %u", lady_heights[j]);
    }
    else if (lady_heights[N - 1] == luchu_heights[i]) {
      for (j = N - 1; j > 0; j--)
        if (lady_heights[j] < luchu_heights[i])
          break;

      printf("%u X", lady_heights[j]);
    }
    else {
      s = 0;
      l = N - 1;

      while (s <= l) {
        m = (s + l) / 2;

        if (lady_heights[m] == luchu_heights[i])
          break;

        if (lady_heights[m] > luchu_heights[i])
          l = m - 1;
        else
          s = m + 1;
      }

      if (lady_heights[m] == luchu_heights[i]) {

        for (j = m - 1; j > 0; j--)
          if (lady_heights[j] < luchu_heights[i]) break;
        printf("%u", lady_heights[j]);

        for (j = m + 1; j < N; j++)
          if (lady_heights[j] > luchu_heights[i]) break;
        printf(" %u", lady_heights[j]);
      }
      else if (lady_heights[m] < luchu_heights[i]) {
        for (j = m + 1; j < N; j++)
          if (lady_heights[j] > luchu_heights[i]) break;
        printf("%u %u", lady_heights[m], lady_heights[j]);
      }
      else {
        for (j = m - 1; j > 0; j--)
          if (lady_heights[j] < luchu_heights[i])
            break;

        printf("%u %u", lady_heights[j], lady_heights[m]);
      }
    }
    printf("\n");
  }
}
