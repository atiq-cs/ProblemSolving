/***************************************************************************************************
* Title : pig Latin
* meta  : tag-string
***************************************************************************************************/

#include<stdio.h>
#include<ctype.h>


void main() {
  char c, wd[100], vwl[10] = { 'a','e','i','o','u','A','E','I','O','U' };
  short p = 0, i, vf, g = 0;

  while ((c = getchar()) != EOF) {
    if (isalpha(c)) {
      g = 0;
      wd[p++] = c;
    }
    else {
      vf = 0;
      for (i = 0; i < 10; i++)
        if (vwl[i] == wd[0]) {
          vf = 1;
          break;
        }

      if (!vf) {
        wd[p] = wd[0];
        for (i = 0; i < p; i++)
          wd[i] = wd[i + 1];
      }

      wd[p] = 'a';
      wd[p + 1] = 'y';
      wd[p + 2] = NULL;

      if (!g)
        printf("%s", wd);

      p = 0;
      wd[0] = NULL;
      putchar(c);
      g = 1;
    }
  }
}
