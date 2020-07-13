/***************************************************************************************************
* Title : What's Cryptanalysis?
* meta  : tag-algo-sort, tag-string
***************************************************************************************************/

#include<stdio.h>
#include<ctype.h>
#include<string.h>

void main() {
  unsigned n, i, len;
  short asc[96], fr[96][2], j, c, tmp;
  char ln[10000];
  scanf("%u%*c", &n);

  for (i = 0; i < 96; i++)
    asc[i] = 0;

  for (i = 0; i < n; i++) {
    gets(ln);
    len = strlen(ln);
    for (j = 0; j < len; j++) {
      if (isupper(ln[j])) {
        c = ln[j] - 32;
        asc[c]++;
      }
      else if (islower(ln[j])) {
        c = ln[j] - 64;
        asc[c]++;
      }
    }
  }

  j = 0;
  for (i = 0; i < 96; i++) {
    if (asc[i] > 0) {
      fr[j][1] = asc[i];
      fr[j++][0] = i + 32;
    }
  }
  for (i = 0; i < j - 1; i++)
    for (c = i + 1; c < j; c++)
      if (fr[i][1] < fr[c][1]) {
        tmp = fr[i][1];
        fr[i][1] = fr[c][1];
        fr[c][1] = tmp;
        tmp = fr[i][0];
        fr[i][0] = fr[c][0];
        fr[c][0] = tmp;
      }
      else if (fr[i][1] == fr[c][1] && fr[i][0] > fr[c][0]) {
        tmp = fr[i][1];
        fr[i][1] = fr[c][1];
        fr[c][1] = tmp;
        tmp = fr[i][0];
        fr[i][0] = fr[c][0];
        fr[c][0] = tmp;
      }

  for (i = 0; i < j; i++)
    printf("%c %hd\n", fr[i][0], fr[i][1]);
}
