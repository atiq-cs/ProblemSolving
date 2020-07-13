/***************************************************************************************************
* URL   : 10293
* Notes : 
* meta  : tag-string, tag-lang-c
***************************************************************************************************/
#include<stdio.h>
#include<string.h>
#include<ctype.h>


int main() {
  int fr[32][2], pos = 0, i, size = 32, ln, f = 0, f1 = 0;
  char c, wd[50];

  for (i = 0; i < size; i++) {
    fr[i][0] = 0;
    fr[i][1] = 0;
  }

  while ((c = getchar()) != EOF) {
    if (c == '#') {
      wd[pos] = NULL;
      ln = strlen(wd);
      fr[ln][0]++;
      fr[ln][1] = 1;

      for (i = 1; i < size; i++) if (fr[i][1])
        printf("%d %d\n", i, fr[i][0]);
      putchar('\n');

      pos = 0;
      wd[pos] = NULL;

      for (i = 0; i < size; i++) {
        fr[i][0] = 0;
        fr[i][1] = 0;
      }

      f = 0;
      f1 = 0;
    }
    else if (isalpha(c)) {
      if (f1) {
        wd[pos] = NULL;
        ln = strlen(wd);
        fr[ln][0]++;
        fr[ln][1] = 1;

        pos = 0;
        wd[pos++] = c;
        f1 = 0;
      }
      else
        wd[pos++] = c;

      if (f)
        f = 0;
    }
    else if (c == '\'');
    else if (c == '-') f = 1;
    else if (c == '\n') {
      if (f)
        f = 0;
      else
        f1 = 1;
    }
    else
      f1 = 1;
  }
  return 0;
}
