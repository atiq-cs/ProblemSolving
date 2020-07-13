/***************************************************************************************************
* Title : Factorial Frequencies
* URL   : 324
* Status: Accepted
* Notes : Easy problem no special case, only challenge is big int
* meta  : tag-big-integer, tag-number-theory
***************************************************************************************************/
#include <math.h>
#include <string.h>
#include <stdio.h>

int digit[11];

// ref: 'ds/BigInt.cpp'
class BigInt;

int main() {
  int i, n;

  BigInt fact[400], tmp = BigInt("1"), aux = BigInt("2");

  fact[0] = BigInt("1");
  for (i = 1; i < 370; i++) {
    fact[i] = fact[i - 1] * aux;
    aux = aux + tmp;
  }

  while (scanf("%d", &n) && n) {
    fact[n - 1].show();
    printf("%d! --\n", n);
    for (i = 0; i < 5; i++)
      printf("   (%d)    %d", i, digit[i]);
    putchar('\n');

    for (i = 5; i < 10; i++)
      printf("   (%d)    %d", i, digit[i]);
    putchar('\n');
  }

  return 0;
}
