/***************************************************************************************************
* Title : Marvelous Mazes
* Comp  : O(N)
* meta  : tag-string, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>

int main() {
  char c, t = '\0';
  short fr = 0, i, n = 1;

  while ((c = getchar()) != EOF) {
    if (isdigit(c)) {
      fr += c - '0';
      n = 1;
    }
    else if (c == '\n') {
      if (n && t == '\n') {
        putchar('\n');
        n = 0;
      }

      if (n && t != '!')
        putchar('\n');
      fr = 0;
    }
    else {
      if (c == '!')
        putchar('\n');
      else {
        if (c == 'b')
          c = ' ';

        for (i = 0; i < fr; i++)
          putchar(c);
      }
      fr = 0;
      n = 1;
    }

    t = c;
  }

  return 0;
}
