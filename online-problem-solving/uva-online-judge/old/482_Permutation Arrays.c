/***************************************************************************************************
* Title : Permutation Arrays
* meta  : tag-algo-sort, tag-algo-greedy, tag-permutation
***************************************************************************************************/

#include<stdio.h>
#include<string.h>

int main() {
  int t, i, j, pos, index[1000];
  const long size = 10000;
  char c, data[10000][15], sort[10000][15];

  scanf("%d", &t);

  for (i = 0; i < t; i++) {
    pos = 0;

    if (i)
      putchar('\n');
    scanf("%d", &index[pos++]);

    while ((c = getchar()) != '\n')
      scanf("%d", &index[pos++]);

    pos = 0;
    scanf("%s", data[pos++]);
    while ((c = getchar()) != '\n')
      scanf("%s", data[pos++]);

    for (j = 0; j < pos; j++)
      strcpy(sort[index[j]], data[j]);

    for (j = 1; j <= pos; j++)
      puts(sort[j]);
  }

  getchar();

  return 0;
}
