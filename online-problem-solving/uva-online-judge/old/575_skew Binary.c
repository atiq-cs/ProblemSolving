/***************************************************************************************************
* Title : Skew Binary
* URL   : 575
* Status: Accepted
* Notes : summing powers skew binary numbers are found.
*   It's not a base conversion problem
* meta  : tag-math
***************************************************************************************************/
#include<stdio.h>
#include<string.h>
#include<math.h>

int main() {
  char num[1000];
  long res;
  int len, i;

  while (gets(num) && (num[0] != '0' || num[1] != '\0')) {
    len = strlen(num);

    for (res = 0, i = 0; i < len; i++)
      res += (num[i] - '0') * (pow((double)2, (double)(len - i)) - 1);

    printf("%ld\n", res);
  }

  return 0;
}
