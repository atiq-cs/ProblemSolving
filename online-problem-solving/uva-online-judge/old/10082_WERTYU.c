/***************************************************************************************************
* URL   : https://uva.onlinejudge.org/external/100/10082.pdf
* Date  : 2006-08-27
* Notes : Could be shorter code if mapping was done with array of chars or using
*   hash-table to represent the mapping
* meta  : tag-string, tag-lang-c, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>
#include<ctype.h>

int main() {
  char c;

  while ((c = getchar()) != EOF) {
    if (c == 'W')
      c = 'Q';
    else if (isdigit(c) && c != '1' && c != '0')
      c--;
    else if (c == '0') c = '9';
    else if (c == '1') c = '`';
    else if (c == '-') c = '0';
    else if (c == '=') c = '-';
    else if (c == '\\') c = '=';
    else if (c == 'E') c = 'W';
    else if (c == 'R') c = 'E';
    else if (c == 'T') c = 'R';
    else if (c == 'Y') c = 'T';
    else if (c == 'U') c = 'Y';
    else if (c == 'I') c = 'U';
    else if (c == 'O') c = 'I';
    else if (c == 'P') c = 'O';
    else if (c == '[') c = 'P';
    else if (c == ']') c = '[';
    else if (c == 'S') c = 'A';
    else if (c == 'D') c = 'S';
    else if (c == 'F') c = 'D';
    else if (c == 'G') c = 'F';
    else if (c == 'H') c = 'G';
    else if (c == 'J') c = 'H';
    else if (c == 'K') c = 'J';
    else if (c == 'L') c = 'K';
    else if (c == ';') c = 'L';
    else if (c == 'X') c = 'Z';
    else if (c == 'C') c = 'X';
    else if (c == 'V') c = 'C';
    else if (c == 'B') c = 'V';
    else if (c == 'N') c = 'B';
    else if (c == 'M') c = 'N';
    else if (c == ',') c = 'M';
    else if (c == '.') c = ',';
    else if (c == '/') c = '.';
    else if (c == '\'') c = ';';

    putchar(c);
  }

  return 0;
}
