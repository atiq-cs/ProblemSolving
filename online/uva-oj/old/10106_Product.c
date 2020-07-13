/***************************************************************************************************
* Title : Product
* Notes : multiplication of large numbers, using most prob grade school algo
* meta  : tag-big-integer
***************************************************************************************************/

#include<stdio.h>
#include<string.h>

void main() {
  char a[251], b[251], m[502], ra[502];
  short la, lb, i, j, max, ml, ad, carry, lt, dif;

  while (gets(a)) {
    gets(b);
    la = strlen(a);
    lb = strlen(b);

    for (i = 0; i < la + lb; i++) {
      m[i] = 0;
      ra[i] = 0;
    }
    lt = 0;

    // multiplication
    for (i = lb - 1; i >= 0; i--) {
      carry = 0; lt = 0;
      for (j = la - 1; j >= 0; j--) {
        ml = (b[i] - '0')*(a[j] - '0' ) + carry;
        if (ml == 10) {
          m[lt] = 0;
          carry = 1;
        }
        else {
          m[lt] = ml % 10;
          carry = ml / 10;
        }
        lt++;
      }

      if (carry) {
        m[lt++] = carry;
        carry = 0;
      }

      // addition
      dif = lb - i - 1;
      for (j = dif; j < lt + dif; j++) {
        ad = ra[j] + m[j - dif] + carry;
        if (ad > 9) {
          ra[j] = ad - 10;
          carry = 1;
        }
        else {
          ra[j] = ad;
          carry = 0;
        }
      }

      if (carry)
        ra[j++] = carry;
    }

    lt = 0;
    for (i = j - 1; i >= 0; i--) {
      if (ra[i] != 0)
        lt = 1;

      if (lt)
        putchar(ra[i] + '0');
    }

    if (!lt)
      putchar('0');
    putchar('\n');
  }
}
