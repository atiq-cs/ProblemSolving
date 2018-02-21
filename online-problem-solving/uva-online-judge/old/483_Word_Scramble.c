/*
 * URL : https://uva.onlinejudge.org/external/4/483.pdf
 * Date: 2007-03-18
 * Note: Iterates and prints the reverse of the string whenever a delimeter is
 *   encountered. An ANSI C solution.
 * meta: tag-string
 */
#include<stdio.h>

int main() {
  char c, wd[50];
  short pos = 0, i;

  while ((c = getchar()) != EOF) {
    if (c == ' ' || c == '\n') {
      for (i = pos - 1; i >= 0; --i)
        putchar(wd[i]);
      pos = 0;
      putchar(c);
    }
    else
      wd[pos++] = c;
  }
  return 0;
}
