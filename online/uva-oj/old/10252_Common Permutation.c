/***************************************************************************************************
* Title : Common Permutation
* meta  : tag-string, tag-hash-table, tag-lang-c, tag-permutation, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>
#include<string.h>

void main() {
  char a[1001], b[1001];
  int i, j, asc[123][2], min;

  for (i = 'a'; i <= 'z'; i++)
    asc[i][0] = asc[i][1] = 0;

  while (gets(a)) {
    gets(b);

    for (i = strlen(a) - 1; i >= 0; i--)
      asc[a[i]][0]++;

    for (i = strlen(b); i >= 0; i--)
      asc[b[i]][1]++;

    for (i = 97; i < 123; i++) {
      min = asc[i][0] < asc[i][1] ? asc[i][0] : asc[i][1];

      for (j = 0; j < min; j++)
        putchar(i);

      asc[i][0] = asc[i][1] = 0;
    }

    putchar('\n');
  }
}
