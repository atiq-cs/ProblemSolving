/***************************************************************************************************
* Title : What's the frequency, Kenneth?
* URL   : 499
* Comp  : O(n^2)
* Notes :
* meta  : tag-lang-c, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>
#include<ctype.h>

void main() {
  char c, str[80], tm[80];
  int i = 0, ln, j, fr[80], max, p = 0, k;

  while ((c = getchar()) != EOF) {
    if ((c != ' ' && c != '\n') && ((c > 47 && c < 58) || (c > 64 && c < 127)))
      str[p++] = c;

    if (c == '\n') {
      str[p] = NULL;
      for (ln = 0; str[ln]; ln++);

      max = 0;
      for (i = 0; i < ln; i++)
        fr[i] = 0;

      for (i = 0; i < ln - 1; i++)
        for (j = i + 1; j < ln; j++)
        {
          if (str[i] == str[j])
            fr[i]++;

          if (max < fr[i])
            max = fr[i];
        }

      j = 0;
      for (i = 0; i < ln; i++)
        if (fr[i] == max)
          tm[j++] = str[i];
      tm[j] = NULL;

      for (i = 0; i < j - 1; i++)
        for (k = i + 1; k < j; k++)
          if ((isupper(tm[k]) && islower(tm[i])) || tm[i] > tm[k]) {
            c = tm[i];
            tm[i] = tm[k];
            tm[k] = c;
          }

      for (i = 0; i < j; i++)
        printf("%c", tm[i]);
      printf(" %d\n", max + 1);
      p = 0;
    }
  }
}
