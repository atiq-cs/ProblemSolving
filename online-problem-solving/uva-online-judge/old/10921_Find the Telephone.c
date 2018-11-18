/***************************************************************************************************
* URL   : 10921
* Notes :
* meta  : tag-string, tag-hash-table, tag-lang-c
***************************************************************************************************/
#include<stdio.h>

void main() {
  char c;

  while ((c = getchar()) != EOF) {
    if (c == 'A' || c == 'B' || c == 'C')
      c = '2';
    else if (c == 'D' || c == 'E' || c == 'F')
      c = '3';
    else if (c == 'G' || c == 'H' || c == 'I')
      c = '4';
    else if (c == 'J' || c == 'K' || c == 'L')
      c = '5';
    else if (c == 'M' || c == 'N' || c == 'O')
      c = '6';
    else if (c == 'P' || c == 'Q' || c == 'R' || c == 'S')
      c = '7';
    else if (c == 'T' || c == 'U' || c == 'V')
      c = '8';
    else if (c == 'W' || c == 'X' || c == 'Y' || c == 'Z')
      c = '9';
    putchar(c);
  }
}
