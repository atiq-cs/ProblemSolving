/***************************************************************************************************
* URL   : 10260
* Status: Accepted
* Notes : 
* meta  : tag-string, tag-hash-table, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>

void main() {
  char c, p;
  short t, f = 0;

  while ((c = getchar()) != EOF) {
    if (c == 'B' || c == 'F' || c == 'P' || c == 'V')
      t = 1;
    else if (c == 'C' || c == 'G' || c == 'J' || c == 'K' || c == 'Q' || c == 'S' || c == 'X' || c == 'Z') 
      = 2;
    else if (c == 'D' || c == 'T')
      t = 3;
    else if (c == 'L')
      t = 4;
    else if (c == 'M' || c == 'N')
      t = 5;
    else if (c == 'R')
      t = 6;
    else
      t = 0;

    if (c == '\n')
      putchar(c);
    else if (f != t && t)
      printf("%hd", t);

    f = t;
  }
}
