/***************************************************************************************************
* Title : Kibbles `n' Bits `n' Bits `n' Bits
* Notes  : hexa inputs and printing in string
* meta  : tag-base-conversion, tag-string tag-uva-easy
***************************************************************************************************/

#include<stdio.h>

void display_binary(int x) {
  int c, v = 0x1000;

  for (c = 0; c < 13; c++) {
    if (x&v)
      putchar('1');
    else
      putchar('0');

    v >>= 1;
  }
}

void main() {
  int Hex1, Hex2, T, i, res_op;
  char Operator;
  scanf("%d", &T);

  for (i = 0; i < T; i++) {
    scanf("%X %c %X", &Hex1, &Operator, &Hex2);

    if (Operator == '+')
      res_op = Hex1 + Hex2;
    else
      res_op = Hex1 - Hex2;

    display_binary(Hex1);
    printf(" %c ", Operator);
    display_binary(Hex2);
    printf(" = %d\n", res_op);
  }
}
