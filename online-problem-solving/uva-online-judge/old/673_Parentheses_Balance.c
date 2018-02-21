/*
 * URL : https://uva.onlinejudge.org/external/6/673.pdf
 * Date: 2007-03-19
 * Note: Iterates and checks for imbalance each time
 *   ANSI C program
 * meta: tag-parentheses
 */
#include<stdio.h>

int main() {
  char c, t;
  short first = 0, second = 0, f;
  unsigned i, n;

  scanf("%u%*c", &n);

  for (i = 0; i<n; i++) {
    f = 0;
    t = 0;
    while ((c = getchar()) != '\n') {
      if (!f)
        if ((t == '(' && c == ']') || (t == '[' && c == ')'))
          f = 1;
      if (c == '(')
        first++;
      else if (c == '[')
        second++;
      else if (c == ')')
        first--;
      else if (c == ']')
        second--;
      if ((first<0) || (second<0))
        f = 1;
      t = c;
    }
    if (!f && (!first && !second))
      printf("Yes\n");
    else
      printf("No\n");
    first = 0;
    second = 0;
  }
}
