/***************************************************************************************************
* Title : One Little, Two Little, Three Little Endians
* meta  : tag-math, tag-bit-manip
***************************************************************************************************/

#include<stdio.h>

int main(void) {
  int little,a,b,c,d,s;

  while (scanf("%d", &little) != EOF) {
    c = little >> 16;
    a = little;
    b = little >> 8;
    d = little >> 24;

    a = a - ((a >> 8) << 8);
    b = b - ((b >> 8) << 8);
    c = c - ((c >> 8) << 8);
    s = d + (c << 8) + (b << 16) + (a << 24);

    if (little < 0)
      s += 256;

    printf("%d converts to %d\n", little, s);
  }
}
