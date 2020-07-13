/***************************************************************************************************
* Title : Tree Recovery
* URL   : 10789
* Author: Atiq Rahman
* Status: Accepted
* Notes : Todo, classify the problem properly..
* meta  : tag-number-theory, tag-primality
***************************************************************************************************/
#include<stdio.h>
#include<ctype.h>
#include<string.h>
#include<math.h>

void main() {
  unsigned i;
  short s, t, asc[96], fr[96][2], j, c, tmp, x;
  char ln[10000];

  scanf("%hd%*c", &t);
  for (s = 1; s <= t; s++) {
    printf("Case %hd: ", s);
    for (i = 0; i < 96; i++)
      asc[i] = 0;

    gets(ln);
    x = strlen(ln);

    for (j = 0; j < x; j++)
      if (isalnum(ln[j])) {
        c = ln[j] - 32;
        asc[c]++;
      }

    j = 0;
    for (i = 0; i < 96; i++)
      if (asc[i] > 0) {
        fr[j][1] = asc[i];
        fr[j++][0] = i + 32;
      }


    c = 0;
    for (i = 0; i < j; i++)
      if (fr[i][1] > 1) {
        tmp = sqrt(fr[i][1]);

        for (x = 2; x <= tmp; x++)
          if (!(fr[i][1] % x))
            break;

        if (tmp == x - 1) {
          c = 1;
          printf("%c", fr[i][0]);
        }
      }

    if (!c)
      printf("empty");
    putchar('\n');
  }
}
