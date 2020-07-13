/***************************************************************************************************
* URL   : https://uva.onlinejudge.org/external/6/673.pdf
* Date  : 2007-03-19
* Notes : Iterates and checks for imbalance during iteration, on each character
*   Could have done early termination on line 25 and 35
* meta  : tag-parentheses, tag-automaton, tag-ds-stack
***************************************************************************************************/
#include<stdio.h>

int main() {
  char c, t;
  short first = 0, second = 0;
  short f;  // value of 1 means unbalanced
  unsigned i, n;

  scanf("%u%*c", &n);

  for (i = 0; i<n; i++) {
    f = 0;
    t = 0;

    while ((c = getchar()) != '\n') {
      // Take care of invalid pairs, these can't appear as per problem spec
      // "(]", "[)"
      if (!f)
        // previous char is t and current char is c
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

    // initialize variables for next string
    first = 0;
    second = 0;
  }

  return 0;
}
