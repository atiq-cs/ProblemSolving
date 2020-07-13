/***************************************************************************************************
* Title : Encoder and Decoder
* Comp  : O(N)
* meta  : tag-string, tag-uva-easy
***************************************************************************************************/

#include<stdio.h>
#include<string.h>
#include<ctype.h>

void main() {
  char ms[240];
  short i, a, b, c, d, f, len;

  while (gets(ms)) {
    len = strlen(ms);

    if (isdigit(ms[0])) {
      for (i = len - 1; i > 0; ) {
        a = ms[i] - '0';
        b = ms[i - 1] - '0';
        c = ms[i - 2] - '0';
        d = a * 10 + b;

        if (i > 1)
          f = d * 10 + c;
        else
          f = 128;

        if (f < 127) {
          i -= 3;
          printf("%c", f);
        }
        else {
          i -= 2;
          printf("%c", d);
        }
      }
    }
    else {
      for (i = len - 1; i >= 0; i--) {
        a = (short) ms[i];

        while (a) {
          b = a % 10;
          printf("%hd", b);
          a /= 10;
        }
      }
    }

    printf("\n");
  }
}
