/***************************************************************************************************
* Title : Periodic Strings
* Notes : String Matching, probably before I knew about KMP
* meta  : tag-string, tag-lang-c
***************************************************************************************************/
#include<stdio.h>
#include<string.h>

int main() {
  int t, i, j, k, f;
  char str[90], cmp[50], *p, len;

  scanf("%d", &t);
  getchar();

  for (i = 0; i < t; i++) {
    if (i)
      putchar('\n');

    getchar();
    gets(str);

    len = strlen(str);
    for (j = 1; j < (len + 3) / 2; j++) {
      if (!(len%j)) {
        p = str;
        f = 1;
        for (k = 0; k < j; k++)
          cmp[k] = str[k];
        cmp[k] = '\0';

        if (j > 1) {
          for (p = str + j; p < str + (len + 2) / 2; p += j) {
            if (strncmp(p, cmp, j)) {
              f = 0;
              break;
            }
          }
        }
        else {
          for (p = str + j; p < str + len; p += j) {
            if (strncmp(p, cmp, j)) {
              f = 0;
              break;
            }
          }
        }
      }
      else
        f = 0;

      if (f)
        break;
    }

    if (f)
      printf("%d\n", strlen(cmp));
    else
      printf("%d\n", len);
  }

  return 0;
}
