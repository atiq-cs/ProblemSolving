/***************************************************************************************************
* Title  : The Decoder
* Notes : Type normal encoding of strings
* meta  : tag-string, tag-uva-easy
***************************************************************************************************/

#include<stdio.h>

void main() {
  char c, k;

  while ((c = getchar()) != EOF) {
    if (c == '\n')
      k = c;
    else
      k = c - 7;

    putchar(k);
  }
}
