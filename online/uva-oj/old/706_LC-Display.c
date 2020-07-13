/***************************************************************************************************
* Title : LC-Display
* Notes : old C Style macro defines
* meta  : tag-string, tag-lang-c, tag-uva-easy
***************************************************************************************************/

#include<stdio.h>
#include<string.h>

#define put2  putchar(32);for (j=1;j<s+1;j++) putchar('-');putchar(32);
#define put1  for (j=0;j<s+2;j++) putchar(32);
#define put3  for (j=0;j<s+1;j++) putchar(32); putchar('|');
#define put4  putchar('|');for (j=0;j<s;j++) putchar(32);putchar('|');
#define put5  putchar('|');for (j=0;j<s+1;j++) putchar(32);

int main() {
  int i, s, ln, j, k;
  char n[10];

  while (scanf("%d %s", &s, n) && (s || n[0] != '0' || n[1] != NULL)) {
    ln = strlen(n);

    for (i = 0; i < ln; i++) {
      if (i)
        putchar(32);
      if (n[i] == '1' || n[i] == '4')
        put1
      else if (n[i] >= '0' && n[i] <= '9')
        put2
    }
    putchar('\n');

    for (k = 0; k < s; k++) {
      for (i = 0; i < ln; i++) {
        if (i)
          putchar(32);
        if (n[i] == '1' || n[i] == '2' || n[i] == '3' || n[i] == '7')
          put3
        else if (n[i] == '4' || n[i] == '8' || n[i] == '9' || n[i] == '0')
          put4
        else if (n[i] == '5' || n[i] == '6')
          put5
      }
      putchar('\n');
    }

    for (i = 0; i < ln; i++) {
      if (i)
        putchar(32);

      if (n[i] == '0' || n[i] == '1' || n[i] == '7')
        put1
      else if (n[i] > '1' && n[i] <= '9')
        put2
    }
    putchar('\n');

    for (k = 0; k < s; k++) {
      for (i = 0; i < ln; i++) {
        if (i)
          putchar(32);
        if (n[i] == '1' || n[i] == '3' || n[i] == '4' || n[i] == '5' || n[i] == '7'
            || n[i] == '9') {
          put3
        }
        else if (n[i] == '2')
          put5
        else if (n[i] == '6' || n[i] == '8' || n[i] == '0')
          put4
      }
      putchar('\n');
    }
    for (i = 0; i < ln; i++) {
      if (i)
        putchar(32);

      if (n[i] == '1' || n[i] == '4' || n[i] == '7')
        put1
      else if (n[i] >= '0' && n[i] <= '9')
        put2
    }

    puts("\n");
  }

  return 0;
}
