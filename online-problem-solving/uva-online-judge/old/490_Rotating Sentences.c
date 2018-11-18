/***************************************************************************************************
* Title : Rotating Sentences
* Notes : String Matrix operation
* meta  : tag-string
***************************************************************************************************/
#include<stdio.h>
#include<string.h>

void main() {
  char lin[101][101];
  short nl = 0, fr[101], i, j, max;

  while (gets(lin[nl]))
    fr[nl++] = strlen(lin[nl]);

  for (i = 1, max = fr[0]; i < nl; i++)
    if (fr[i] > max)
      max = fr[i];

  for (i = 0; i < max; i++) {
    for (j = nl - 1; j >= 0; j--)
      if (i < fr[j])
        putchar(lin[j][i]);

      else
        putchar(' ');

    putchar('\n');
  }
}
