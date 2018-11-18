/***************************************************************************************************
* Title : Decoding The message
* URL   : https://uva.onlinejudge.org/external/112/11220.pdf
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : Uses strtok and basic string operations in C
* meta  : tag-string, tag-lang-c, tag-uva-easy
***************************************************************************************************/
#include<stdio.h> 
#include<string.h> 

int main() {
  char string[3000];
  char string1[110][50];
  char *p;
  int l, count, test, res = 1, j = 0, k, c = 0;
  scanf("%d\n", &test);

  while (test--) {
    j = k = 0;
    while (gets(string))
    {
      count = 1;
      p = strtok(string, "' '");
      if (p == NULL)
        break;
      if (p)
      {
        l = strlen(p);
        if (l >= count)
          string1[j][k++] = p[count - 1];
        else
          count--;
      }
      while (p = strtok(NULL, "' '"))
      {
        if (p)
        {
          count++;
          l = strlen(p);
          if (l >= count)
            string1[j][k++] = p[count - 1];
          else
            count--;
        }
      }
      string1[j][k] = '\0';
      j++; k = 0;
    }

    if (c)
      printf("\n");

    c = 1;
    printf("Case #%d:\n", res++);

    for (l = 0; l < j; l++)
      printf("%s\n", string1[l]);
  }
  return 0;
}

// may be first version; requires this instead, tag-lang-c, tag-automaton
#include<ctype.h> 

int main() {
  int n, i, l, nw, pos;
  char c, t;

  scanf("%d", &n);
  getchar();

  for (i = 0; i < n; i++) {
    l = 0;
    nw = 0;
    pos = 0;
    t = '\0';

    if (i)
      putchar('\n');
    printf("Case #%d:\n", i + 1);

    while ((c = getchar())) {
      if (c == '\n') {
        if (t == '\n')
          break;
        else
          putchar('\n');

        l = 0;
        nw = 0;
      }
      else if (isalpha(c)) {
        if (!l) {
          if (!nw)
            putchar(c);
          nw++;
          l = 1;
          pos = 1;
        }
        else {
          pos++;
          if (pos == nw)
            putchar(c);
        }
      }
      else if (c == EOF)
        break;
      else {
        if (pos < nw && pos) {
          nw--;
          pos = 0;
        }
        l = 0;
      }
      t = c;
    }
  }

  return 0;
}
