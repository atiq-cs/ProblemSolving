/***************************************************************************************************
* URL   : https://uva.onlinejudge.org/external/109/10924.pdf
* Date  : 2006-08-27
* Notes : Sum the values of letters and find if sum is prime or not
* meta  : tag-number-theory, tag-primality, tag-lang-c
***************************************************************************************************/
#include<stdio.h>
#include<ctype.h>
#include<math.h>

int main() {
  char c;
  short v = 0, sq, i;

  while ((c = getchar()) != EOF)
    if (c == '\n') {
      // at this point when we encounter a nwe line we have a sum
      // check if this is a prime
      sq = sqrt(v);
      for (i = 2; i <= sq; i++)
        if (!(v%i))
          break;

      printf(sq == i - 1? "It is a prime word.\n" : "It is not a prime word.\n");
      v = 0;
    }
    else if (islower(c))
      v += (short) c - 96;
    else if (isupper(c))
      v += (short) c - 38;

  return 0;
}
